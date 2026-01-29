using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerencesite.Migrations
{
    /// <inheritdoc />
    public partial class neuwdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_patient_CustomerModels_userMediciness_UserId",
                table: "patient_CustomerModels");

            migrationBuilder.DropIndex(
                name: "IX_patient_CustomerModels_UserId",
                table: "patient_CustomerModels");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "patient_CustomerModels",
                newName: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "patient_CustomerModels",
                newName: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_patient_CustomerModels_UserId",
                table: "patient_CustomerModels",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_patient_CustomerModels_userMediciness_UserId",
                table: "patient_CustomerModels",
                column: "UserId",
                principalTable: "userMediciness",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
