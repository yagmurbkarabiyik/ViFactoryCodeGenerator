using Microsoft.EntityFrameworkCore;
using aws.Dal.FluentApi;
using aws.Domain.Entities.Models;
#region CustomUsing
#endregion CustomUsing

namespace aws.Dal.Context
{
    public class awsDbContext : DbContext
    {
        public awsDbContext(DbContextOptions<awsDbContext> ctx) : base(ctx)
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