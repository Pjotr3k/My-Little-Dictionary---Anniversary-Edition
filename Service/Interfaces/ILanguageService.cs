using Domain;
using Service.DTOs;

namespace Service.Interfaces
{
    public interface ILanguageService
    {
        Language AddLanguage(LanguageInsertDTO request);
        Language GetLanguageById(Guid id);
        IQueryable<Language> GetLanguages();
        void CSVImportLangs();
    }
} 
