using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerencesite.Migrations
{
    /// <inheritdoc />
    public partial class fixResponse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_userMedicines_ResponseModelstatusCode",
                table: "userMedicines");

            migrationBuilder.DropIndex(
                name: "IX_orders_ResponseModelstatusCode",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orderItems_ResponseModelstatusCode",
                table: "orderItems");

            migrationBuilder.DropIndex(
                name: "IX_medicines_ResponseModelstatusCode",
                table: "medicines");

            migrationBuilder.DropIndex(
                name: "IX_carts_ResponseModelstatusCode",
                table: "carts");

            migrationBuilder.DropColumn(
                name: "ResponseModelstatusCode",
                table: "userMedicines");

            migrationBuilder.DropColumn(
                name: "ResponseModelstatusCode",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "ResponseModelstatusCode",
                table: "orderItems");

            migrationBuilder.DropColumn(
                name: "ResponseModelstatusCode",
                table: "medicines");

            migrationBuilder.DropColumn(
                name: "ResponseModelstatusCode",
                table: "carts");

            migrationBuilder.AlterColumn<decimal>(
                name: "Fund",
                table: "userMedicines",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Ordertotal",
                table: "orders",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderStatus",
                table: "orders",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "OrderNumber",
                table: "orders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<decimal>(
                name: "UnitPrice",
                table: "orderItems",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Totalprice",
                table: "orderItems",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Discount",
                table: "orderItems",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "UnitPrice",
                table: "medicines",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "medicines",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "IMAGEURL",
                table: "medicines",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpiryDate",
                table: "medicines",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<decimal>(
                name: "Discount",
                table: "medicines",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "UnitPrice",
                table: "carts",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Totalprice",
                table: "carts",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Discount",
                table: "carts",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Fund",
                table: "userMedicines",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResponseModelstatusCode",
                table: "userMedicines",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Ordertotal",
                table: "orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderStatus",
                table: "orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OrderNumber",
                table: "orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResponseModelstatusCode",
                table: "orders",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "UnitPrice",
                table: "orderItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Totalprice",
                table: "orderItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Discount",
                table: "orderItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResponseModelstatusCode",
                table: "orderItems",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "UnitPrice",
                table: "medicines",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "medicines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IMAGEURL",
                table: "medicines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpiryDate",
                table: "medicines",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Discount",
                table: "medicines",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResponseModelstatusCode",
                table: "medicines",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "UnitPrice",
                table: "carts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Totalprice",
                table: "carts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Discount",
                table: "carts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResponseModelstatusCode",
                table: "carts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "responseModels",
                columns: table => new
                {
                    statusCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cartId = table.Column<int>(type: "int", nullable: false),
                    medicineid = table.Column<int>(type: "int", nullable: false),
                    orderid = table.Column<int>(type: "int", nullable: false),
                    orderItemId = table.Column<int>(type: "int", nullable: false),
                    userMedicineid = table.Column<int>(type: "int", nullable: false),
                    responseMessage = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    table.ForeignKey(
                        name: "FK_responseModels_userMedicines_userMedicineid",
                        column: x => x.userMedicineid,
                        principalTable: "userMedicines",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_userMedicines_ResponseModelstatusCode",
                table: "userMedicines",
                column: "ResponseModelstatusCode");

            migrationBuilder.CreateIndex(
                name: "IX_orders_ResponseModelstatusCode",
                table: "orders",
                column: "ResponseModelstatusCode");

            migrationBuilder.CreateIndex(
                name: "IX_orderItems_ResponseModelstatusCode",
                table: "orderItems",
                column: "ResponseModelstatusCode");

            migrationBuilder.CreateIndex(
                name: "IX_medicines_ResponseModelstatusCode",
                table: "medicines",
                column: "ResponseModelstatusCode");

            migrationBuilder.CreateIndex(
                name: "IX_carts_ResponseModelstatusCode",
                table: "carts",
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
                name: "FK_userMedicines_responseModels_ResponseModelstatusCode",
                table: "userMedicines",
                column: "ResponseModelstatusCode",
                principalTable: "responseModels",
                principalColumn: "statusCode");
        }
    }
}
