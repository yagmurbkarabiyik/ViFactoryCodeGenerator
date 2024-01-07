using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using IceTea.Core.Models;

namespace IceTea.Dal.FluentApi
{
    public abstract class BaseMap<T> : IEntityTypeConfiguration<T> where T : class, IBaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.CreatedDate).IsRequired().HasColumnType("timestamptz");
            builder.Property(x => x.UpdatedDate).IsRequired(false).HasColumnType("timestamptz");
        }
    }
}




    
      