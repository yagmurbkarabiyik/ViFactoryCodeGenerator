using Microsoft.EntityFrameworkCore;
using New.Dal.FluentApi;
using New.Domain.Entities.Models;
using New.Domain.IdentityModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
#region CustomUsing
#endregion CustomUsing

namespace New.Dal.Context
{
    public class NewDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public NewDbContext(DbContextOptions<NewDbContext> ctx) : base(ctx)
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