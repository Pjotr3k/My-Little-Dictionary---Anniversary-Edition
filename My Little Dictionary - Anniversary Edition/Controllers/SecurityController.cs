using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using My_Little_Dictionary___Anniversary_Edition.Data;
using My_Little_Dictionary___Anniversary_Edition.DTOs.Security;
using My_Little_Dictionary___Anniversary_Edition.Services.Interfaces;

namespace My_Little_Dictionary___Anniversary_Edition.Controllers
{
    [Route("[controller]/[Action]")]
    [ApiController]
    [AllowAnonymous]
    public class SecurityController : BaseController
    {
        private readonly ILogger<SecurityController> _logger;
        private readonly ISecurityService _securityService;

        public SecurityController(ILogger<SecurityController> logger, ISecurityService linguisticsService, ApplicationDBContext context) : base(logger, context)
        {
            _logger = logger;
            _securityService = linguisticsService;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDTO request)
        {
            return await ResponseWithValidationResponseAsync(async () 
                => await _securityService.Register(request));
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO request)
        {
            return await ResponseWithValidationResponseAsync(async()
                => await _securityService.Login(request));
        }

        [HttpPost]
        public async Task<IActionResult> RefreshBearer([FromBody] Guid refreshToken)
        {
            return await ResponseWithValidationResponseAsync(async()
                => await _securityService.GetBearerWithRefresh(refreshToken));
        }
    }
}
