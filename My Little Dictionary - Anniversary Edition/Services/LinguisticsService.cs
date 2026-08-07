using Microsoft.EntityFrameworkCore;
using My_Little_Dictionary___Anniversary_Edition.Data;
using My_Little_Dictionary___Anniversary_Edition.DTOs;
using My_Little_Dictionary___Anniversary_Edition.Model;
using My_Little_Dictionary___Anniversary_Edition.Services.Base;
using My_Little_Dictionary___Anniversary_Edition.Services.Interfaces;
using My_Little_Dictionary___Anniversary_Edition.Validation;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace My_Little_Dictionary___Anniversary_Edition.Services
{
    public class LinguisticsService : BaseContextService, ILinguisticsService
    {
        private readonly ILanguageService _languageService;
        private readonly IProjectService _projectService;

        public LinguisticsService(ILanguageService languageService, IProjectService projectService, ApplicationDBContext context) : base(context)
        {
            _languageService = languageService;
            _projectService = projectService;
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
                Code = request.Code,
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

        public IQueryable<PartOfSpeech> GetPartsOfSpeechByLanguage(Guid projectID)
        {
            return _context.PartOfSpeech
                .Include(item => item.Dictionary)
                .Where(item => item.Dictionary.ID == projectID);
        }

        public Form GetFormById(Guid id, params Expression<Func<Form, object>>[] includeFuncs)
            => _context.Form.GetById(id, includeFuncs);

        public PartOfSpeech GetPartOfSpeechById(Guid id, params Expression<Func<PartOfSpeech, object>>[] includeFuncs)
            => _context.PartOfSpeech.GetById(id, includeFuncs);

        public Lexicon GetDictionaryById(Guid id, params Expression<Func<Lexicon, object>>[] includeFuncs)
            => _context.Dictionary.GetById(id, includeFuncs);

        public PartOfSpeech GetPartOfSpeechByName(string posName, Guid dictionaryId)
        {
            var dictionary = GetDictionaryById(dictionaryId)
                .ValidateOnNull(dictionaryId, "Project", "code");


            return _context.PartOfSpeech
                .FirstOrDefault(x => x.Dictionary == dictionary && x.Name == posName);
        }

        public IQueryable<Form> GetFormsByPos(Guid posId)
        {
            return _context.Form
                .Where(item => item.PartOfSpeech.ID == posId);
        }

        public IQueryable<PartOfSpeech> GetPartsOfSpeechByDictionary(Guid dictionaryId, params Expression<Func<PartOfSpeech, object>>[] includeFuncs)
        {
            var dictionary = GetDictionaryById(dictionaryId)
                .ValidateOnNull(dictionaryId.ToString(), "Project", "Code");

            return GetPartsOfSpeechByDictionary(dictionary);
        }

        public IQueryable<PartOfSpeech> GetPartsOfSpeechByDictionary(Lexicon dictionary, params Expression<Func<PartOfSpeech, object>>[] includeFuncs)
        {
            IQueryable<PartOfSpeech> query = _context.PartOfSpeech;

            if (includeFuncs != null && includeFuncs.Length > 0)
            {
                foreach (var inclFunc in includeFuncs)
                {
                    if (inclFunc != null)
                        query = query.Include(inclFunc);
                }
            }

            return query.Where(item => item.Dictionary == dictionary);
        }
        public IQueryable<PartOfSpeech> GetPartsOfSpeechByDictionary(Lexicon dictionary) => GetPartsOfSpeechByDictionary(dictionary, null);

        public IQueryable<Lexicon> DictionariesByProject(Guid projectId)
        {
            var project = _projectService.GetProjectById(projectId)
                .ValidateOnNull(projectId.ToString(), "Project");

            return DictionariesByProject(project);
        }

        public IQueryable<Lexicon> DictionariesByProject(Project project)
        {
            return _context.Dictionary
                .Where(item => item.Project == project);
        }


    }
}
