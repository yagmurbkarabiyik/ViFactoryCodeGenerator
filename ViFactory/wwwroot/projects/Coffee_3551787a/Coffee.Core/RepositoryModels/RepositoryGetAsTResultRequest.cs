using System.Linq.Expressions;
using Coffee.Core.Models;

namespace Coffee.Core.RepositoryModels
{
    public class RepositoryGetAsTResultRequest<T, TResult>
        where T : class, IBaseEntity    
    {
        required public Expression<Func<T, TResult>> Projection { get; set; }
        required public Expression<Func<T, bool>> Filter { get; set; }
        public bool IsLast { get; set; }
    }
}