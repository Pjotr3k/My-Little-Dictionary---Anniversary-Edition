namespace My_Little_Dictionary___Anniversary_Edition.Model
{
    /// <summary>
    /// Entry is a representation of full dictionary entry with forms of the words 
    /// and its definition(s)
    /// </summary>
    public class Entry : BaseModel
    {
        public List<Word> Words { get; set; } = new List<Word>();
        public List<EntryDefinitionAssociation> EntryDefinitions { get; set; } = new List<EntryDefinitionAssociation>();
        public List<Definition> Definitions => EntryDefinitions.Select(x => x.Definition).ToList();

        public Entry() : base()
        {
            
        }
    }

    public class EntryDefinitionAssociation : BaseModel
    {
        public Entry Entry { get; set; }
        public Definition Definition { get; set; }

        public EntryDefinitionAssociation() : base()
        {

        }

        public EntryDefinitionAssociation(Entry entry, Definition definition) : base()
        {
            Entry = entry;
            Definition = definition;
        }
    }
}
