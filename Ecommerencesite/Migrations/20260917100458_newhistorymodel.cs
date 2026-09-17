using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerencesite.Migrations
{
    /// <inheritdoc />
    public partial class newhistorymodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "HistoryModels");

            migrationBuilder.RenameColumn(
                name: "Timestamp",
                table: "HistoryModels",
                newName: "IpAddress");

            migrationBuilder.RenameColumn(
                name: "ActivityType",
                table: "HistoryModels",
                newName: "ActionType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IpAddress",
                table: "HistoryModels",
                newName: "Timestamp");

            migrationBuilder.RenameColumn(
                name: "ActionType",
                table: "HistoryModels",
                newName: "ActivityType");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "HistoryModels",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
