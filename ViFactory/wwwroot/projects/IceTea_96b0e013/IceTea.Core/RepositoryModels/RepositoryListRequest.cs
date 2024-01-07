using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace IceTea.Core.Models.RepositoryModels
{
    public class RepositoryListRequest<T>
    {
        public Expression<Func<T, bool>>? Filter { get; set; }
        public Func<IQueryable<T>, IIncludableQueryable<T, object>>? Include { get; set; }
        public Func<IQueryable<T>, IOrderedQueryable<T>>? OrderBy { get; set; }
        public bool AsNoTracking { get; set; } = true;
        public int Skip { get; set; } = 0;
        public int Take { get; set; } = 10;
    }
}