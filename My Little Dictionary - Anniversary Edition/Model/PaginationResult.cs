using My_Little_Dictionary___Anniversary_Edition.DTOs;
using My_Little_Dictionary___Anniversary_Edition.Helpers;
using My_Little_Dictionary___Anniversary_Edition.Interfaces;

namespace My_Little_Dictionary___Anniversary_Edition.Model
{
    public class PaginationResult<TData>// : ValidationResponse<List<T>>
    {
        public PaginationRequest Request { get; set; }
        public int TotalCount { get; set; }
        public List<TData> Data { get; set; }
        public int TotalPages
        {
            get
            {
                return (int)Math.Ceiling((double)TotalCount / Request.PageSize);
            }
        }

        public bool Overlimit => TotalCount < Request.PageSize * Request.PageNumber;
        public PaginationResult(IEnumerable<TData> source, PaginationRequest? pagination) : this(pagination)
        {
            IEnumerable<TData> result = source;
            if (result is IEnumerable<ISearchable> searchable)
            {
                result = searchable
                    .Filter(Request.SearchPhrase)
                    .OrderBy(item => item.OrderDefault)
                    .Cast<TData>(); ;
            }

            Data = result
                .Paginate(Request, out int total)
                .ToList();

            TotalCount = total;
        }

        public PaginationResult(PaginationRequest? pagination)
        {
            Request = pagination ?? new PaginationRequest();
        }

        public PaginationResult<TResult> Select<TResult>(Func<TData, TResult> selector)
        {
            PaginationResult<TResult> result = new PaginationResult<TResult>(Request);
            result.TotalCount = TotalCount;
            result.Data = Data.Select(selector).ToList();
            
            return result;
        }
    }
}
