namespace Service.DTOs
{
    public class PaginationRequest
    {
        public int PageSize { get; set; } = 20;
        public int PageNumber { get; set; } = 1;
        public string? SearchPhrase { get; set; } = null;
        public PaginationRequest() { }
    }
}
