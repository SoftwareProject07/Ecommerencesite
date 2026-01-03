using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerencesite.Migrations
{
    /// <inheritdoc />
    public partial class needld : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "patient_CustomerModels");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "patient_CustomerModels");

            migrationBuilder.RenameColumn(
                name: "MiddleName",
                table: "patient_CustomerModels",
                newName: "FullNmae");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullNmae",
                table: "patient_CustomerModels",
                newName: "MiddleName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "patient_CustomerModels",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "patient_CustomerModels",
                type: "text",
                nullable: true);
        }
    }
}
