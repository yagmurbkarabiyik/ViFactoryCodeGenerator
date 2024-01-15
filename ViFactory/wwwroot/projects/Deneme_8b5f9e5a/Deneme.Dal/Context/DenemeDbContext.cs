using Microsoft.EntityFrameworkCore;
using Deneme.Dal.FluentApi;
using Deneme.Domain.Entities.Models;
#region CustomUsing
#endregion CustomUsing

namespace Deneme.Dal.Context
{
    public class DenemeDbContext : DbContext
    {
        public DenemeDbContext(DbContextOptions<DenemeDbContext> ctx) : base(ctx)
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