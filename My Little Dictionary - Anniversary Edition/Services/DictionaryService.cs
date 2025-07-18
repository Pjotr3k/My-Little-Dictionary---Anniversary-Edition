using My_Little_Dictionary___Anniversary_Edition.Data;
using My_Little_Dictionary___Anniversary_Edition.DTOs;
using My_Little_Dictionary___Anniversary_Edition.Model;
using My_Little_Dictionary___Anniversary_Edition.Services.Base;
using My_Little_Dictionary___Anniversary_Edition.Services.Interfaces;
using My_Little_Dictionary___Anniversary_Edition.Validation;

namespace My_Little_Dictionary___Anniversary_Edition.Services
{
    public class DictionaryService : BaseContextService, IDictionaryService
    {
        private readonly ILinguisticsService _linguisticsService;
        public DictionaryService(ApplicationDBContext context, ILinguisticsService linguisticsService) : base(context)
        {
            _linguisticsService = linguisticsService;
        }

        public Lexeme AddEntry(EntryInsertDTO request)
        {
            request.Validate();

            var dictionary = _linguisticsService.GetDictionaryById(request.DictionaryId)
                .ValidateOnNull(request.DictionaryId, "Dictionary");

            Lexeme entry = new Lexeme()
            {
                Dictionary = dictionary
            };

            List<Word> words = new List<Word>();

            //List<LexemeDefinitionAssociation> definitionAssociations = new List<LexemeDefinitionAssociation>();
            List<string> invalidItems = [];

            foreach (var word in request.WordForms)
            {
                try
                {
                    Form form = _linguisticsService.GetFormById(word.Key)
                        .ValidateOnNull(word.Key, "Form");

                    words.Add(new()
                    {
                        Expression = word.Value,
                        Lexeme = entry,
                        Form = form
                    });
                }
                catch (ValidationException vex)
                {
                    invalidItems.AddRange(vex.Errors);
                    continue;
                }
                catch
                {
                    throw;
                }

            }

            List<Definition> definitions = [];

            foreach (var def in request.Definitions)
            {
                Definition insert = def.ID != null
                    ? _context.Definition.GetById(def.ID.Value).ValidateOnNull(def.ID, "Definition")
                    : new Definition(def.Expression);

                definitions.Add(insert);
            }

            entry.Words = words;
            entry.Definitions = definitions;

            _context.Add(entry);
            _context.SaveChanges();

            return entry;
        }
    }
}
