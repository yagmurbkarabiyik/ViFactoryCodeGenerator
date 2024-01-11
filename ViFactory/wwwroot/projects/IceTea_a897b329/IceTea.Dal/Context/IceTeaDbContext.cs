using Microsoft.EntityFrameworkCore;
using IceTea.Dal.FluentApi;
using IceTea.Domain.Entities.Models;
#region CustomUsing
#endregion CustomUsing

namespace IceTea.Dal.Context
{
    public class IceTeaDbContext : DbContext
    {
        public IceTeaDbContext(DbContextOptions<IceTeaDbContext> ctx) : base(ctx)
        {
            #region CustomConstructor
            #endregion CustomConstructor
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
           #region CustomOnModelCreating
           #endregion CustomOnModelCreating

           base.OnModelCreating(builder);
        }
           #region CustomCode
           #endregion CustomCode

    }
}