using Microsoft.EntityFrameworkCore;
using dddd.Dal.FluentApi;
using dddd.Domain.Entities.Models;
using dddd.Domain.IdentityModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
#region CustomUsing
#endregion CustomUsing

namespace dddd.Dal.Context
{
    public class ddddDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public ddddDbContext(DbContextOptions<ddddDbContext> ctx) : base(ctx)
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