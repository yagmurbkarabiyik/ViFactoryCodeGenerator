using System.Linq.Expressions;

namespace IceTea.Core.Models.RepositoryModels
{
    public class RepositoryIsExistRequest<T> where T : class, IBaseEntity   
    {
       required public Expression<Func<T, bool>> Filter { get; set; }
    }
}