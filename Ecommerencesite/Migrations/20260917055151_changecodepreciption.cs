using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerencesite.Migrations
{
    /// <inheritdoc />
    public partial class changecodepreciption : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_medicinedetailss_PrescriptionModels_PrescriptionModelId",
                table: "medicinedetailss");

            migrationBuilder.AlterColumn<int>(
                name: "PrescriptionModelId",
                table: "medicinedetailss",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_medicinedetailss_PrescriptionModels_PrescriptionModelId",
                table: "medicinedetailss",
                column: "PrescriptionModelId",
                principalTable: "PrescriptionModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_medicinedetailss_PrescriptionModels_PrescriptionModelId",
                table: "medicinedetailss");

            migrationBuilder.AlterColumn<int>(
                name: "PrescriptionModelId",
                table: "medicinedetailss",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_medicinedetailss_PrescriptionModels_PrescriptionModelId",
                table: "medicinedetailss",
                column: "PrescriptionModelId",
                principalTable: "PrescriptionModels",
                principalColumn: "Id");
        }
    }
}
