using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using My_Little_Dictionary___Anniversary_Edition.Data;
using My_Little_Dictionary___Anniversary_Edition.DTOs.Security;
using My_Little_Dictionary___Anniversary_Edition.Model;
using My_Little_Dictionary___Anniversary_Edition.Services.Base;
using My_Little_Dictionary___Anniversary_Edition.Services.Interfaces;
using My_Little_Dictionary___Anniversary_Edition.Validation;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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


        public async Task<LoginResponseDTO> Login(LoginRequestDTO request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            user.ValidateOnNull(request.UserName, "User", "User Name");

            bool isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Password);

            if (!isPasswordValid)
                throw new ValidationException("The password is incorrect");


            return GenerateBearerToken(user);
        }

        public async Task<LoginResponseDTO> Register(RegistrationRequestDTO request)
        {
            ValidateRegistrationRequest(request);

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

                return loginResult;
            }
            else
            {
                throw new ValidationException(userResult.Errors.Select(err => err.Description).ToList());
            }
        }

        private void ValidateRegistrationRequest(RegistrationRequestDTO request)
        {
            ValidationHelper.ValidateSequence(
                () =>
                {
                    bool usernameExists = _context.Users.Any(u => u.UserName == request.UserName);
                    if (usernameExists)
                    {
                        throw new ValidationException("User with this name already exists");
                    }
                }, 
                () =>
                {
                    bool emailExists = _context.Users.Any(u => u.Email == request.Email);

                    if (emailExists)
                    {
                        throw new ValidationException("User with this email already exists");
                    }
                },
                () =>
                {
                    if (request.Password != request.PasswordConfirm)
                        throw new ValidationException("Passwords are different");
                },
                () =>
                {
                    if (request.Email != request.EmailConfirm)
                        throw new ValidationException("Emails are different");
                }
                );
        }

        public async Task<LoginResponseDTO> GetBearerWithRefresh(Guid refreshToken)
        {
            RefreshToken refreshResult = _context.RefreshToken
                .Include(item => item.User)
                .FirstOrDefault(token => token.Token == refreshToken);

            if (refreshResult == null || !refreshResult.Valid)
            {
                throw new ValidationException("Refresh token not found");
            }

            refreshResult.Use(_context);
            

            return GenerateBearerToken(refreshResult.User);
        }

        public IdentityUser GetUserByName(string name)
        {
            return _context.Users.FirstOrDefault(u => u.UserName == name);
        }

        public LoginResponseDTO GenerateBearerToken(IdentityUser user)
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
            var refreshToken = GenerateRefreshToken(user);

            return new LoginResponseDTO(bearer, token.ValidTo, refreshToken);
        }

        public Guid GenerateRefreshToken(IdentityUser user)
        {
            RefreshToken refreshToken = new RefreshToken(user, _configuration);

            _context.Add(refreshToken);
            _context.SaveChanges();

            return refreshToken.Token;
        }
    }
}
