using Microsoft.EntityFrameworkCore;
using Milk.Dal.FluentApi;

namespace Milk.Dal.Context
{
    public class MilkDbContext : DbContext
    {
        public MilkDbContext(DbContextOptions<MilkDbContext> ctx) : base(ctx)
        {

        }
        
         protected override void OnModelCreating(ModelBuilder builder)
        {
           base.OnModelCreating(builder);

          
        }
           
    }
}