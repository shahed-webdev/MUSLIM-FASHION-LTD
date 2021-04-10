using Microsoft.EntityFrameworkCore.Migrations;

namespace MuslimFashion.Data.Migrations
{
    public partial class DeleteProdcutSizeTableLinkToOrderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderList_ProductSize",
                table: "OrderList");

            migrationBuilder.DropIndex(
                name: "IX_OrderList_ProductSizeId",
                table: "OrderList");

            migrationBuilder.DropColumn(
                name: "ProductSizeId",
                table: "OrderList");

            migrationBuilder.AddColumn<string>(
                name: "ProductSize",
                table: "OrderList",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductSize",
                table: "OrderList");

            migrationBuilder.AddColumn<int>(
                name: "ProductSizeId",
                table: "OrderList",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderList_ProductSizeId",
                table: "OrderList",
                column: "ProductSizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderList_ProductSize",
                table: "OrderList",
                column: "ProductSizeId",
                principalTable: "ProductSize",
                principalColumn: "ProductSizeId");
        }
    }
}
