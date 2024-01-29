using Microsoft.EntityFrameworkCore;
using Deneme.Dal.FluentApi;
using Deneme.Domain.Entities.Models;
using Deneme.Domain.IdentityModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
#region CustomUsing
#endregion CustomUsing

namespace Deneme.Dal.Context
{
    public class DenemeDbContext : IdentityDbContext<AppUser, AppRole, int>
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