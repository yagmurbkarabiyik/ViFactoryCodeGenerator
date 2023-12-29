using Microsoft.EntityFrameworkCore;
using Artyfy.Dal.FluentApi;

namespace Artyfy.Dal.Context
{
    public class ArtyfyDbContext : DbContext
    {
        public ArtyfyDbContext(DbContextOptions<ArtyfyDbContext> ctx) : base(ctx)
        {

        }
        
         protected override void OnModelCreating(ModelBuilder builder)
        {
           base.OnModelCreating(builder);

          
        }
           
    }
}