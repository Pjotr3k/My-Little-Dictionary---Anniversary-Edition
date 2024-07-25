
using My_Little_Dictionary___Anniversary_Edition.DTOs;
using My_Little_Dictionary___Anniversary_Edition.Model;


namespace My_Little_Dictionary___Anniversary_Edition.Interfaces
{
    public interface IDictionaryService
    {
        public ValidationResponse<Dictionary> GetDictionaryById(Guid id);
        public ValidationResponse<List<Dictionary>> GetAllDictionaries();
        public ValidationResponse<Dictionary> AddDictionary(DictionaryInsertDTO request);
        public ValidationResponse<Entry> AddEntry(EntryInsertDTO request);
    }
}
