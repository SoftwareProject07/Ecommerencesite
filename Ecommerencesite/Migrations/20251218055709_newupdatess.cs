using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerencesite.Migrations
{
    /// <inheritdoc />
    public partial class newupdatess : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_mediciness",
                table: "mediciness");

            migrationBuilder.RenameTable(
                name: "mediciness",
                newName: "medicines");

            migrationBuilder.AddPrimaryKey(
                name: "PK_medicines",
                table: "medicines",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_medicines",
                table: "medicines");

            migrationBuilder.RenameTable(
                name: "medicines",
                newName: "mediciness");

            migrationBuilder.AddPrimaryKey(
                name: "PK_mediciness",
                table: "mediciness",
                column: "id");
        }
    }
}
