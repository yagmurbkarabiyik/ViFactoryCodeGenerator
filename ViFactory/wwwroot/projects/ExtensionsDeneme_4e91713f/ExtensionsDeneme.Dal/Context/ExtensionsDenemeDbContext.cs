using Microsoft.EntityFrameworkCore;
using ExtensionsDeneme.Dal.FluentApi;

namespace ExtensionsDeneme.Dal.Context
{
    public class ExtensionsDenemeDbContext : DbContext
    {
        public ExtensionsDenemeDbContext(DbContextOptions<ExtensionsDenemeDbContext> ctx) : base(ctx)
        {

        }
        
         protected override void OnModelCreating(ModelBuilder builder)
        {
           base.OnModelCreating(builder);

          
        }
           
    }
}