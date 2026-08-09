namespace Domain
{
    public class Lexicon : BaseModel
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public Project Project { get; set; }
        public Language Language { get; set; }
        public List<Lexeme> Lexemes { get; set; } = new List<Lexeme>();

        public Lexicon() : base()
        {
            
        }
    }
}
