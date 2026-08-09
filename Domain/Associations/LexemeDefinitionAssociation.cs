using Domain;
using Domain.Interfaces;

namespace Domain.Associations
{
    public class LexemeDefinitionAssociation : BaseModel, ISearchable
    {
        public int OrderNo { get; set; }
        public Lexeme Entry { get; set; }
        public Definition Definition { get; set; }

        public IComparable OrderDefault => OrderNo;

        public LexemeDefinitionAssociation() : base() { }

        public LexemeDefinitionAssociation(Lexeme entry, Definition definition) : base()
        {
            Entry = entry;
            Definition = definition;
        }

        public bool MatchSearch(string searchValue) => Definition.MatchSearch(searchValue);
    }
}

