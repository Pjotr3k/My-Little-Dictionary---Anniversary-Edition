using Service.DTOs;
using Service.Base;
using Service.Interfaces;
using Domain;
using Data;

namespace Service
{
    public class LanguageService : BaseContextService, ILanguageService
    {
        public LanguageService(ApplicationDBContext context) : base(context)
        {

        }

        public Language AddLanguage(LanguageInsertDTO request)
        {
            Language language = new Language();

            request.GetData(language);

            _context.Add(language);
            _context.SaveChanges();

            return language;
        }

        public void CSVImportLangs()
        {
            string csvContent = File.ReadAllText("");
            var languages = new List<Language>();

            using (var reader = new StringReader(csvContent))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    var fields = line.Split(';');

                    if (fields.Length >= 4)
                    {
                        var language = new Language
                        {
                            Code = fields[4].Trim('\"'),  // "alpha3-b" => Code
                            Name = string.Join(", ", fields[1].Trim('\"'), fields[2].Trim('\"')),  // "English" => Name
                            Description = fields[0].Trim('\"')    // Description left as empty string
                        };

                        languages.Add(language);
                    }
                }
            }
            
            _context.AddRange(languages);
            _context.SaveChanges();
        }


        public Language GetLanguageById(Guid id)
            => _context.Language.GetById(id);

        public IQueryable<Language> GetLanguages()
            => _context.Language;
    }
}
