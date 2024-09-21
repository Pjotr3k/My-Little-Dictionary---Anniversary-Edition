using My_Little_Dictionary___Anniversary_Edition.Interfaces;

namespace My_Little_Dictionary___Anniversary_Edition.Model
{
    public class Project : BaseModel, ISearchable
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public Language Language { get; set; }

        public Project() { }
        public Project(string name, string code, string desc = "", Language language = null) : base()
        {
            Name = name;
            Code = code;
            Description = desc;
            Language = language;
        }

        public bool MatchSearch(string searchValue) =>
                    Name.ToLower().Contains(searchValue)
                    || Code.ToLower().Contains(searchValue)
                    || Description.ToLower().Contains(searchValue);
    }
}
