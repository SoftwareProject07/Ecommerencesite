using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerencesite.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_cartss_UserId",
                table: "cartss",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_cartss_userMediciness_UserId",
                table: "cartss",
                column: "UserId",
                principalTable: "userMediciness",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cartss_userMediciness_UserId",
                table: "cartss");

            migrationBuilder.DropIndex(
                name: "IX_cartss_UserId",
                table: "cartss");
        }
    }
}
