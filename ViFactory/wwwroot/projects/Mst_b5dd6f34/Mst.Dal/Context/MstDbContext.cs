using Microsoft.EntityFrameworkCore;
using Mst.Dal.FluentApi;

namespace Mst.Dal.Context
{
    public class MstDbContext : DbContext
    {
        public MstDbContext(DbContextOptions<MstDbContext> ctx) : base(ctx)
        {

        }
        
         protected override void OnModelCreating(ModelBuilder builder)
        {
           base.OnModelCreating(builder);

          
        }
           
    }
}