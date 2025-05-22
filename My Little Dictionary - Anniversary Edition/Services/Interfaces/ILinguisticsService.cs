using My_Little_Dictionary___Anniversary_Edition.DTOs;
using My_Little_Dictionary___Anniversary_Edition.Model;

namespace My_Little_Dictionary___Anniversary_Edition.Services.Interfaces
{
    public interface ILinguisticsService
    {
        ValidationResponse<Language> GetLanguageById(Guid id);
        PaginationResponse<LanguageDTO> GetLanguages(PaginationRequestDTO? request);
        PaginationResponse<ProjectDTO> GetProjects(PaginationRequestDTO? request = null);
        ValidationResponse<Project> AddProject(ProjectInsertDTO request);
        ValidationResponse<Language> AddLanguage(LanguageInsertDTO request);
        ValidationResponse<PartOfSpeech> GetPartOfSpeechById(Guid id);
        ValidationResponse<PartOfSpeech> GetPartOfSpeechByName(string posName, string projectCode);
        PaginationResponse<PartOfSpeech> GetPartsOfSpeechByProject(PaginationRequestDTO? request, Project project);
        PaginationResponse<PartOfSpeech> GetPartsOfSpeechByProject(PaginationRequestDTO? request, string projectCode);
        ValidationResponse<Project> GetProjectById(Guid id);
        ValidationResponse<Project> GetProjectByCode(string code);
        ValidationResponse<PartOfSpeech> AddPartOfSpeech(PartOfSpeechInsertDTO request);
        ValidationResponse<Form> GetFormById(Guid id);
        ValidationResponse<List<Form>> GetAllForms();
        ValidationResponse<List<Form>> GetFormsByPos(Guid posId);
        //ValidationResponse<Form> AddForm(FormInsertDTO request, PartOfSpeech pos);
        //ValidationResponse<List<Form>> BulkAddForm(List<FormInsertDTO> request);
        void CSVImportLangs();


    }
}
