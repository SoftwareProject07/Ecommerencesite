using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerencesite.Migrations
{
    /// <inheritdoc />
    public partial class ecommerecemedicine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Totalprice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ResponseModelstatusCode = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "medicines",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IMAGEURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    STATUS = table.Column<int>(type: "int", nullable: false),
                    ResponseModelstatusCode = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicines", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "orderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    MedicineId = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Totalprice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ResponseModelstatusCode = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OrderNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ordertotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderStatus = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ResponseModelstatusCode = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "responseModels",
                columns: table => new
                {
                    statusCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    responseMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userMedicineid = table.Column<int>(type: "int", nullable: false),
                    medicineid = table.Column<int>(type: "int", nullable: false),
                    cartId = table.Column<int>(type: "int", nullable: false),
                    orderid = table.Column<int>(type: "int", nullable: false),
                    orderItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_responseModels", x => x.statusCode);
                    table.ForeignKey(
                        name: "FK_responseModels_carts_cartId",
                        column: x => x.cartId,
                        principalTable: "carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_responseModels_medicines_medicineid",
                        column: x => x.medicineid,
                        principalTable: "medicines",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_responseModels_orderItems_orderItemId",
                        column: x => x.orderItemId,
                        principalTable: "orderItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_responseModels_orders_orderid",
                        column: x => x.orderid,
                        principalTable: "orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "userMedicines",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fund = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ResponseModelstatusCode = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userMedicines", x => x.id);
                    table.ForeignKey(
                        name: "FK_userMedicines_responseModels_ResponseModelstatusCode",
                        column: x => x.ResponseModelstatusCode,
                        principalTable: "responseModels",
                        principalColumn: "statusCode");
                });

            migrationBuilder.CreateIndex(
                name: "IX_carts_ResponseModelstatusCode",
                table: "carts",
                column: "ResponseModelstatusCode");

            migrationBuilder.CreateIndex(
                name: "IX_medicines_ResponseModelstatusCode",
                table: "medicines",
                column: "ResponseModelstatusCode");

            migrationBuilder.CreateIndex(
                name: "IX_orderItems_ResponseModelstatusCode",
                table: "orderItems",
                column: "ResponseModelstatusCode");

            migrationBuilder.CreateIndex(
                name: "IX_orders_ResponseModelstatusCode",
                table: "orders",
                column: "ResponseModelstatusCode");

            migrationBuilder.CreateIndex(
                name: "IX_responseModels_cartId",
                table: "responseModels",
                column: "cartId");

            migrationBuilder.CreateIndex(
                name: "IX_responseModels_medicineid",
                table: "responseModels",
                column: "medicineid");

            migrationBuilder.CreateIndex(
                name: "IX_responseModels_orderid",
                table: "responseModels",
                column: "orderid");

            migrationBuilder.CreateIndex(
                name: "IX_responseModels_orderItemId",
                table: "responseModels",
                column: "orderItemId");

            migrationBuilder.CreateIndex(
                name: "IX_responseModels_userMedicineid",
                table: "responseModels",
                column: "userMedicineid");

            migrationBuilder.CreateIndex(
                name: "IX_userMedicines_ResponseModelstatusCode",
                table: "userMedicines",
                column: "ResponseModelstatusCode");

            migrationBuilder.AddForeignKey(
                name: "FK_carts_responseModels_ResponseModelstatusCode",
                table: "carts",
                column: "ResponseModelstatusCode",
                principalTable: "responseModels",
                principalColumn: "statusCode");

            migrationBuilder.AddForeignKey(
                name: "FK_medicines_responseModels_ResponseModelstatusCode",
                table: "medicines",
                column: "ResponseModelstatusCode",
                principalTable: "responseModels",
                principalColumn: "statusCode");

            migrationBuilder.AddForeignKey(
                name: "FK_orderItems_responseModels_ResponseModelstatusCode",
                table: "orderItems",
                column: "ResponseModelstatusCode",
                principalTable: "responseModels",
                principalColumn: "statusCode");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_responseModels_ResponseModelstatusCode",
                table: "orders",
                column: "ResponseModelstatusCode",
                principalTable: "responseModels",
                principalColumn: "statusCode");

            migrationBuilder.AddForeignKey(
                name: "FK_responseModels_userMedicines_userMedicineid",
                table: "responseModels",
                column: "userMedicineid",
                principalTable: "userMedicines",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_carts_responseModels_ResponseModelstatusCode",
                table: "carts");

            migrationBuilder.DropForeignKey(
                name: "FK_medicines_responseModels_ResponseModelstatusCode",
                table: "medicines");

            migrationBuilder.DropForeignKey(
                name: "FK_orderItems_responseModels_ResponseModelstatusCode",
                table: "orderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_responseModels_ResponseModelstatusCode",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_userMedicines_responseModels_ResponseModelstatusCode",
                table: "userMedicines");

            migrationBuilder.DropTable(
                name: "responseModels");

            migrationBuilder.DropTable(
                name: "carts");

            migrationBuilder.DropTable(
                name: "medicines");

            migrationBuilder.DropTable(
                name: "orderItems");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "userMedicines");
        }
    }
}
