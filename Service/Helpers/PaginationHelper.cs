using Service.DTOs;

namespace Service.Helpers
{
    public static class PaginationHelper
    {
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
    }
}
