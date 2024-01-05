using Microsoft.EntityFrameworkCore;
using Deneme.Dal.FluentApi;

namespace Deneme.Dal.Context
{
    public class DenemeDbContext : DbContext
    {
        public DenemeDbContext(DbContextOptions<DenemeDbContext> ctx) : base(ctx)
        {

        }
        
         protected override void OnModelCreating(ModelBuilder builder)
        {
           base.OnModelCreating(builder);

          
        }
           
    }
}