namespace Mst.Core.Models
{
    public class PaginationResponse<T>
    {
        public IQueryable<T>? Items { get; set; }
        public long Total { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
        public int TotalPages
        {
            get { return (int)Math.Ceiling(Total / (double)Size); }
        }
    }
}