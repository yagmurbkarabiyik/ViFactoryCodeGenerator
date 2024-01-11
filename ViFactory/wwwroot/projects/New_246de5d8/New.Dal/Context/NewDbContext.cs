using Microsoft.EntityFrameworkCore;
using New.Dal.FluentApi;

namespace New.Dal.Context
{
    public class NewDbContext : DbContext
    {
        public NewDbContext(DbContextOptions<NewDbContext> ctx) : base(ctx)
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