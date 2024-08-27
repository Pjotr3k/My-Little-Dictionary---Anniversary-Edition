using Microsoft.AspNetCore.Identity;
using My_Little_Dictionary___Anniversary_Edition.DTOs.Security;
using My_Little_Dictionary___Anniversary_Edition.Model;

namespace My_Little_Dictionary___Anniversary_Edition.Services.Interfaces
{
    public interface ISecurityService
    {
        public Task<ValidationResponse<LoginResponseDTO>> Login(LoginRequestDTO request);
        public Task<ValidationResponse<LoginResponseDTO>> Register(RegistrationRequestDTO request);
        public ValidationResponse<IdentityUser> GetUserByName(string name);
        public Task<ValidationResponse<LoginResponseDTO>> GetBearerWithRefresh(Guid refreshToken);

    }
}
