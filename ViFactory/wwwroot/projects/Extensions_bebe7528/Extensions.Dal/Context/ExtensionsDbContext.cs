using Microsoft.EntityFrameworkCore;
using Extensions.Dal.FluentApi;

namespace Extensions.Dal.Context
{
    public class ExtensionsDbContext : DbContext
    {
        public ExtensionsDbContext(DbContextOptions<ExtensionsDbContext> ctx) : base(ctx)
        {

        }
        
         protected override void OnModelCreating(ModelBuilder builder)
        {
           base.OnModelCreating(builder);

          
        }
           
    }
}