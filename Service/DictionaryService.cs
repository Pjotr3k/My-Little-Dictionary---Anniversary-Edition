using Data;
using Domain;
using Service.Base;
using Service.DTOs;
using Service.Interfaces;
using Service.Validation;

namespace Service
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

            entry.Words = PrepareEntryWords(entry, request.WordForms);
            entry.Definitions = PrepareEntryDefinitions(entry, request.Definitions);

            _context.Add(entry);
            _context.SaveChanges();

            return entry;
        }

        private List<Word> PrepareEntryWords(Lexeme entry, Dictionary<Guid, string> wordForms)
        {
            List<Form> forms = _linguisticsService.GetFormsById(wordForms.Select(w => w.Key).ToList()).ToList();

            return forms.Select(form => new Word()
            {
                Expression = wordForms[form.ID],
                Lexeme = entry,
                Form = form
            }).ToList();
        }

        private List<Definition> PrepareEntryDefinitions(Lexeme entry, List<EntryDefinitionInsertDTO> definitionInserts)
        {
            List<Guid> existingDefsIds = [];
            List<Definition> definitions = [];

            foreach (var item in definitions)
            {
                if (item.ID != null)
                {
                    existingDefsIds.Add(item.ID);
                }
                else
                {
                    definitions.Add(new Definition(item.Expression));
                }
            }

            if(existingDefsIds.Count > 0)
            {
                definitions.AddRange(_context.Definition
                    .GetByIds(existingDefsIds));
            }

            return definitions;
        }

    }
}
