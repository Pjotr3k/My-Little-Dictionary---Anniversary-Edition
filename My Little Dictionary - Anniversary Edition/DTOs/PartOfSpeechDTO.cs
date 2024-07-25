using My_Little_Dictionary___Anniversary_Edition.Model;

namespace My_Little_Dictionary___Anniversary_Edition.DTOs
{
    public class PartOfSpeechDTO
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public Guid? Language { get; set; }

        public PartOfSpeechDTO() { }
        public PartOfSpeechDTO(PartOfSpeech model)
        {
            ID = model.ID;
            Name = model.Name;
            Description = model.Description;
            Language = model.Language?.ID;
        }
    }

    public class PartOfSpeechInsertDTO
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public Guid Language { get; set; }
    }
}
