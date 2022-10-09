using Domain;
using Infrastructure.Persistence.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class ActualConfiguration :BaseConfiguration<Actual>, IEntityTypeConfiguration<Actual>
    {
        public override void Configure(EntityTypeBuilder<Actual> builder)
        {

            base.Configure(builder);
            builder.ToTable("Actual");
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).HasColumnName("id").HasMaxLength(50).ValueGeneratedOnAdd();
        }
    }
}
