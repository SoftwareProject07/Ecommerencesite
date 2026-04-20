using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Ecommerencesite.Migrations
{
    /// <inheritdoc />
    public partial class newupdatemodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BankName",
                table: "bankdetailsModless",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "bankselectmodelss",
                columns: table => new
                {
                    bankselectid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BankName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bankselectmodelss", x => x.bankselectid);
                });

            migrationBuilder.CreateTable(
                name: "qRCashCodeModelss",
                columns: table => new
                {
                    QRcashcodeid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BankName = table.Column<string>(type: "text", nullable: true),
                    CustomerName = table.Column<string>(type: "text", nullable: true),
                    itemprice = table.Column<double>(type: "double precision", nullable: false),
                    totalitem = table.Column<double>(type: "double precision", nullable: false),
                    totalquantity = table.Column<double>(type: "double precision", nullable: false),
                    TOTALAMOUNT = table.Column<double>(type: "double precision", nullable: false),
                    QRcashcode = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_qRCashCodeModelss", x => x.QRcashcodeid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bankselectmodelss");

            migrationBuilder.DropTable(
                name: "qRCashCodeModelss");

            migrationBuilder.DropColumn(
                name: "BankName",
                table: "bankdetailsModless");
        }
    }
}
