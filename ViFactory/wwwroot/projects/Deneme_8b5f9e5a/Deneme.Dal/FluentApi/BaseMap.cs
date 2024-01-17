using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Deneme.Core.Models;

namespace Deneme.Dal.FluentApi
{
    public abstract class BaseMap<T> : IEntityTypeConfiguration<T> where T : class, IBaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.DbState).IsRequired();
            builder.Property(x => x.CreatedDate).IsRequired().HasColumnType("timestamptz");
            builder.Property(x => x.UpdatedDate).IsRequired(false).HasColumnType("timestamptz");
        }
    }
}




    
      