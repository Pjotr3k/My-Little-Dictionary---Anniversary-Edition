using My_Little_Dictionary___Anniversary_Edition.DTOs;
using My_Little_Dictionary___Anniversary_Edition.Model;

namespace My_Little_Dictionary___Anniversary_Edition.Mappers
{
    public static class ValidationMapper
    {
        public static LanguageDTO ToDTO(this Language model) => new LanguageDTO(model);
        public static ProjectDTO ToDTO(this Project model) => new ProjectDTO(model);
        public static LexiconDTO ToDTO(this Lexicon model)
        {
            return new LexiconDTO
            {
                ID = model.ID,
                Data = new LexiconDataDTO(model.Name, model.Description, model.Code),
                Project = model.Project.ToDTO()
            };
        }
        public static PartOfSpeechDTO ToDTO(this PartOfSpeech model) => new PartOfSpeechDTO(model);
        public static FormDTO ToDTO(this Form model) => new FormDTO(model);
        public static LexiconDataDTO ToDataDTO(this Lexicon model) => new LexiconDataDTO(model.Name, model.Description, model.Code);

    }
}
