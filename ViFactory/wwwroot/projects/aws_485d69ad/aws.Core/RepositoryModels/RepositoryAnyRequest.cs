using aws.Core.Models;
using System.Linq.Expressions;


namespace aws.Core.Models.RepositoryModels
{
    public class RepositoryAnyRequest<T> where T : class, IBaseEntity   
    {
       required public Expression<Func<T, bool>> Filter { get; set; }
    }
}