using Ybk.Core.Enums;
using Ybk.Core.Models;

namespace Ybk.Domain.Entities.Models
{
    public class BaseEntity : IBaseEntity
    {
        public int Id { get; set; }
        public DbEntityState DbState { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
    }
}