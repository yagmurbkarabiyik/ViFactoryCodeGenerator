using aws.Core.Models;

namespace aws.Core.RepositoryModels
{
    public class RepositoryDeleteRequest<T> where T : class, IBaseEntity
    {
      required public T Model { get; set; }
    }
}