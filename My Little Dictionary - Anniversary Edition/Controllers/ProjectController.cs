using Data;
using Microsoft.AspNetCore.Mvc;
using My_Little_Dictionary___Anniversary_Edition.Mappers;
using Service.DTOs;
using Service.Helpers;
using Service.Interfaces;

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

        [HttpGet]
        public IActionResult Project([FromQuery] string projectCode)
        {
            return ResponseWithValidationResponse(()
                => _projectService.GetProjectByCode(projectCode)?.ToDTO());
        }

        [HttpGet("{projectId}")]
        public IActionResult Project([FromRoute] Guid projectId)
        {
            return ResponseWithValidationResponse(()
                => _projectService.GetProjectById(projectId)?.ToDTO());
        }

        [HttpPost]
        public IActionResult Projects([FromBody] PaginationRequest request)
        {
            return ResponseWithValidationResponse(()
                => _projectService.GetProjects()
                .ToPaginationResult(request, item => item.ToDTO()));
        }
    }
}
