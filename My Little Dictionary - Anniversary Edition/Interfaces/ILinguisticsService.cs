using My_Little_Dictionary___Anniversary_Edition.DTOs;
using My_Little_Dictionary___Anniversary_Edition.Model;

namespace My_Little_Dictionary___Anniversary_Edition.Interfaces
{
    public interface ILinguisticsService
    {
        public ValidationResponse<Language> GetLanguageById(Guid id);
        public ValidationResponse<List<Language>> GetAllLanguages();
        public ValidationResponse<Language> AddLanguage(LanguageInsertDTO request);
        public ValidationResponse<PartOfSpeech> GetPartOfSpeechById(Guid id);
        public ValidationResponse<List<PartOfSpeech>> GetAllPartsOfSpeech();
        public ValidationResponse<List<PartOfSpeech>> GetPartsOfSpeechByLanguageCode(string code);
        public ValidationResponse<PartOfSpeech> AddPartOfSpeech(PartOfSpeechInsertDTO request);
        public ValidationResponse<Form> GetFormById(Guid id);
        public ValidationResponse<List<Form>> GetAllForms();
        public ValidationResponse<List<Form>> GetFormsByPos(Guid posId);
        public ValidationResponse<Form> AddForm(FormInsertDTO request);
        public ValidationResponse<List<Form>> BulkAddForm(List<FormInsertDTO> request);

    }
}
