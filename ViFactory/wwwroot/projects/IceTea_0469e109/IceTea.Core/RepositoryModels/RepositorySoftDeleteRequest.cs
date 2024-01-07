using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace IceTea.Core.Models.RepositoryModels
{
    public class RepositorySoftDeleteRequest<T> where T : class, IBaseEntity
    {
       required public T Model { get; set; }
    }
}