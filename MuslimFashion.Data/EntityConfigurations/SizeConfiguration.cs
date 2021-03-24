using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MuslimFashion.Data
{
    public class SizeConfiguration : IEntityTypeConfiguration<Size>
    {
        public void Configure(EntityTypeBuilder<Size> builder)
        {
            builder.Property(e => e.SizeName)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(e => e.Description)
                .HasMaxLength(512);
            builder.Property(e => e.InsertDateUtc)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getutcdate())");
        }
    }
}