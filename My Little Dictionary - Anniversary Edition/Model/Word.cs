namespace My_Little_Dictionary___Anniversary_Edition.Model
{
    /// <summary>
    /// Word is a reporesentation of a word declined/conjugated by particular form
    /// eg. English "told" being past tense form of "tell"
    /// or Polish "doktorze" being vocative case of the word "doktor" in singular
    /// </summary>
    public class Word : BaseModel
    {
        public string Expression { get; set; }
        public Form Form { get; set; }
        public Lexeme Lexeme { get; set; }

        public Word() : base()
        {
            
        }
    }
}
