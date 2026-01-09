using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerencesite.Migrations
{
    /// <inheritdoc />
    public partial class newupdadd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfirmPassword",
                table: "userMediciness");

            migrationBuilder.DropColumn(
                name: "PhotoFileName",
                table: "userMediciness");

            migrationBuilder.AlterColumn<string>(
                name: "MobileNumber",
                table: "userMediciness",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MobileNumber",
                table: "userMediciness",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConfirmPassword",
                table: "userMediciness",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhotoFileName",
                table: "userMediciness",
                type: "text",
                nullable: true);
        }
    }
}
