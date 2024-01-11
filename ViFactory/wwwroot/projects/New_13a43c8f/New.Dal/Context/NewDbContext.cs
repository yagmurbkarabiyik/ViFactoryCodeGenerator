using Microsoft.EntityFrameworkCore;
using New.Dal.FluentApi;

namespace New.Dal.Context
{
    public class NewDbContext : DbContext
    {
        public NewDbContext(DbContextOptions<NewDbContext> ctx) : base(ctx)
        {
            #region CustomConstructor
            #endregion
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
           #region CustomOnModelCreating
           #endregion

           base.OnModelCreating(builder);

          
        }
           
           #region Custom
           #endregion
    }
}