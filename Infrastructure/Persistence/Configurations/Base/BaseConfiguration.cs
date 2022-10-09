using Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.Base
{
    public  class BaseConfiguration<T> where T: BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(o => o.State).HasColumnName("state").HasMaxLength(50).ValueGeneratedOnAdd();
            builder.Property(o => o.Population).HasColumnName("population").HasMaxLength(50);
            builder.Property(o => o.Household).HasColumnName("household").HasMaxLength(50);
        }
    }
}
