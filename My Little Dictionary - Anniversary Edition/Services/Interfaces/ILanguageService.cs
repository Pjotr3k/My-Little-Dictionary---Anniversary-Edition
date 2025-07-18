using My_Little_Dictionary___Anniversary_Edition.DTOs;
using My_Little_Dictionary___Anniversary_Edition.Model;

namespace My_Little_Dictionary___Anniversary_Edition.Services.Interfaces
{
    public interface ILanguageService
    {
        Language AddLanguage(LanguageInsertDTO request);
        Language GetLanguageById(Guid id);
        PaginationResult<Language> GetLanguages(PaginationRequest? request);
        void CSVImportLangs();
    }
}
