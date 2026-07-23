using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Ecommerencesite.Migrations
{
    /// <inheritdoc />
    public partial class newmodeladdress_trackingapi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "orderss",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "DistanceInKm",
                table: "orderss",
                type: "numeric(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EstimatedTime",
                table: "orderss",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StoreId",
                table: "orderss",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "UnitPrice",
                table: "orderItemss",
                type: "numeric(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Totalprice",
                table: "orderItemss",
                type: "numeric(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Discount",
                table: "orderItemss",
                type: "numeric(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "BankRefundableAmount",
                table: "BankRefundableAmountModels",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "deliverypartnermodels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    AddressLine = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    Pincode = table.Column<string>(type: "text", nullable: false),
                    Latitude = table.Column<decimal>(type: "numeric(18,6)", nullable: false),
                    Longitude = table.Column<decimal>(type: "numeric(18,6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_deliverypartnermodels", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_orderss_AddressId",
                table: "orderss",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_orderItemss_OrderId",
                table: "orderItemss",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_orderItemss_orderss_OrderId",
                table: "orderItemss",
                column: "OrderId",
                principalTable: "orderss",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orderss_deliverypartnermodels_AddressId",
                table: "orderss",
                column: "AddressId",
                principalTable: "deliverypartnermodels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderItemss_orderss_OrderId",
                table: "orderItemss");

            migrationBuilder.DropForeignKey(
                name: "FK_orderss_deliverypartnermodels_AddressId",
                table: "orderss");

            migrationBuilder.DropTable(
                name: "deliverypartnermodels");

            migrationBuilder.DropIndex(
                name: "IX_orderss_AddressId",
                table: "orderss");

            migrationBuilder.DropIndex(
                name: "IX_orderItemss_OrderId",
                table: "orderItemss");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "orderss");

            migrationBuilder.DropColumn(
                name: "DistanceInKm",
                table: "orderss");

            migrationBuilder.DropColumn(
                name: "EstimatedTime",
                table: "orderss");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "orderss");

            migrationBuilder.AlterColumn<decimal>(
                name: "UnitPrice",
                table: "orderItemss",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Totalprice",
                table: "orderItemss",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Discount",
                table: "orderItemss",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "BankRefundableAmount",
                table: "BankRefundableAmountModels",
                type: "numeric(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);
        }
    }
}
