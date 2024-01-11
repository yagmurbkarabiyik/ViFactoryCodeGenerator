using Microsoft.EntityFrameworkCore;
using Neew.Dal.FluentApi;

namespace Neew.Dal.Context
{
    public class NeewDbContext : DbContext
    {
        public NeewDbContext(DbContextOptions<NeewDbContext> ctx) : base(ctx)
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