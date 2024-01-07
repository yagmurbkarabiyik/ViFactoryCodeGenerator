using Microsoft.EntityFrameworkCore;
using Tea.Dal.FluentApi;

namespace Tea.Dal.Context
{
    public class TeaDbContext : DbContext
    {
        public TeaDbContext(DbContextOptions<TeaDbContext> ctx) : base(ctx)
        {

        }
        
         protected override void OnModelCreating(ModelBuilder builder)
        {
           base.OnModelCreating(builder);

          
        }
           
    }
}