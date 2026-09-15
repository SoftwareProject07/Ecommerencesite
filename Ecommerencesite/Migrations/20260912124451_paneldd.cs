using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Ecommerencesite.Migrations
{
    /// <inheritdoc />
    public partial class paneldd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medicationss");

            migrationBuilder.DropTable(
                name: "TestReportModels");

            migrationBuilder.DropColumn(
                name: "IsTaken",
                table: "MedicationTrackerModels");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MedicationTrackerModels");

            migrationBuilder.RenameColumn(
                name: "Timing",
                table: "MedicationTrackerModels",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "MedicineName",
                table: "MedicationTrackerModels",
                newName: "MedicationName");

            migrationBuilder.AddColumn<int>(
                name: "DashboardDataModelid",
                table: "TestReports",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "MedicationTrackerModels",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Frequency",
                table: "MedicationTrackerModels",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "MedicationTrackerModels",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TestReports_DashboardDataModelid",
                table: "TestReports",
                column: "DashboardDataModelid");

            migrationBuilder.AddForeignKey(
                name: "FK_TestReports_DashboardDataModels_DashboardDataModelid",
                table: "TestReports",
                column: "DashboardDataModelid",
                principalTable: "DashboardDataModels",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestReports_DashboardDataModels_DashboardDataModelid",
                table: "TestReports");

            migrationBuilder.DropIndex(
                name: "IX_TestReports_DashboardDataModelid",
                table: "TestReports");

            migrationBuilder.DropColumn(
                name: "DashboardDataModelid",
                table: "TestReports");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "MedicationTrackerModels");

            migrationBuilder.DropColumn(
                name: "Frequency",
                table: "MedicationTrackerModels");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "MedicationTrackerModels");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "MedicationTrackerModels",
                newName: "Timing");

            migrationBuilder.RenameColumn(
                name: "MedicationName",
                table: "MedicationTrackerModels",
                newName: "MedicineName");

            migrationBuilder.AddColumn<bool>(
                name: "IsTaken",
                table: "MedicationTrackerModels",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "MedicationTrackerModels",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Medicationss",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Dosage = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Frequency = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    MedicationName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicationss", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestReportModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DashboardDataModelid = table.Column<int>(type: "integer", nullable: true),
                    Date = table.Column<string>(type: "text", nullable: false),
                    ReportFileUrl = table.Column<string>(type: "text", nullable: false),
                    ResultSummary = table.Column<string>(type: "text", nullable: false),
                    TestName = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestReportModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestReportModels_DashboardDataModels_DashboardDataModelid",
                        column: x => x.DashboardDataModelid,
                        principalTable: "DashboardDataModels",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestReportModels_DashboardDataModelid",
                table: "TestReportModels",
                column: "DashboardDataModelid");
        }
    }
}
