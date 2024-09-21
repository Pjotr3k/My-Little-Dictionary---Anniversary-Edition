using Azure.Core;
using My_Little_Dictionary___Anniversary_Edition.DTOs;
using My_Little_Dictionary___Anniversary_Edition.Helpers;

namespace My_Little_Dictionary___Anniversary_Edition.Model
{
    public class PaginationResponse<T> : ValidationResponse<List<T>>
    {
        public PaginationRequestDTO Request { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages
        {
            get
            {
                return (int)Math.Ceiling((double)TotalCount / Request.PageSize);
            }
        }

        public bool Overlimit => TotalCount < Request.PageSize * Request.PageNumber;

        public PaginationResponse(PaginationRequestDTO? pagination) : base()
        {
            Request = pagination ?? new PaginationRequestDTO();
        }

        public void Paginate(List<T> source)
        {
            Result = source
                .Paginate(Request, out int totalCount)
                .ToList();

            TotalCount = totalCount;
        }

        public void Paginate<TSource>(List<TSource> source, Func<TSource, T> selector)
        {
            Result = source
                .Paginate(Request, out int totalCount)
                .Select(selector)
                .ToList();

            TotalCount = totalCount;
        }

        public PaginationResponse<TResult> Select<TResult>(Func<T, TResult> selector)
        {
            PaginationResponse<TResult> result = new PaginationResponse<TResult>(Request);
            result.TotalCount = TotalCount;
            result.Result = Result?.Select(selector).ToList();
            
            return result;
        }
    }
}
