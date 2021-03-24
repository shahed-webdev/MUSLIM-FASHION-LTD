using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MuslimFashion.Data.Migrations
{
    public partial class AddSizeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Size",
                columns: table => new
                {
                    SizeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SizeName = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 512, nullable: true),
                    InsertDateUtc = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getutcdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Size", x => x.SizeId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Size");
        }
    }
}
