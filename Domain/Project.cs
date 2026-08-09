using Domain.Interfaces;

namespace Domain
{
    public class Project : BaseModel, ISearchable
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public List<Lexicon> Dictionaries { get; set; }

        public IComparable OrderDefault => Name;

        public Project() { }
        public Project(string name, string code, string desc = "") : base()
        {
            Name = name;
            Code = code;
            Description = desc;
            Dictionaries = [];
        }

        public bool MatchSearch(string searchValue) =>
                    Name.ToLower().Contains(searchValue)
                    || Code.ToLower().Contains(searchValue)
                    || Description.ToLower().Contains(searchValue);
    }
}
