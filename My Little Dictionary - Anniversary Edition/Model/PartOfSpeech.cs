using My_Little_Dictionary___Anniversary_Edition.DTOs;
using My_Little_Dictionary___Anniversary_Edition.Interfaces;

namespace My_Little_Dictionary___Anniversary_Edition.Model
{
    public class PartOfSpeech : BaseModel, ISearchable
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Project Project { get; set; }
        public List<Form> Forms { get; set; }
        public PartOfSpeech() : base() { }

        public bool MatchSearch(string searchValue) => Name.ToLower().Contains(searchValue);
    }
}
