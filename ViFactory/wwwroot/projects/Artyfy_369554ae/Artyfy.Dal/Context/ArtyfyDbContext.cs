using Microsoft.EntityFrameworkCore;
using Artyfy.Dal.FluentApi;
using Artyfy.Domain.Entities.Models;
#region CustomUsing
#endregion CustomUsing

namespace Artyfy.Dal.Context
{
    public class ArtyfyDbContext : DbContext
    {
        public ArtyfyDbContext(DbContextOptions<ArtyfyDbContext> ctx) : base(ctx)
        {
            #region CustomConstructor
            #endregion CustomConstructor
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
           #region CustomOnModelCreating
           #endregion CustomOnModelCreating

           base.OnModelCreating(builder);
        }
           #region CustomCode
           #endregion CustomCode

    }
}