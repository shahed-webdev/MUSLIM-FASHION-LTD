using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MuslimFashion.Data
{
    public class BasicSettingConfiguration : IEntityTypeConfiguration<BasicSetting>
    {
        public void Configure(EntityTypeBuilder<BasicSetting> builder)
        {
            builder.Property(e => e.InSideDhaka)
                .HasColumnType("decimal(18, 2)");
            builder.Property(e => e.OutSideDhaka)
                .HasColumnType("decimal(18, 2)");

            builder.HasData(new BasicSetting
            {
                BasicSettingId = 1,
                InSideDhaka = 60,
                OutSideDhaka = 100
            });
        }
    }
}