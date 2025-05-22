using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using My_Little_Dictionary___Anniversary_Edition.DTOs;
using My_Little_Dictionary___Anniversary_Edition.Mappers;
using My_Little_Dictionary___Anniversary_Edition.Model;
using My_Little_Dictionary___Anniversary_Edition.Services.Interfaces;

namespace My_Little_Dictionary___Anniversary_Edition.Controllers
{
    [Authorize]
    [Route("[controller]/[Action]")]
    [ApiController]
    public class LinguisticsController : ControllerBase
    {
        private readonly ILogger<LinguisticsController> _logger;
        private readonly ILinguisticsService _linguisticsService;

        public LinguisticsController(ILogger<LinguisticsController> logger, ILinguisticsService linguisticsService)
        {
            _logger = logger;
            _linguisticsService = linguisticsService;
        }

        [HttpPost]
        public IActionResult Language ([FromBody] LanguageInsertDTO request)
        {
            var result = _linguisticsService.AddLanguage(request);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Languages([FromBody] PaginationRequestDTO request)
        {
            var result = _linguisticsService.GetLanguages(request);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Language([FromRoute] Guid id)
        {
            var result = _linguisticsService.GetLanguageById(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Project([FromBody] ProjectInsertDTO request)
        {
            var result = _linguisticsService.AddProject(request);
            return Ok(result);
        }

        [HttpGet("{projectCode}")]
        [AllowAnonymous]
        public IActionResult Project([FromRoute] string projectCode)
        {
            var result = _linguisticsService.GetProjectByCode(projectCode);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Projects([FromBody] PaginationRequestDTO request)
        {
            var result = _linguisticsService.GetProjects(request);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult PartOfSpeech([FromBody] PartOfSpeechInsertDTO request)
        {
            var result = _linguisticsService.AddPartOfSpeech(request);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult PartOfSpeech([FromRoute] Guid id)
        {
            var result = _linguisticsService
                .GetPartOfSpeechById(id)
                .Transform(item => new PartOfSpeechDTO(item));

            return Ok(result);
        }

        [HttpGet("{projectCode}/{posName}")]
        public IActionResult PartOfSpeech([FromRoute] string projectCode, string posName)
        {
            var result = _linguisticsService
                .GetPartOfSpeechByName(posName, projectCode)
                .Transform(item => new PartOfSpeechDTO(item));

            return Ok(result);
        }

        [HttpPost("{code}")]
        public IActionResult PartOfSpeech([FromBody] PaginationRequestDTO request, [FromRoute] string code)
        {
            var result = _linguisticsService
                .GetPartsOfSpeechByProject(request, code)
                .Select(pos => new PartOfSpeechDTO(pos));

            return Ok(result);
        }

        //[HttpPost]
        //public IActionResult Form([FromBody] FormInsertDTO request)
        //{
        //    var result = _linguisticsService.AddForm(request);
        //    return Ok(result);
        //}

        //[HttpPost("Range")]
        //public IActionResult Form([FromBody] List<FormInsertDTO> request)
        //{
        //    var result = _linguisticsService.BulkAddForm(request);
        //    return Ok(result);
        //}


        [HttpGet]
        public IActionResult Form([FromQuery] Guid? pos)
        {
            ValidationResponse<List<FormDTO>> result;

            if (pos != null)
            {
                result = _linguisticsService
                .GetFormsByPos((Guid)pos)
                .ToDTO();
            }
            else
            {
                result = _linguisticsService
                .GetAllForms()
                .ToDTO();
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Form([FromRoute] Guid id)
        {
            var result = _linguisticsService.GetFormById(id);
            return Ok(result);
        }

    }
}
