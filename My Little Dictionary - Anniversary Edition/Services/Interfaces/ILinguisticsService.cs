using My_Little_Dictionary___Anniversary_Edition.DTOs;
using My_Little_Dictionary___Anniversary_Edition.Model;

namespace My_Little_Dictionary___Anniversary_Edition.Services.Interfaces
{
    public interface ILinguisticsService
    {
        Lexicon AddDictionary(LexiconInsertDTO request);
        Lexicon AddDictionary(LexiconDataDTO request, Project project, Language language);
        PartOfSpeech AddPartOfSpeech(PartOfSpeechInsertDTO request);
        PaginationResult<PartOfSpeech> GetPartsOfSpeechByLanguage(PaginationRequest? request, Guid projectID);
        PartOfSpeech GetPartOfSpeechByName(string posName, Guid dictionaryId);
        Form GetFormById(Guid id);
        Lexicon GetDictionaryById(Guid id);
        PaginationResult<PartOfSpeech> GetPartsOfSpeechByDictionary(PaginationRequest? request, Guid dictionaryId);
        PaginationResult<PartOfSpeech> GetPartsOfSpeechByDictionary(PaginationRequest? request, Lexicon dictionary);
        PartOfSpeech GetPartOfSpeechById(Guid id);
        List<Form> GetFormsByPos(Guid posId);
    }
}
