using Microsoft.EntityFrameworkCore.Migrations;

namespace MuslimFashion.Data.Migrations
{
    public partial class AddSliderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Slider",
                columns: table => new
                {
                    SliderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageFileName = table.Column<string>(maxLength: 128, nullable: false),
                    Caption = table.Column<string>(maxLength: 128, nullable: true),
                    Sn = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slider", x => x.SliderId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Slider");
        }
    }
}
