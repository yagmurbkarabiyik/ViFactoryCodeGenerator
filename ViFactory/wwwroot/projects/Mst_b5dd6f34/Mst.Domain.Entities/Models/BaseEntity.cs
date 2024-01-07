using Mst.Core.Enums;
using Mst.Core.Models;

namespace Mst.Domain.Models
{
    public class BaseEntity : IBaseEntity
    {
       public int Id { get; set; }
       public DbEntityState Status { get; set; }
       public DateTime CreatedDate { get; set; }
       public DateTime UpdatedDate { get; set; }
    }
}