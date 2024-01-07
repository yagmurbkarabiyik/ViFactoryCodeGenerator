using IceTea.Core.Models;

namespace IceTea.Core.RepositoryModels
{
    public class RepositoryDeleteRequest<T> where T : class, IBaseEntity
    {
      required public T Model { get; set; }
    }
}