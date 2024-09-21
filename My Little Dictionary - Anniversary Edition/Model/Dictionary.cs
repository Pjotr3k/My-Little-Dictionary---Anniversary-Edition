namespace My_Little_Dictionary___Anniversary_Edition.Model
{
    public class Dictionary : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Lexeme> Lexemes { get; set; } = new List<Lexeme>();

        public Dictionary() : base()
        {
            
        }
    }
}
