using Microsoft.AspNetCore.Mvc;
using My_Little_Dictionary___Anniversary_Edition.Data;
using My_Little_Dictionary___Anniversary_Edition.DTOs;
using My_Little_Dictionary___Anniversary_Edition.Services.Interfaces;
using My_Little_Dictionary___Anniversary_Edition.Mappers;
using Microsoft.AspNetCore.Authorization;

namespace My_Little_Dictionary___Anniversary_Edition.Controllers
{
    [Route("[Controller]/[Action]")]
    [ApiController]
    public class ProjectController : BaseController
    {
        private readonly ILogger<ProjectController> _logger;
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService, ILogger<ProjectController> logger, ApplicationDBContext context) : base(logger, context)
        {
            _projectService = projectService;
        }

        [HttpPost]
        public IActionResult Project([FromBody] ProjectInsertDTO request)
        {
            return ResponseWithValidationResponse(()
                => _projectService.AddProject(request)?.ToDTO());
        }

        [HttpGet("{projectCode}")]
        [AllowAnonymous]
        public IActionResult Project([FromRoute] string projectCode)
        {
            return ResponseWithValidationResponse(()
                => _projectService.GetProjectByCode(projectCode)?.ToDTO());
        }

        [HttpPost]
        public IActionResult Projects([FromBody] PaginationRequest request)
        {
            return ResponseWithValidationResponse(()
                => _projectService.GetProjects(request).Select(item => item.ToDTO()));
        }
    }
}
