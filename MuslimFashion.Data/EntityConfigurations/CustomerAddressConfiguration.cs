using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MuslimFashion.Data
{
    public class CustomerAddressConfiguration : IEntityTypeConfiguration<CustomerAddress>
    {
        public void Configure(EntityTypeBuilder<CustomerAddress> builder)
        {
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(128);
            builder.Property(e => e.Phone)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(e => e.Address)
                .IsRequired()
                .HasMaxLength(1024);
            builder.HasOne(e => e.Customer)
                .WithMany(c => c.CustomerAddress)
                .HasForeignKey(e => e.CustomerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_CustomerAddress_Customer");
        }
    }
}