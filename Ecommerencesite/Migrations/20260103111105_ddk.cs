using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerencesite.Migrations
{
    /// <inheritdoc />
    public partial class ddk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateOfBirth",
                table: "patient_CustomerModels",
                newName: "Gender");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "patient_CustomerModels",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "patient_CustomerModels");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "patient_CustomerModels",
                newName: "DateOfBirth");
        }
    }
}
