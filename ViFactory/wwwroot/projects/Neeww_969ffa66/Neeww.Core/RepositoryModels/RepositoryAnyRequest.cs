using Neeww.Core.Models;
using System.Linq.Expressions;


namespace Neeww.Core.Models.RepositoryModels
{
    public class RepositoryAnyRequest<T> where T : class, IBaseEntity   
    {
       required public Expression<Func<T, bool>> Filter { get; set; }
    }
}