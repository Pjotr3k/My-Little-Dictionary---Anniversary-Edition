namespace My_Little_Dictionary___Anniversary_Edition.Model
{
    public class Language : BaseModel
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public Language()
        {
            
        }
        public Language(string name, string code, string desc = "") : base()
        {
            Name = name;
            Code = code;
            Description = desc;
        }
    }
}
