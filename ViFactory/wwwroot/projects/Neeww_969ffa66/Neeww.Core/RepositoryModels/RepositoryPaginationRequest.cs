using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Neeww.Core.Models.RepositoryModels
{
    public class RepositoryPaginationRequest<T> where T : class, IBaseEntity
    {
        public Expression<Func<T, bool>>? Filter { get; set; } = null;
        public Func<IQueryable<T>, IIncludableQueryable<T, object>>? Include { get; set; } = null;
        public Func<IQueryable<T>, IOrderedQueryable<T>>? OrderBy { get; set; } = null;
        public int Page { get; set; } = 1;
        public int Size { get; set; } = 10;
    }
}