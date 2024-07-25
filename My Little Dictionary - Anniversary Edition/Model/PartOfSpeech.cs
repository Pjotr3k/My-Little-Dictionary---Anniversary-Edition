using My_Little_Dictionary___Anniversary_Edition.DTOs;

namespace My_Little_Dictionary___Anniversary_Edition.Model
{
    public class PartOfSpeech : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Language Language { get; set; }

        //an array saved as a JSON string containing forms for given part of speech
        public string? Forms { get; set; }
        public PartOfSpeech() : base() { }
    }
}
