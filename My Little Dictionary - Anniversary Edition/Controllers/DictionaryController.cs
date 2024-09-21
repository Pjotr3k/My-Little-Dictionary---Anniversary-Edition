using Microsoft.AspNetCore.Mvc;
using My_Little_Dictionary___Anniversary_Edition.DTOs;
using My_Little_Dictionary___Anniversary_Edition.Services.Interfaces;

namespace My_Little_Dictionary___Anniversary_Edition.Controllers
{
    [Route("[Controller]/[Action]")]
    [ApiController]
    public class DictionaryController : ControllerBase
    {
        private readonly ILogger<DictionaryController> _logger;
        private readonly IDictionaryService _dictionaryService;

        public DictionaryController(ILogger<DictionaryController> logger, IDictionaryService dictionaryService)
        {
            _logger = logger;
            _dictionaryService = dictionaryService;
        }

        [HttpPost]
        public ActionResult Dictionary(DictionaryInsertDTO request)
        {
            var result = _dictionaryService.AddDictionary(request);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult Dictionary([FromRoute] Guid id)
        {
            var result = _dictionaryService.GetDictionaryById(id);
            return Ok(result);
        }

        [HttpGet]
        public ActionResult Dictionary()
        {
            var result = _dictionaryService.GetAllDictionaries();
            return Ok(result);
        }

        [HttpPost]
        public ActionResult Entry([FromBody] EntryInsertDTO request)
        {
            var result = _dictionaryService.AddEntry(request);
            return Ok(result);
        }
    }
}
