using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MuslimFashion.Data.Migrations
{
    public partial class AddProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubMenuId = table.Column<int>(nullable: false),
                    ProductName = table.Column<string>(maxLength: 256, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    OldPrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    ProductCode = table.Column<string>(maxLength: 50, nullable: false),
                    Brand = table.Column<string>(maxLength: 128, nullable: true),
                    FabricType = table.Column<string>(maxLength: 128, nullable: true),
                    Description = table.Column<string>(maxLength: 1024, nullable: true),
                    InsertDateUtc = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getutcdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Product_SubMenu",
                        column: x => x.SubMenuId,
                        principalTable: "SubMenu",
                        principalColumn: "SubMenuId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_SubMenuId",
                table: "Product",
                column: "SubMenuId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
