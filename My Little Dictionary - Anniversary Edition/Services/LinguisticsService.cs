using Microsoft.EntityFrameworkCore;
using My_Little_Dictionary___Anniversary_Edition.Data;
using My_Little_Dictionary___Anniversary_Edition.DTOs;
using My_Little_Dictionary___Anniversary_Edition.Model;
using My_Little_Dictionary___Anniversary_Edition.Services.Base;
using My_Little_Dictionary___Anniversary_Edition.Services.Interfaces;
using My_Little_Dictionary___Anniversary_Edition.Validation;

namespace My_Little_Dictionary___Anniversary_Edition.Services
{
    public class LinguisticsService : BaseContextService, ILinguisticsService
    {
        private readonly ILanguageService _languageService;
        private readonly IProjectService _projectService;

        public LinguisticsService(ApplicationDBContext context) : base(context)
        {

        }

        public Lexicon AddDictionary(LexiconInsertDTO request)
        {
            Project project = _projectService.GetProjectById(request.ProjectID);
            Language language = _languageService.GetLanguageById(request.LanguageID);

            ValidationHelper.ValidateSequence(
                () => project.ValidateOnNull(),
                () => language.ValidateOnNull()
                );

            return AddDictionary(request.Data, project, language);
        }

        public Lexicon AddDictionary(LexiconDataDTO request, Project project, Language language)
        {
            Lexicon lexicon = new Lexicon()
            {
                Name = request.Name,
                Description = request.Description ?? "",
                Language = language,
                Project = project,
            };

            _context.Add(lexicon);
            _context.SaveChanges();

            return lexicon;
        }
        public PartOfSpeech AddPartOfSpeech(PartOfSpeechInsertDTO request)
        {
            Lexicon dictionary = GetDictionaryById(request.ProjectID)
                .ValidateOnNull($"No dictionary with id {request.ProjectID}");

            PartOfSpeech pos = new PartOfSpeech()
            {
                Name = request.Data.Name,
                Description = request.Data.Description ?? "",
                Dictionary = dictionary,
            };

            _context.Add(pos);

            foreach (var item in request.Forms)
            {
                Form form = new Form()
                {
                    Description = item.Description,
                    Name = item.Name,
                    PartOfSpeech = pos,
                };

                _context.Add(form);
            }

            _context.SaveChanges();

            return pos;

        }

        public PaginationResult<PartOfSpeech> GetPartsOfSpeechByLanguage(PaginationRequest? request, Guid projectID)
        {
            var query = _context.PartOfSpeech
                .Include(item => item.Dictionary)
                .Where(item => item.Dictionary.ID == projectID);

            return new PaginationResult<PartOfSpeech>(query, request);
        }

        public Form GetFormById(Guid id)
            => _context.Form.GetById(id);

        public PartOfSpeech GetPartOfSpeechById(Guid id)
            => _context.PartOfSpeech.GetById(id);

        public Lexicon GetDictionaryById(Guid id)
            => _context.Dictionary.GetById(id);

        public PartOfSpeech GetPartOfSpeechByName(string posName, Guid dictionaryId)
        {
            var dictionary = GetDictionaryById(dictionaryId)
                .ValidateOnNull(dictionaryId, "Project", "code");


            return _context.PartOfSpeech
                .FirstOrDefault(x => x.Dictionary == dictionary && x.Name == posName);
        }

        public List<Form> GetFormsByPos(Guid posId)
        {
            return _context.Form
                .Where(item => item.PartOfSpeech.ID == posId)
                .ToList();
        }

        public PaginationResult<PartOfSpeech> GetPartsOfSpeechByDictionary(PaginationRequest? request, Guid dictionaryId)
        {
            var project = GetDictionaryById(dictionaryId)
                .ValidateOnNull(dictionaryId.ToString(), "Project", "Code");

            return GetPartsOfSpeechByDictionary(request, project);
        }

        public PaginationResult<PartOfSpeech> GetPartsOfSpeechByDictionary(PaginationRequest? request, Lexicon dictionary)
        {
            PaginationResult<PartOfSpeech> validation = new PaginationResult<PartOfSpeech>(request);
            var result = _context.PartOfSpeech
                .Where(item => item.Dictionary == dictionary);

            return new PaginationResult<PartOfSpeech>(result, request);
        }
    }
}
