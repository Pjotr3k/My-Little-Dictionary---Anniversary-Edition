namespace My_Little_Dictionary___Anniversary_Edition.Model
{
    public class Form : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsLemma { get; set; }
        public PartOfSpeech PartOfSpeech { get; set; }

        public Form() : base()
        {
            
        }
    }
}
