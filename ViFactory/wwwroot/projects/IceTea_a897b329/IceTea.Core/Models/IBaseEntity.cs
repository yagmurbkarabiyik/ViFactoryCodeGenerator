using IceTea.Core.Enums;

namespace IceTea.Core.Models
{
    public interface IBaseEntity
    {
       public int Id { get; set; }
       public DbEntityState DbState { get; set; }
       public DateTimeOffset CreatedDate { get; set; }
       public DateTimeOffset? UpdatedDate { get; set; }
    }
}