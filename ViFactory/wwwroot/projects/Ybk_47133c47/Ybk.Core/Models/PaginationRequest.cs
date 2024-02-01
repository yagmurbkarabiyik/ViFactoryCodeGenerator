namespace Ybk.Core.Models
{
    public class PaginationRequest
    {
        public int Page { get; set; } = 1;
        public int Size { get; set; } = 10;
        public string OrderBy { get; set; } = "Id";
        public bool IsDesc { get; set; } = true;
    }
}