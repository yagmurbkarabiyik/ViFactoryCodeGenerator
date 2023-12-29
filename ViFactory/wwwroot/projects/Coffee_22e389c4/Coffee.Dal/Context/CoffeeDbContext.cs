using Microsoft.EntityFrameworkCore;
using Coffee.Domain.Entities;
using Coffee.Dal.FluentApi;

namespace Coffee.Dal.Context
{
    public class CoffeeDbContext : DbContext
    {
        public CoffeeDbContext(DbContextOptions<CoffeeDbContext> ctx) : base(ctx)
        {

        }
        
         protected override void OnModelCreating(ModelBuilder builder)
        {
           base.OnModelCreating(builder);

          
        }
           
    }
}