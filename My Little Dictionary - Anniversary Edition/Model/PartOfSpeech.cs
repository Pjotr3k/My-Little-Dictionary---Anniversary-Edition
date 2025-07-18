using My_Little_Dictionary___Anniversary_Edition.DTOs;
using My_Little_Dictionary___Anniversary_Edition.Interfaces;

namespace My_Little_Dictionary___Anniversary_Edition.Model
{
    public class PartOfSpeech : BaseModel, ISearchable
    {
        public int Position { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Lexicon Dictionary { get; set; }
        public List<Form> Forms { get; set; }

        public IComparable OrderDefault => Position;

        public PartOfSpeech() : base() { }

        public bool MatchSearch(string searchValue) => Name.ToLower().Contains(searchValue);
    }
}
