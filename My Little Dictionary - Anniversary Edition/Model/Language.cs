using My_Little_Dictionary___Anniversary_Edition.Interfaces;

namespace My_Little_Dictionary___Anniversary_Edition.Model
{
    public class Language : BaseModel, ISearchable
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public bool MatchSearch(string searchValue) => 
            Name.ToLower().Contains(searchValue) 
            || Code.ToLower().Contains(searchValue) 
            || Description.ToLower().Contains(searchValue);
    }
}
