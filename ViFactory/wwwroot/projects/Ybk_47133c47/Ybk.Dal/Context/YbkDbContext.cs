using Microsoft.EntityFrameworkCore;
using Ybk.Dal.FluentApi;
using Ybk.Domain.Entities.Models;
using Ybk.Domain.IdentityModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
#region CustomUsing
#endregion CustomUsing

namespace Ybk.Dal.Context
{
    public class YbkDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public YbkDbContext(DbContextOptions<YbkDbContext> ctx) : base(ctx)
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