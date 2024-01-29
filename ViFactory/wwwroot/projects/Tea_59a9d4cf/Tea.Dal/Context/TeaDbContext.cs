using Microsoft.EntityFrameworkCore;
using Tea.Dal.FluentApi;
using Tea.Domain.Entities.Models;
using Tea.Domain.IdentityModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
#region CustomUsing
#endregion CustomUsing

namespace Tea.Dal.Context
{
    public class TeaDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public TeaDbContext(DbContextOptions<TeaDbContext> ctx) : base(ctx)
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