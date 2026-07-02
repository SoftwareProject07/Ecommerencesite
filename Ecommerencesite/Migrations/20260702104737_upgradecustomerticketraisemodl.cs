using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerencesite.Migrations
{
    /// <inheritdoc />
    public partial class upgradecustomerticketraisemodl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IssueType",
                table: "CustomerTicketRaise",
                newName: "TicketNumber");

            migrationBuilder.RenameColumn(
                name: "EmployeeName",
                table: "CustomerTicketRaise",
                newName: "OrderId");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "CustomerTicketRaise",
                newName: "MedicineName");

            migrationBuilder.RenameColumn(
                name: "Department",
                table: "CustomerTicketRaise",
                newName: "IssueCategory");

            migrationBuilder.AddColumn<string>(
                name: "CustomerId",
                table: "CustomerTicketRaise",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "CustomerTicketRaise",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "CustomerTicketRaise",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "CustomerTicketRaise");

            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "CustomerTicketRaise");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "CustomerTicketRaise");

            migrationBuilder.RenameColumn(
                name: "TicketNumber",
                table: "CustomerTicketRaise",
                newName: "IssueType");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "CustomerTicketRaise",
                newName: "EmployeeName");

            migrationBuilder.RenameColumn(
                name: "MedicineName",
                table: "CustomerTicketRaise",
                newName: "EmployeeId");

            migrationBuilder.RenameColumn(
                name: "IssueCategory",
                table: "CustomerTicketRaise",
                newName: "Department");
        }
    }
}
