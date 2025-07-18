using My_Little_Dictionary___Anniversary_Edition.Data;
using My_Little_Dictionary___Anniversary_Edition.DTOs;
using My_Little_Dictionary___Anniversary_Edition.Model;
using My_Little_Dictionary___Anniversary_Edition.Services.Base;
using My_Little_Dictionary___Anniversary_Edition.Services.Interfaces;

namespace My_Little_Dictionary___Anniversary_Edition.Services
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
            string csvContent = File.ReadAllText("C:\\Users\\User\\OneDrive\\Pulpit\\lang.csv");
            var languages = new List<Language>();

            using (var reader = new StringReader(csvContent))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    var fields = line.Split(',');

                    if (fields.Length >= 3)
                    {
                        var language = new Language
                        {
                            Code = fields[0].Trim('\"'),  // "alpha3-b" => Code
                            Name = fields[2].Trim('\"'),  // "English" => Name
                            Description = string.Empty    // Description left as empty string
                        };

                        languages.Add(language);
                    }
                }
            }

            foreach (var language in languages)
            {
                _context.Add(language);
            }
            _context.SaveChanges();
        }


        public Language GetLanguageById(Guid id)
            => _context.Language.GetById(id);

        public PaginationResult<Language> GetLanguages(PaginationRequest? request)
            => new(_context.Language, request);

    }
}
