using Microsoft.AspNetCore.Mvc;
using My_Little_Dictionary___Anniversary_Edition.Data;
using My_Little_Dictionary___Anniversary_Edition.DTOs;
using My_Little_Dictionary___Anniversary_Edition.Mappers;
using My_Little_Dictionary___Anniversary_Edition.Services.Interfaces;

namespace My_Little_Dictionary___Anniversary_Edition.Controllers
{
    [Route("[Controller]/[Action]")]
    [ApiController]
    public class DictionaryController : BaseController
    {
        private readonly ILogger<DictionaryController> _logger;
        private readonly ILinguisticsService _linguisticsService;
        private readonly IDictionaryService _dictionaryService;

        public DictionaryController(ILogger<DictionaryController> logger, ILinguisticsService linguisticsService, IDictionaryService dictionaryService, ApplicationDBContext context) : base(logger, context)
        {
            _linguisticsService = linguisticsService;
            _dictionaryService = dictionaryService;
        }

        [HttpPost]
        public ActionResult Dictionary(LexiconInsertDTO request)
        {
            return ResponseWithValidationResponse(() 
                => _linguisticsService.AddDictionary(request));
        }

        [HttpGet("{id}")]
        public ActionResult Dictionary([FromRoute] Guid id)
        {
            return ResponseWithValidationResponse(()
                => _linguisticsService.GetDictionaryById(id));
        }

        [HttpPost]
        public ActionResult Entry([FromBody] EntryInsertDTO request)
        {
            return ResponseWithValidationResponse(()
                => _dictionaryService.AddEntry(request));
        }

        [HttpPost]
        public IActionResult PartOfSpeech([FromBody] PartOfSpeechInsertDTO request)
        {
            return ResponseWithValidationResponse(()
                => _linguisticsService.AddPartOfSpeech(request)?.ToDTO());
        }

        [HttpGet("{id}")]
        public IActionResult PartOfSpeech([FromRoute] Guid id)
        {
            return ResponseWithValidationResponse(()
                => _linguisticsService.GetPartOfSpeechById(id)?.ToDTO());
        }

        [HttpGet("{dictionaryId}/{posName}")]
        public IActionResult PartOfSpeech([FromRoute] Guid dictionaryId, string posName)
        {
            return ResponseWithValidationResponse(()
                => _linguisticsService.GetPartOfSpeechByName(posName, dictionaryId)?.ToDTO());
        }

        [HttpPost("{code}")]
        public IActionResult PartOfSpeech([FromBody] PaginationRequest request, [FromRoute] Guid code)
        {
            return ResponseWithValidationResponse(()
                => _linguisticsService.GetPartsOfSpeechByDictionary(request, code)
                .Select(pos => new PartOfSpeechDTO(pos)));
        }

        [HttpGet("{pos}")]
        public IActionResult FormByPartOfSpeech([FromRoute] Guid pos)
        {
            return ResponseWithValidationResponse(()
                => _linguisticsService.GetFormsByPos(pos).Select(item => item.ToDTO()));
        }

        [HttpGet("{id}")]
        public IActionResult Form([FromRoute] Guid id)
        {
            return ResponseWithValidationResponse(()
                => _linguisticsService.GetFormById(id)?.ToDTO());
        }
    }
}
