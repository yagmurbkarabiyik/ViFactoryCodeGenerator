using Microsoft.EntityFrameworkCore;
using Coffee.Dal.FluentApi;
using Coffee.Domain.Entities.Models;
using Coffee.Domain.IdentityModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
#region CustomUsing
#endregion CustomUsing

namespace Coffee.Dal.Context
{
    public class CoffeeDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public CoffeeDbContext(DbContextOptions<CoffeeDbContext> ctx) : base(ctx)
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