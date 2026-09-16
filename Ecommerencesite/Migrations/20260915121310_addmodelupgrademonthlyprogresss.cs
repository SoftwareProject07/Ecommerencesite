using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerencesite.Migrations
{
    /// <inheritdoc />
    public partial class addmodelupgrademonthlyprogresss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Score",
                table: "MonthlyProgressModels");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "MonthlyProgressModels",
                newName: "AvgGlucose");

            migrationBuilder.RenameColumn(
                name: "Month",
                table: "MonthlyProgressModels",
                newName: "Notes");

            migrationBuilder.RenameColumn(
                name: "MetricName",
                table: "MonthlyProgressModels",
                newName: "MonthYear");

            migrationBuilder.AddColumn<string>(
                name: "BloodPressureStatus",
                table: "MonthlyProgressModels",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "RecordedDate",
                table: "MonthlyProgressModels",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "Weight",
                table: "MonthlyProgressModels",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BloodPressureStatus",
                table: "MonthlyProgressModels");

            migrationBuilder.DropColumn(
                name: "RecordedDate",
                table: "MonthlyProgressModels");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "MonthlyProgressModels");

            migrationBuilder.RenameColumn(
                name: "Notes",
                table: "MonthlyProgressModels",
                newName: "Month");

            migrationBuilder.RenameColumn(
                name: "MonthYear",
                table: "MonthlyProgressModels",
                newName: "MetricName");

            migrationBuilder.RenameColumn(
                name: "AvgGlucose",
                table: "MonthlyProgressModels",
                newName: "UserId");

            migrationBuilder.AddColumn<double>(
                name: "Score",
                table: "MonthlyProgressModels",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
