using Microsoft.IdentityModel.Tokens;
using My_Little_Dictionary___Anniversary_Edition.DTOs;
using My_Little_Dictionary___Anniversary_Edition.Interfaces;
using My_Little_Dictionary___Anniversary_Edition.Model;

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

        public static IEnumerable<TSource> Paginate<TSource>(this IEnumerable<TSource> source, PaginationRequest request, out int total)
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

        public static PaginationResult<TData> ToPaginationResult<TData>(this IEnumerable<TData> source, PaginationRequest request)
            => new PaginationResult<TData>(source, request);

        public static PaginationResult<TResult> ToPaginationResult<TSource, TResult>(this IEnumerable<TSource> source, PaginationRequest request, Func<TSource, TResult> selector)
            => source.ToPaginationResult(request).Select(selector.Invoke);


        public static bool MatchAnyContaining(this string searchValue, params string[] values)
            => !string.IsNullOrEmpty(searchValue)
            && values.Any(val => val.Contains(searchValue, StringComparison.CurrentCultureIgnoreCase));
    }
}
