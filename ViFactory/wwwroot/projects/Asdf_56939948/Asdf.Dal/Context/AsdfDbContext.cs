using Microsoft.EntityFrameworkCore;
using Asdf.Dal.FluentApi;
using Asdf.Domain.Entities.Models;
using Asdf.Domain.IdentityModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
#region CustomUsing
#endregion CustomUsing

namespace Asdf.Dal.Context
{
    public class AsdfDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public AsdfDbContext(DbContextOptions<AsdfDbContext> ctx) : base(ctx)
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