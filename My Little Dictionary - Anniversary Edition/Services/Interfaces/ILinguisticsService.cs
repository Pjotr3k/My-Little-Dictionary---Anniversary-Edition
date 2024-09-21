using My_Little_Dictionary___Anniversary_Edition.DTOs;
using My_Little_Dictionary___Anniversary_Edition.Model;

namespace My_Little_Dictionary___Anniversary_Edition.Services.Interfaces
{
    public interface ILinguisticsService
    {
        public ValidationResponse<Language> GetLanguageById(Guid id);
        public PaginationResponse<LanguageDTO> GetLanguages(PaginationRequestDTO? request);
        public PaginationResponse<ProjectDTO> GetProjects(PaginationRequestDTO? request = null);
        public ValidationResponse<Project> AddProject(ProjectInsertDTO request);
        public ValidationResponse<Language> AddLanguage(LanguageInsertDTO request);
        public ValidationResponse<PartOfSpeech> GetPartOfSpeechById(Guid id);
        public PaginationResponse<PartOfSpeech> GetPartsOfSpeechByProject(PaginationRequestDTO? request, Project project);
        public ValidationResponse<Project> GetProjectById(Guid id);
        public ValidationResponse<Project> GetProjectByCode(string code);
        public ValidationResponse<PartOfSpeech> AddPartOfSpeech(PartOfSpeechInsertDTO request);
        public ValidationResponse<Form> GetFormById(Guid id);
        public ValidationResponse<List<Form>> GetAllForms();
        public ValidationResponse<List<Form>> GetFormsByPos(Guid posId);
        //public ValidationResponse<Form> AddForm(FormInsertDTO request, PartOfSpeech pos);
        //public ValidationResponse<List<Form>> BulkAddForm(List<FormInsertDTO> request);
        public void CSVImportLangs();


    }
}
