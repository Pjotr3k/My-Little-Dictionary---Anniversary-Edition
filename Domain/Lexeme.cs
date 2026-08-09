namespace Domain
{
    /// <summary>
    /// Entry is a representation of full dictionary entry with forms of the words 
    /// and its definition(s)
    /// </summary>
    public class Lexeme : BaseModel
    {
        public Lexicon Dictionary { get; set; }
        public List<Word> Words { get; set; } = [];
        public List<Definition> Definitions { get; set; } = [];
    }
}
