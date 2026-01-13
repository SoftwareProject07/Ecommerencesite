using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerencesite.Migrations
{
    /// <inheritdoc />
    public partial class addpatientdetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullNmae",
                table: "patient_CustomerModels",
                newName: "FullName");

            migrationBuilder.AddColumn<string>(
                name: "CustomerAddress",
                table: "patient_CustomerModels",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerCity",
                table: "patient_CustomerModels",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerCountry",
                table: "patient_CustomerModels",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerState",
                table: "patient_CustomerModels",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerZipCode",
                table: "patient_CustomerModels",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerAddress",
                table: "patient_CustomerModels");

            migrationBuilder.DropColumn(
                name: "CustomerCity",
                table: "patient_CustomerModels");

            migrationBuilder.DropColumn(
                name: "CustomerCountry",
                table: "patient_CustomerModels");

            migrationBuilder.DropColumn(
                name: "CustomerState",
                table: "patient_CustomerModels");

            migrationBuilder.DropColumn(
                name: "CustomerZipCode",
                table: "patient_CustomerModels");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "patient_CustomerModels",
                newName: "FullNmae");
        }
    }
}
