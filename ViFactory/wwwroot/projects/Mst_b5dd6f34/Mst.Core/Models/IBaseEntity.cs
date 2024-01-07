using Mst.Core.Enums;

namespace Mst.Core.Models
{
    public interface IBaseEntity
    {
       public int Id { get; set; }
       public DbEntityState Status { get; set; }
       public DateTime CreatedDate { get; set; }
       public DateTime UpdatedDate { get; set; }
    }
}