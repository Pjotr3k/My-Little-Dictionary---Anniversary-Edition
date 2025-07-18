using My_Little_Dictionary___Anniversary_Edition.DTOs;
using My_Little_Dictionary___Anniversary_Edition.Model;

namespace My_Little_Dictionary___Anniversary_Edition.Services.Interfaces
{
    public interface IDictionaryService
    {
        public Lexeme AddEntry(EntryInsertDTO request);
    }
}
