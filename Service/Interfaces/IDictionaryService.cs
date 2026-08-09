using Domain;
using Service.DTOs;

namespace Service.Interfaces
{
    public interface IDictionaryService
    {
        public Lexeme AddEntry(EntryInsertDTO request);
    }
}
