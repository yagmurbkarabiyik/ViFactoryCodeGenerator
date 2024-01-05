using System.Linq.Expressions;
using ExtensionsDeneme.Core.Models;

namespace ExtensionsDeneme.Core.RepositoryModels
{
    public class RepositoryGetAsTResultRequest<T, TResult>
        where T : class, IBaseEntity    
    {
        required public Expression<Func<T, TResult>> Projection { get; set; }
        required public Expression<Func<T, bool>> Filter { get; set; }
    }
}