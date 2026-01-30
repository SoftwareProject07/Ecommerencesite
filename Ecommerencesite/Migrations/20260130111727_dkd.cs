using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerencesite.Migrations
{
    /// <inheritdoc />
    public partial class dkd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "patient_CustomerModels");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsersId",
                table: "patient_CustomerModels",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
