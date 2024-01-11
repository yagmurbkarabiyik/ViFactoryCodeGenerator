using Microsoft.EntityFrameworkCore;
using Mst.Dal.FluentApi;
using Mst.Domain.Entities.Models;
#region CustomUsing
#endregion CustomUsing

namespace Mst.Dal.Context
{
    public class MstDbContext : DbContext
    {
        public MstDbContext(DbContextOptions<MstDbContext> ctx) : base(ctx)
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