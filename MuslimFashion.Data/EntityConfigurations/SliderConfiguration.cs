using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MuslimFashion.Data
{
    public class SliderConfiguration : IEntityTypeConfiguration<Slider>
    {
        public void Configure(EntityTypeBuilder<Slider> builder)
        {
            builder.Property(e => e.ImageFileName)
                .IsRequired()
                .HasMaxLength(128);
            builder.Property(e => e.Caption)
                .HasMaxLength(128);

        }
    }
}