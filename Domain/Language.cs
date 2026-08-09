using Domain.Interfaces;

namespace Domain
{
    public class Language : BaseModel, ISearchable
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public IComparable OrderDefault => Code;

        public bool MatchSearch(string searchValue) => 
            Name.ToLower().Contains(searchValue) 
            || Code.ToLower().Contains(searchValue) 
            || Description.ToLower().Contains(searchValue);
    }
}
