using Asdf.Core.Models;

namespace Asdf.Core.Models.RepositoryModels
{
    public class RepositoryUpdateBulkRequest<T> where T : class, IBaseEntity    
    {   
        required public IEnumerable<T> Model { get; set; }
    }
}