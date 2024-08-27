using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using My_Little_Dictionary___Anniversary_Edition.DTOs.Security;
using My_Little_Dictionary___Anniversary_Edition.Services.Interfaces;

namespace My_Little_Dictionary___Anniversary_Edition.Controllers
{
    [Route("[controller]/[Action]")]
    [ApiController]
    [AllowAnonymous]
    public class SecurityController : ControllerBase
    {
        private readonly ILogger<SecurityController> _logger;
        private readonly ISecurityService _securityService;

        public SecurityController(ILogger<SecurityController> logger, ISecurityService linguisticsService)
        {
            _logger = logger;
            _securityService = linguisticsService;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDTO request)
        {
            var result = await _securityService.Register(request);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO request)
        {
            var result = await _securityService.Login(request);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> RefreshBearer([FromBody] Guid refreshToken)
        {
            var result = await _securityService.GetBearerWithRefresh(refreshToken);
            return Ok(result);
        }
    }
}
