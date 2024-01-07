using Mst.Core.Models;

namespace Mst.Core.RepositoryModels
{
    public class RepositoryDeleteRequest<T> where T : class, IBaseEntity
    {
      required public T Model { get; set; }
    }
}