namespace My_Little_Dictionary___Anniversary_Edition.Model
{
    /// <summary>
    /// Definition is the meaning of the word
    /// - as a separate class in order to easily implement thesaurus and word translations
    /// </summary>
    public class Definition : BaseModel
    {
        public string Expression { get; set; }

        public Definition() : base() { }
        public Definition(string expr)
        {
            Expression = expr;
        }
    }
}
