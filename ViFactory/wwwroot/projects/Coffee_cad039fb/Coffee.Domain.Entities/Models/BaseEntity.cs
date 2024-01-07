using Coffee.Core.Enums;
using Coffee.Core.Models;

namespace Coffee.Domain.Models
{
    public class BaseEntity : IBaseEntity
    {
       public int Id { get; set; }
       public DbEntityState Status { get; set; }
       public DateTime CreatedDate { get; set; }
       public DateTime UpdatedDate { get; set; }
    }
}