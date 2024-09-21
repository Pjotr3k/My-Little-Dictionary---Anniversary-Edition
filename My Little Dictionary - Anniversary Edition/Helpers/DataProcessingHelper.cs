using My_Little_Dictionary___Anniversary_Edition.DTOs;
using My_Little_Dictionary___Anniversary_Edition.Interfaces;

namespace My_Little_Dictionary___Anniversary_Edition.Helpers
{

    public static class DataProcessingHelper
    {
        public static IEnumerable<TSource> Filter<TSource>(this IEnumerable<TSource> source, string? searchPhrase) where TSource : ISearchable
        {
            if (string.IsNullOrEmpty(searchPhrase))
                return source;

            return source.Where(x => ((ISearchable)x).MatchSearch(searchPhrase.ToLower()));
        }

        public static IEnumerable<TSource> Paginate<TSource>(this IEnumerable<TSource> source, PaginationRequestDTO request, out int total)
        {
            return source.Paginate(request.PageNumber, request.PageSize, out total);
        }

        public static IEnumerable<TSource> Paginate<TSource>(this IEnumerable<TSource> source, int pageNumber, int pageSize, out int total)
        {
            total = source.Count();
            IEnumerable<TSource> result = source;

            int skipItems = (pageNumber - 1) * pageSize;

            return result
                .Skip(skipItems)
                .Take(pageSize);
        }
    }
}
