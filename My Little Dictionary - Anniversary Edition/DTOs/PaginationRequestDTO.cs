using My_Little_Dictionary___Anniversary_Edition.Interfaces;
using System.Collections.Generic;

namespace My_Little_Dictionary___Anniversary_Edition.DTOs
{
    public class PaginationRequestDTO
    {
        public int PageSize { get; set; } = 20;
        public int PageNumber { get; set; } = 1;
        public string? SearchPhrase { get; set; } = null;
        public PaginationRequestDTO() { }
    }
}
