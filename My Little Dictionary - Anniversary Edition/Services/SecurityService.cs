using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using My_Little_Dictionary___Anniversary_Edition.Data;
using My_Little_Dictionary___Anniversary_Edition.DTOs.Security;
using My_Little_Dictionary___Anniversary_Edition.Model;
using My_Little_Dictionary___Anniversary_Edition.Services.Base;
using My_Little_Dictionary___Anniversary_Edition.Services.Interfaces;
using System.Collections.Specialized;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace My_Little_Dictionary___Anniversary_Edition.Services
{
    public class SecurityService : BaseContextService, ISecurityService
    {
        readonly UserManager<IdentityUser> _userManager;
        readonly IConfiguration _configuration;
        IHttpContextAccessor _httpContext;

        public SecurityService(ApplicationDBContext context, UserManager<IdentityUser> userManager, IConfiguration configuration, IHttpContextAccessor httpContext) : base(context)
        {
            _userManager = userManager;
            _configuration = configuration;
            _httpContext = httpContext;
        }

        private async Task<IdentityUser> GetAuthUser()
        {
            if (_userManager == null)
                return null;

            var userClaims = _httpContext?.HttpContext?.User;

            if (userClaims == null)
                return null;

            return await _userManager.GetUserAsync(userClaims);
        }


        public async Task<ValidationResponse<LoginResponseDTO>> Login(LoginRequestDTO request)
        {
            ValidationResponse<LoginResponseDTO> validation = new ValidationResponse<LoginResponseDTO>();

            var user = await _userManager.FindByNameAsync(request.UserName);

            if (user == null)
            {
                validation.Errors.Add("User not found");
                return validation;
            }

            bool isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Password);

            if (!isPasswordValid)
                return validation;

            return validation.Merge(GenerateBearerToken(user));
        }

        public async Task<ValidationResponse<LoginResponseDTO>> Register(RegistrationRequestDTO request)
        {
            ValidationResponse<LoginResponseDTO> validation = new ValidationResponse<LoginResponseDTO>();

            request.Validate(validation);

            bool usernameExists = _context.Users.Any(u => u.UserName == request.UserName);
            if (usernameExists)
            {
                validation.Errors.Add("User with this name already exists");
            }

            bool emailExists = _context.Users.Any(u => u.Email == request.Email);

            if (emailExists)
            {
                validation.Errors.Add("User with this email already exists");
            }

            if (validation.Errors.Count > 0)
                return validation;

            IdentityUser user = new IdentityUser()
            {
                UserName = request.UserName,
                Email = request.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            var userResult = await _userManager.CreateAsync(user, request.Password);

            if (userResult.Succeeded)
            {
                var loginResult = await Login(new LoginRequestDTO()
                {
                    UserName = request.UserName,
                    Password = request.Password
                });

                validation.Merge(loginResult);
            }
            else
            {
                validation.Errors.AddRange(userResult.Errors.Select(err => err.Description));
            }

            return validation;
        }

        public async Task<ValidationResponse<LoginResponseDTO>> GetBearerWithRefresh(Guid refreshToken)
        {
            ValidationResponse<LoginResponseDTO> validation = new ValidationResponse<LoginResponseDTO>();

            RefreshToken refreshResult = _context.RefreshToken
                .Include(item => item.User)
                .FirstOrDefault(token => token.Token == refreshToken);

            if (refreshResult == null || !refreshResult.Valid)
            {
                validation.Errors.Add("Refresh token not found");
                return validation;
            }

            refreshResult.Use();

            return validation.Merge(GenerateBearerToken(refreshResult.User));
        }

        public ValidationResponse<IdentityUser> GetUserByName(string name)
        {
            ValidationResponse<IdentityUser> validation = new ValidationResponse<IdentityUser>();
            validation.Result = _context.Users.FirstOrDefault(u => u.UserName == name);
            if (validation.Result == null)
            {
                validation.Errors.Add("User not found");
            }
            return validation;
        }

        public ValidationResponse<LoginResponseDTO> GenerateBearerToken(IdentityUser user)
        {
            var authClaims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.NameIdentifier, user.Id)
                };

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var token = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    audience: _configuration["Jwt:Audience"],
                    expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:Expires"])),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            string bearer = new JwtSecurityTokenHandler().WriteToken(token);
            var (refreshToken, _) = GenerateRefreshToken(user);

            return new ValidationResponse<LoginResponseDTO>(new LoginResponseDTO(bearer, token.ValidTo, refreshToken));
        }

        public ValidationResponse<Guid> GenerateRefreshToken(IdentityUser user)
        {
            RefreshToken refreshToken = new RefreshToken(user, _configuration);

            _context.Add(refreshToken);
            _context.SaveChanges();

            return new ValidationResponse<Guid>(refreshToken.Token);
        }
    }
}
