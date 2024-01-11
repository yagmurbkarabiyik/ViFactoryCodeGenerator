using Neew.Core.Models;

namespace Neew.Core.Models.RepositoryModels
{
    public class RepositoryUpdateBulkRequest<T> where T : class, IBaseEntity    
    {   
        required public IEnumerable<T> Model { get; set; }
    }
}