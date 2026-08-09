using Domain.Helpers;
using Domain.Interfaces;

namespace Domain
{
    /// <summary>
    /// Definition is the meaning of the word
    /// - as a separate class in order to easily implement thesaurus and word translations
    /// </summary>
    public class Definition : BaseModel, ISearchable
    {
        public string Expression { get; set; }

        public IComparable OrderDefault => Expression;

        public Definition() : base() { }
        public Definition(string expr)
        {
            Expression = expr;
        }

        public bool MatchSearch(string searchValue) => searchValue.MatchAnyContaining(Expression);
    }
}
