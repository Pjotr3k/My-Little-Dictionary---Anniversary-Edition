using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using My_Little_Dictionary___Anniversary_Edition.Data;
using My_Little_Dictionary___Anniversary_Edition.DTOs;
using My_Little_Dictionary___Anniversary_Edition.Services.Interfaces;
using My_Little_Dictionary___Anniversary_Edition.Mappers;

namespace My_Little_Dictionary___Anniversary_Edition.Controllers
{
    [Route("[controller]/[Action]")]
    [ApiController]
    public class LanguageController : BaseController
    {
        ILanguageService _languageService;

        public LanguageController(ILanguageService languageService, ILogger<ProjectController> logger, ApplicationDBContext context) : base(logger, context)
        {
            _languageService = languageService;
        }

        [HttpPost]
        public IActionResult Language([FromBody] LanguageInsertDTO request)
        {
            return ResponseWithValidationResponse(()
                => _languageService.AddLanguage(request)?.ToDTO());
        }

        [HttpPost]
        public IActionResult Languages([FromBody] PaginationRequest request)
        {
            return ResponseWithValidationResponse(()
                => _languageService.GetLanguages(request).Select(item => item.ToDTO()));
        }

        [HttpGet("{id}")]
        public IActionResult Language([FromRoute] Guid id)
        {
            return ResponseWithValidationResponse(()
                => _languageService.GetLanguageById(id)?.ToDTO());
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ImportLanguages()
        {
            return ResponseWithValidationResponse(()
                => {
                    _languageService.CSVImportLangs();
                    return "Success!!!";
                });
        }
    }
}
