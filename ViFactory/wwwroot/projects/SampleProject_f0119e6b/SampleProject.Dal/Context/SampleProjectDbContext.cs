using Microsoft.EntityFrameworkCore;
using SampleProject.Dal.FluentApi;
using SampleProject.Domain.Entities.Models;
using SampleProject.Domain.IdentityModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
#region CustomUsing
#endregion CustomUsing

namespace SampleProject.Dal.Context
{
    public class SampleProjectDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public SampleProjectDbContext(DbContextOptions<SampleProjectDbContext> ctx) : base(ctx)
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