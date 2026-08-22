using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerencesite.Migrations
{
    /// <inheritdoc />
    public partial class newupdateupdatepatientdetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AssignedDeliveryPerson",
                table: "patient_CustomerModels",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AssignedDoctor",
                table: "patient_CustomerModels",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssignedDeliveryPerson",
                table: "patient_CustomerModels");

            migrationBuilder.DropColumn(
                name: "AssignedDoctor",
                table: "patient_CustomerModels");
        }
    }
}
