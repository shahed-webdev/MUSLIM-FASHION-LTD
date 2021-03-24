using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MuslimFashion.Data
{
    public class HomeMenuConfiguration : IEntityTypeConfiguration<HomeMenu>
    {
        public void Configure(EntityTypeBuilder<HomeMenu> builder)
        {
            builder.Property(e => e.HomeMenuName)
                .IsRequired()
                .HasMaxLength(128);
            builder.Property(e => e.ImageFileName)
                .HasMaxLength(128);
            builder.Property(e => e.InsertDateUtc)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getutcdate())");
        }
    }
}