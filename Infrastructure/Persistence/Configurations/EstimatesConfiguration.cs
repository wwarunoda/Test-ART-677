using Domain;
using Infrastructure.Persistence.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class EstimatesConfiguration : BaseConfiguration<Estimate>, IEntityTypeConfiguration<Estimate>
    {
        public override void Configure(EntityTypeBuilder<Estimate> builder)
        {

            base.Configure(builder);
            builder.ToTable("Estimate");
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).HasColumnName("id").HasMaxLength(50).ValueGeneratedOnAdd();
            builder.Property(o => o.District).HasColumnName("note").HasMaxLength(50);
        }
    }
}
