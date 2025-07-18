using Microsoft.IdentityModel.Tokens;

namespace My_Little_Dictionary___Anniversary_Edition.Interfaces
{
    public interface ISearchable
    {
        IComparable OrderDefault { get; }
        bool MatchSearch(string searchValue);
    }
}
