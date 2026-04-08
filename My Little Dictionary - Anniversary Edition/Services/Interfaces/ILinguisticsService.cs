using My_Little_Dictionary___Anniversary_Edition.DTOs;
using My_Little_Dictionary___Anniversary_Edition.Model;
using System.Linq.Expressions;

namespace My_Little_Dictionary___Anniversary_Edition.Services.Interfaces
{
    public interface ILinguisticsService
    {
        Lexicon AddDictionary(LexiconInsertDTO request);
        Lexicon AddDictionary(LexiconDataDTO request, Project project, Language language);
        PartOfSpeech AddPartOfSpeech(PartOfSpeechInsertDTO request);
        IQueryable<PartOfSpeech> GetPartsOfSpeechByLanguage(Guid projectID);
        PartOfSpeech GetPartOfSpeechByName(string posName, Guid dictionaryId);
        Form GetFormById(Guid id, params Expression<Func<Form, object>>[] includeFuncs);
        Lexicon GetDictionaryById(Guid id, params Expression<Func<Lexicon, object>>[] includeFuncs);
        IQueryable<PartOfSpeech> GetPartsOfSpeechByDictionary(Guid dictionaryId, params Expression<Func<PartOfSpeech, object>>[] includeFuncs);
        IQueryable<PartOfSpeech> GetPartsOfSpeechByDictionary(Lexicon dictionary);
        PartOfSpeech GetPartOfSpeechById(Guid id, params Expression<Func<PartOfSpeech, object>>[] includeFuncs);
        IQueryable<Form> GetFormsByPos(Guid posId);
        IQueryable<Lexicon> DictionariesByProject(Guid projectId);
        IQueryable<Lexicon> DictionariesByProject(Project project);
    }
}
