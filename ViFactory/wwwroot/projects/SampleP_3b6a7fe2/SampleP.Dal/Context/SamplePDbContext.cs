using Microsoft.EntityFrameworkCore;
using SampleP.Dal.FluentApi;
using SampleP.Domain.Entities.Models;
using SampleP.Domain.IdentityModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
#region CustomUsing
#endregion CustomUsing

namespace SampleP.Dal.Context
{
    public class SamplePDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public SamplePDbContext(DbContextOptions<SamplePDbContext> ctx) : base(ctx)
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