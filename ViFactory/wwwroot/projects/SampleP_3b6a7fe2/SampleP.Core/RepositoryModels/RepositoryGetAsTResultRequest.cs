using System.Linq.Expressions;
using SampleP.Core.Models;

namespace SampleP.Core.RepositoryModels
{
    public class RepositoryGetAsTResultRequest<T, TResult>
        where T : class, IBaseEntity    
    {
        required public Expression<Func<T, TResult>> Projection { get; set; }
        required public Expression<Func<T, bool>> Filter { get; set; }
        public bool IsLast { get; set; }
    }
}