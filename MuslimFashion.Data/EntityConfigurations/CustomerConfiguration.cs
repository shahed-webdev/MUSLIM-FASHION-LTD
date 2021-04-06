using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MuslimFashion.Data
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(e => e.Phone)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Email)
                .HasMaxLength(128);


            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(256);
        }
    }
}