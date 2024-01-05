using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Deneme.Core.Models.RepositoryModels
{
    public class RepositoryGetRequest<T> where T : class, IBaseEntity
    {
        required public Expression<Func<T, bool>> Filter { get; set; }
        required public bool AsNoTracking { get; set; }
        public Func<IQueryable<T>, IIncludableQueryable<T, object>>? Include { get; set; }
    }
}