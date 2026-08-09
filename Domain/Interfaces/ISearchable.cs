namespace Domain.Interfaces
{
    public interface ISearchable
    {
        IComparable OrderDefault { get; }
        bool MatchSearch(string searchValue);
    }
}
