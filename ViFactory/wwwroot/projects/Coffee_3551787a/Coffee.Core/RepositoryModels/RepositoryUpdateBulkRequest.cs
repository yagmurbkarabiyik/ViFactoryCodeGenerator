using Coffee.Core.Models;

namespace Coffee.Core.Models.RepositoryModels
{
    public class RepositoryUpdateBulkRequest<T> where T : class, IBaseEntity    
    {   
        required public IEnumerable<T> Model { get; set; }
    }
}