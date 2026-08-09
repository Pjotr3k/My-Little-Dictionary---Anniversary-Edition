using Microsoft.AspNetCore.Identity;
using Service.DTOs.Security;

namespace Service.Interfaces
{
    public interface ISecurityService
    {
        public Task<LoginResponseDTO> Login(LoginRequestDTO request);
        public Task<LoginResponseDTO> Register(RegistrationRequestDTO request);
        public IdentityUser GetUserByName(string name);
        public Task<LoginResponseDTO> GetBearerWithRefresh(Guid refreshToken);

    }
}
