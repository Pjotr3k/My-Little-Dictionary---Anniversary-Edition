using Microsoft.AspNetCore.Identity;
using My_Little_Dictionary___Anniversary_Edition.DTOs.Security;

namespace My_Little_Dictionary___Anniversary_Edition.Services.Interfaces
{
    public interface ISecurityService
    {
        public Task<LoginResponseDTO> Login(LoginRequestDTO request);
        public Task<LoginResponseDTO> Register(RegistrationRequestDTO request);
        public IdentityUser GetUserByName(string name);
        public Task<LoginResponseDTO> GetBearerWithRefresh(Guid refreshToken);

    }
}
