using My_Little_Dictionary___Anniversary_Edition.Data;
using My_Little_Dictionary___Anniversary_Edition.DTOs;
using My_Little_Dictionary___Anniversary_Edition.Interfaces;
using My_Little_Dictionary___Anniversary_Edition.Model;
using My_Little_Dictionary___Anniversary_Edition.Services.Base;

namespace My_Little_Dictionary___Anniversary_Edition.Services
{
    public class DictionaryService : BaseContextService, IDictionaryService
    {
        public DictionaryService(ApplicationDBContext context) : base(context)
        {

        }
        public ValidationResponse<Dictionary> AddDictionary(DictionaryInsertDTO request)
        {
            ValidationResponse<Dictionary> validation = new ValidationResponse<Dictionary>();

            request.Validate(validation);

            if (validation.Errors.Any())
                return validation;

            Dictionary dictionary = new Dictionary()
            {
                Name = request.Name,
                Description = request.Description
            };

            _context.Add(dictionary);
            _context.SaveChanges();
            validation.Result = dictionary;

            return validation;
        }

        public ValidationResponse<Entry> AddEntry(EntryInsertDTO request)
        {
            ValidationResponse<Entry> validation = new ValidationResponse<Entry>();

            Entry entry = new Entry();

            List<Word> words = new List<Word>();

            List<EntryDefinitionAssociation> definitionAssociations = new List<EntryDefinitionAssociation>();

            foreach (var word in request.WordForms)
            {
                Form form = _context.Form.FirstOrDefault(f => f.ID == word.Key);
                if (form == null)
                {
                    validation.Errors.Add(string.Format("Form with ID {0} does not exist", word.Key.ToString()));
                    continue;
                }
                words.Add(new Word()
                {
                    Expression = word.Value,
                    Entry = entry,
                    Form = form
                });
            }

            foreach (var def in request.Definitions)
            {
                Definition insert = null;
                if (def.ID != null)
                {
                    insert = _context.Definition.FirstOrDefault(d => d.ID == def.ID);
                    if (insert == null)
                    {
                        validation.Errors.Add(string.Format("Form with ID {0} does not exist", def.ID.ToString()));
                        continue;
                    }
                }
                else if (string.IsNullOrEmpty(def.Expression)){
                    insert = new Definition(def.Expression);
                }
                

                definitionAssociations.Add(new EntryDefinitionAssociation(entry, insert));
            }

            if(validation.Errors.Any()) return validation;

            entry.Words = words;
            entry.EntryDefinitions = definitionAssociations;
            validation.Result = entry;

            return validation;
        }

        public ValidationResponse<List<Dictionary>> GetAllDictionaries()
        {
            ValidationResponse<List<Dictionary>> validation = new ValidationResponse<List<Dictionary>>();
            validation.Result = _context.Dictionary.ToList();

            return validation;
        }

        public ValidationResponse<Dictionary> GetDictionaryById(Guid id)
        {
            ValidationResponse<Dictionary> validation = new ValidationResponse<Dictionary>();
            validation.Result = _context.Dictionary.FirstOrDefault(x => x.ID == id);
            if (validation.Result == null)
            {
                validation.Errors.Add("No dictionary with that ID");
            }

            return validation;
        }
    }
}
