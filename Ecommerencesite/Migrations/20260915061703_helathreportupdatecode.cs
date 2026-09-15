using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerencesite.Migrations
{
    /// <inheritdoc />
    public partial class helathreportupdatecode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Condition",
                table: "HealthHistoryModels");

            migrationBuilder.DropColumn(
                name: "DiagnosedDate",
                table: "HealthHistoryModels");

            migrationBuilder.DropColumn(
                name: "DoctorNotes",
                table: "HealthHistoryModels");

            migrationBuilder.AddColumn<string>(
                name: "ConditionName",
                table: "HealthHistoryModels",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "HealthHistoryModels",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "HealthHistoryModels",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DiagnosisDate",
                table: "HealthHistoryModels",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "HealthHistoryModels",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TreatingDoctor",
                table: "HealthHistoryModels",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConditionName",
                table: "HealthHistoryModels");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "HealthHistoryModels");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "HealthHistoryModels");

            migrationBuilder.DropColumn(
                name: "DiagnosisDate",
                table: "HealthHistoryModels");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "HealthHistoryModels");

            migrationBuilder.DropColumn(
                name: "TreatingDoctor",
                table: "HealthHistoryModels");

            migrationBuilder.AddColumn<string>(
                name: "Condition",
                table: "HealthHistoryModels",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DiagnosedDate",
                table: "HealthHistoryModels",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DoctorNotes",
                table: "HealthHistoryModels",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
