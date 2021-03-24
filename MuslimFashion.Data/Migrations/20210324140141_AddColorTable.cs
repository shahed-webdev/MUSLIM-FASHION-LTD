using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MuslimFashion.Data.Migrations
{
    public partial class AddColorTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Color",
                columns: table => new
                {
                    ColorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorName = table.Column<string>(maxLength: 128, nullable: false),
                    ColorCode = table.Column<string>(maxLength: 50, nullable: true),
                    InsertDateUtc = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getutcdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.ColorId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Color");
        }
    }
}
