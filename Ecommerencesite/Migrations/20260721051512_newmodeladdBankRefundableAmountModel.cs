using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Ecommerencesite.Migrations
{
    /// <inheritdoc />
    public partial class newmodeladdBankRefundableAmountModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BankRefundableAmountModels",
                columns: table => new
                {
                    BankRefundableAmountid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Bank_CustomerName = table.Column<string>(type: "text", nullable: true),
                    BankRefundableAmount = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    BankRefundableAmountStatus = table.Column<bool>(type: "boolean", nullable: true),
                    BankName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    BankAccountNumber = table.Column<string>(type: "text", nullable: false),
                    BankIFSCCode = table.Column<string>(type: "text", nullable: false),
                    BankBranchName = table.Column<string>(type: "text", nullable: true),
                    BankBranchAddress = table.Column<string>(type: "text", nullable: true),
                    BankBranchCity = table.Column<string>(type: "text", nullable: true),
                    BankBranchState = table.Column<string>(type: "text", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankRefundableAmountModels", x => x.BankRefundableAmountid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankRefundableAmountModels");
        }
    }
}
