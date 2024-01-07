using Microsoft.EntityFrameworkCore;
using IceTea.Dal.FluentApi;

namespace IceTea.Dal.Context
{
    public class IceTeaDbContext : DbContext
    {
        public IceTeaDbContext(DbContextOptions<IceTeaDbContext> ctx) : base(ctx)
        {

        }
        
         protected override void OnModelCreating(ModelBuilder builder)
        {
           base.OnModelCreating(builder);

          
        }
           
    }
}