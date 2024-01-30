using dddd.Core.Models;

namespace dddd.Core.Models.RepositoryModels
{
    public class RepositoryUpdateBulkRequest<T> where T : class, IBaseEntity    
    {   
        required public IEnumerable<T> Model { get; set; }
    }
}