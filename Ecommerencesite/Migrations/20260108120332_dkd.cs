using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerencesite.Migrations
{
    /// <inheritdoc />
    public partial class dkd : Migration
    {
        /// <inheritdoc />
        /// 
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoFileName",
                table: "userMediciness",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "userMediciness",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoFileName",
                table: "userMediciness");

            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "userMediciness");
        }
    }
}
