using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerencesite.Migrations
{
    /// <inheritdoc />
    public partial class updatecode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DoctorAssignto",
                table: "patientDetailsModels",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DoctorType",
                table: "doctorAssigntoPatientMOdels",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DoctorAssignto",
                table: "patientDetailsModels");

            migrationBuilder.DropColumn(
                name: "DoctorType",
                table: "doctorAssigntoPatientMOdels");
        }
    }
}
