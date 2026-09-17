using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Ecommerencesite.Migrations
{
    /// <inheritdoc />
    public partial class newupatemodelsdatas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PrescriptionModels");

            migrationBuilder.RenameColumn(
                name: "PrescriptionUrl",
                table: "PrescriptionModels",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "DateIssued",
                table: "PrescriptionModels",
                newName: "PatientName");

            migrationBuilder.AddColumn<string>(
                name: "Diagnosis",
                table: "PrescriptionModels",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "PrescriptionDate",
                table: "PrescriptionModels",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "medicinedetailss",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PrescriptionModelId = table.Column<int>(type: "integer", nullable: false),
                    MedicineName = table.Column<string>(type: "text", nullable: false),
                    Dosage = table.Column<string>(type: "text", nullable: false),
                    Frequency = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicinedetailss", x => x.Id);
                    table.ForeignKey(
                        name: "FK_medicinedetailss_PrescriptionModels_PrescriptionModelId",
                        column: x => x.PrescriptionModelId,
                        principalTable: "PrescriptionModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_medicinedetailss_PrescriptionModelId",
                table: "medicinedetailss",
                column: "PrescriptionModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "medicinedetailss");

            migrationBuilder.DropColumn(
                name: "Diagnosis",
                table: "PrescriptionModels");

            migrationBuilder.DropColumn(
                name: "PrescriptionDate",
                table: "PrescriptionModels");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "PrescriptionModels",
                newName: "PrescriptionUrl");

            migrationBuilder.RenameColumn(
                name: "PatientName",
                table: "PrescriptionModels",
                newName: "DateIssued");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "PrescriptionModels",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
