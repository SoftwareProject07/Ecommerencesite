using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerencesite.Migrations
{
    /// <inheritdoc />
    public partial class datatimeutc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreateOn",
                table: "userMediciness",
                newName: "CreatedOn");

            migrationBuilder.RenameColumn(
                name: "CreateOn",
                table: "adminREGMODELSs",
                newName: "CreatedOn");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "userMediciness",
                newName: "CreateOn");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "adminREGMODELSs",
                newName: "CreateOn");
        }
    }
}
