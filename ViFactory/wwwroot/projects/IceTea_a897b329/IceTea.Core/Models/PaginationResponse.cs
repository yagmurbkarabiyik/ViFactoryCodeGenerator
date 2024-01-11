namespace IceTea.Core.Models
{
    public class PaginationResponse<T>
    {
        public IQueryable<T>? Items { get; set; }
        public long Total { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }

        public bool HasPrevious
        {
            get { return Page > 1; }
        }

        public bool HasNext
        {
            get { return Page < TotalPages; }
        }

        public int From
        {
            get { return (Page - 1) * Size + 1; }
        }

        public int TotalPages
        {
            get { return (int)Math.Ceiling(Total / (double)Size); }
        }
    }
}