using Microsoft.EntityFrameworkCore;
using Neeww.Dal.FluentApi;

namespace Neeww.Dal.Context
{
    public class NeewwDbContext : DbContext
    {
        public NeewwDbContext(DbContextOptions<NeewwDbContext> ctx) : base(ctx)
        {
            #region CustomBase
            #endregion
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
           #region CustomBaseOnModelCreatin
           #endregion

           base.OnModelCreating(builder);

          
        }
           
    }
}