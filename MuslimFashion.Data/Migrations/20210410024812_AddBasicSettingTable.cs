using Microsoft.EntityFrameworkCore.Migrations;

namespace MuslimFashion.Data.Migrations
{
    public partial class AddBasicSettingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BasicSetting",
                columns: table => new
                {
                    BasicSettingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InSideDhaka = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    OutSideDhaka = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasicSetting", x => x.BasicSettingId);
                });

            migrationBuilder.InsertData(
                table: "BasicSetting",
                columns: new[] { "BasicSettingId", "InSideDhaka", "OutSideDhaka" },
                values: new object[] { 1, 60m, 100m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasicSetting");
        }
    }
}
