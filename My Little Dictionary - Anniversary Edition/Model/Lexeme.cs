namespace My_Little_Dictionary___Anniversary_Edition.Model
{
    /// <summary>
    /// Entry is a representation of full dictionary entry with forms of the words 
    /// and its definition(s)
    /// </summary>
    public class Lexeme : BaseModel
    {
        public List<Word> Words { get; set; } = new List<Word>();
        public List<LexemeDefinitionAssociation> LexemeDefinitions { get; set; } = new List<LexemeDefinitionAssociation>();
        public List<Definition> Definitions => LexemeDefinitions
            .Select(x => x.Definition)
            .ToList();

        public Lexeme() : base() { }
    }

    public class LexemeDefinitionAssociation : BaseModel
    {
        public Lexeme Entry { get; set; }
        public Definition Definition { get; set; }

        public LexemeDefinitionAssociation() : base() { }

        public LexemeDefinitionAssociation(Lexeme entry, Definition definition) : base()
        {
            Entry = entry;
            Definition = definition;
        }
    }
}
