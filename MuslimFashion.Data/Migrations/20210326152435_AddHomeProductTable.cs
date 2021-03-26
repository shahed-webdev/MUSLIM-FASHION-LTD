using Microsoft.EntityFrameworkCore.Migrations;

namespace MuslimFashion.Data.Migrations
{
    public partial class AddHomeProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HomeProduct",
                columns: table => new
                {
                    HomeProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    HomeMenuId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeProduct", x => x.HomeProductId);
                    table.ForeignKey(
                        name: "FK_HomeProduct_HomeMenu",
                        column: x => x.HomeMenuId,
                        principalTable: "HomeMenu",
                        principalColumn: "HomeMenuId");
                    table.ForeignKey(
                        name: "FK_HomeProduct_Product",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HomeProduct_HomeMenuId",
                table: "HomeProduct",
                column: "HomeMenuId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeProduct_ProductId",
                table: "HomeProduct",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HomeProduct");
        }
    }
}
