using Domain.Interfaces;

namespace Domain.Helpers
{
    public static class SearchableHelper
    {
        public static IEnumerable<TSource> Filter<TSource>(this IEnumerable<TSource> source, string? searchPhrase) where TSource : ISearchable
        {
            if (string.IsNullOrEmpty(searchPhrase))
                return source;

            return source.Where(x => ((ISearchable)x).MatchSearch(searchPhrase.ToLower()));
        }

        public static bool MatchAnyContaining(this string searchValue, params string[] values)
            => !string.IsNullOrEmpty(searchValue)
            && values.Any(val => val.Contains(searchValue, StringComparison.CurrentCultureIgnoreCase));
    }
}
