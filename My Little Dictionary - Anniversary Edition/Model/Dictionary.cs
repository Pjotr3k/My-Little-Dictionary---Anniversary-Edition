namespace My_Little_Dictionary___Anniversary_Edition.Model
{
    public class Dictionary : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Entry> Entries { get; set; } = new List<Entry>();

        public Dictionary() : base()
        {
            
        }
    }
}
