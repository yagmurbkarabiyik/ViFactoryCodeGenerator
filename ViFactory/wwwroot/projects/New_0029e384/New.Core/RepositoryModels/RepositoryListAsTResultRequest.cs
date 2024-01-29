using System.Linq.Expressions;

namespace New.Core.Models.RepositoryModels
{
   public class RepositoryListAsTResultRequest<T, TResult> where T : class, IBaseEntity where TResult : class
    {
        required public Expression<Func<T, TResult>> Projection { get; set; }
        public Expression<Func<T, bool>>? Filter { get; set; }
        public Func<IQueryable<T>, IOrderedQueryable<T>>? OrderBy { get; set; }
        public int Skip { get; set; } = 0;
        public int Take { get; set; } = 10;
    }
}