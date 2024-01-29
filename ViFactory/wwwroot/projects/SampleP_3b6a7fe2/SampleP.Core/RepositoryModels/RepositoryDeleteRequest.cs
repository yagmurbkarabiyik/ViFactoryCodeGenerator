using SampleP.Core.Models;

namespace SampleP.Core.RepositoryModels
{
    public class RepositoryDeleteRequest<T> where T : class, IBaseEntity
    {
      required public T Model { get; set; }
    }
}