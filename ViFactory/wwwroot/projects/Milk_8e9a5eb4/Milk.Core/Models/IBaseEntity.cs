using Milk.Core.Enums;

namespace Milk.Core.Models
{
    public interface IBaseEntity
    {
       public int Id { get; set; }
       public DbEntityState Status { get; set; }
       public DateTime CreatedDate { get; set; }
       public DateTime UpdatedDate { get; set; }
    }
}