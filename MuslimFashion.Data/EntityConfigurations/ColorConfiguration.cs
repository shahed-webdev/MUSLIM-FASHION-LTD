using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MuslimFashion.Data
{
    public class ColorConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.Property(e => e.ColorName)
                .IsRequired()
                .HasMaxLength(128);
            builder.Property(e => e.ColorCode)
                .HasMaxLength(50);
            builder.Property(e => e.InsertDateUtc)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getutcdate())");
        }
    }
}