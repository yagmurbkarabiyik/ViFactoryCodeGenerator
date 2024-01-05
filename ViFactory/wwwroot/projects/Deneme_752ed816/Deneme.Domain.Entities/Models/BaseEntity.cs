using Deneme.Core.Enums;
using Deneme.Core.Models;

namespace Deneme.Domain.Models
{
    public class BaseEntity : IBaseEntity
    {
       public int Id { get; set; }
       public DbEntityState Status { get; set; }
       public DateTime CreatedDate { get; set; }
       public DateTime UpdatedDate { get; set; }
    }
}