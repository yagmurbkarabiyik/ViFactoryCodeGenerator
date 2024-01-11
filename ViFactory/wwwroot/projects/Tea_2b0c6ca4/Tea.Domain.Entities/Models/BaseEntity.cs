using Tea.Core.Enums;
using Tea.Core.Models;

namespace Tea.Domain.Models
{
    public class BaseEntity : IBaseEntity
    {
        public int Id { get; set; }
        public DbEntityState DbState { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
    }
}