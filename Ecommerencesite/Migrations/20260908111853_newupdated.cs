using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerencesite.Migrations
{
    /// <inheritdoc />
    public partial class newupdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderss_userMediciness_UserId",
                table: "orderss");

            migrationBuilder.DropIndex(
                name: "IX_orderss_UserId",
                table: "orderss");

            migrationBuilder.DropColumn(
                name: "BankName",
                table: "qRCashCodeModelss");

            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "qRCashCodeModelss");

            migrationBuilder.DropColumn(
                name: "QRcashcode",
                table: "qRCashCodeModelss");

            migrationBuilder.DropColumn(
                name: "TOTALAMOUNT",
                table: "qRCashCodeModelss");

            migrationBuilder.DropColumn(
                name: "itemprice",
                table: "qRCashCodeModelss");

            migrationBuilder.DropColumn(
                name: "totalitem",
                table: "qRCashCodeModelss");

            migrationBuilder.DropColumn(
                name: "totalquantity",
                table: "qRCashCodeModelss");

            migrationBuilder.AddColumn<string>(
                name: "QRCodeImageUrl",
                table: "qRCashCodeModelss",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<decimal>(
                name: "Ordertotal",
                table: "orderss",
                type: "numeric(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "UnitPrice",
                table: "orderItemss",
                type: "numeric(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "Totalprice",
                table: "orderItemss",
                type: "numeric(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "Discount",
                table: "orderItemss",
                type: "numeric(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QRCodeImageUrl",
                table: "qRCashCodeModelss");

            migrationBuilder.AddColumn<string>(
                name: "BankName",
                table: "qRCashCodeModelss",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "qRCashCodeModelss",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "QRcashcode",
                table: "qRCashCodeModelss",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TOTALAMOUNT",
                table: "qRCashCodeModelss",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "itemprice",
                table: "qRCashCodeModelss",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "totalitem",
                table: "qRCashCodeModelss",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "totalquantity",
                table: "qRCashCodeModelss",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<decimal>(
                name: "Ordertotal",
                table: "orderss",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "UnitPrice",
                table: "orderItemss",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Totalprice",
                table: "orderItemss",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Discount",
                table: "orderItemss",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)");

            migrationBuilder.CreateIndex(
                name: "IX_orderss_UserId",
                table: "orderss",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_orderss_userMediciness_UserId",
                table: "orderss",
                column: "UserId",
                principalTable: "userMediciness",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
