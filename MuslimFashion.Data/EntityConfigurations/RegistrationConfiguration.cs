using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace MuslimFashion.Data
{
    public class RegistrationConfiguration : IEntityTypeConfiguration<Registration>
    {
        public void Configure(EntityTypeBuilder<Registration> builder)
        {
            builder.Property(e => e.UserName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Type)
                .IsRequired()
                .HasMaxLength(50)
                .HasConversion(c => c.ToString(), c => Enum.Parse<UserType>(c));

            builder.Property(e => e.Name)
                .HasMaxLength(128);

            builder.Property(e => e.DateofBirth)
                .HasMaxLength(50);

            builder.Property(e => e.Phone)
                .HasMaxLength(50);

            builder.Property(e => e.Email)
                .HasMaxLength(50);

            builder.Property(e => e.CreatedOnUtc)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getutcdate())");
        }
    }
}