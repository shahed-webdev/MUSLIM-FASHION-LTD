using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MuslimFashion.Data
{
    public class SubMenuConfiguration : IEntityTypeConfiguration<SubMenu>
    {
        public void Configure(EntityTypeBuilder<SubMenu> builder)
        {
            builder.Property(e => e.SubMenuName)
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(e => e.InsertDateUtc)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getutcdate())");

            builder.HasOne(e => e.Menu)
                .WithMany(d => d.SubMenus)
                .HasForeignKey(e => e.MenuId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_SubMenu_Menu");
        }
    }
}