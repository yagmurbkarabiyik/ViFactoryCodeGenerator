using Tea.Core.Models;

namespace Tea.Core.RepositoryModels
{
    public class RepositoryDeleteRequest<T> where T : class, IBaseEntity
    {
      required public T Model { get; set; }
    }
}