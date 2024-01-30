
namespace Asdf.Core.Models.RepositoryModels
{
    public class RepositoryUpdateRequest<T> where T : class, IBaseEntity    
    {   
        required public T Model { get; set; }
    }
}