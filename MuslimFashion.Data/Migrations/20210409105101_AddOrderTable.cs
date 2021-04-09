using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MuslimFashion.Data.Migrations
{
    public partial class AddOrderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNo = table.Column<int>(nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    DeliveryCost = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    IsInDhaka = table.Column<bool>(nullable: false),
                    OrderStatus = table.Column<string>(maxLength: 50, nullable: false),
                    NetAmount = table.Column<decimal>(nullable: false, computedColumnSql: "(([TotalPrice]-[Discount])+[DeliveryCost])"),
                    CustomerId = table.Column<int>(nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    StatusChangeDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    InsertDateUtc = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getutcdate())"),
                    DeliveryName = table.Column<string>(maxLength: 128, nullable: false),
                    DeliveryAddress = table.Column<string>(maxLength: 1024, nullable: false),
                    DeliveryPhone = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Order_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderList",
                columns: table => new
                {
                    OrderListId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    LineTotal = table.Column<decimal>(nullable: false, computedColumnSql: "([UnitPrice] * [Quantity])"),
                    ProductSizeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderList", x => x.OrderListId);
                    table.ForeignKey(
                        name: "FK_OrderList_Order",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderList_Product",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId");
                    table.ForeignKey(
                        name: "FK_OrderList_ProductSize",
                        column: x => x.ProductSizeId,
                        principalTable: "ProductSize",
                        principalColumn: "ProductSizeId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                table: "Order",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderList_OrderId",
                table: "OrderList",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderList_ProductId",
                table: "OrderList",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderList_ProductSizeId",
                table: "OrderList",
                column: "ProductSizeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderList");

            migrationBuilder.DropTable(
                name: "Order");
        }
    }
}
