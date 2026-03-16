using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Ecommerencesite.Migrations
{
    /// <inheritdoc />
    public partial class updateaddmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StatusRemarks",
                table: "userMediciness",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "customerAddMedicineModels",
                columns: table => new
                {
                    CustomerAddMedicineModelId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerName = table.Column<string>(type: "text", nullable: true),
                    MedicineName = table.Column<string>(type: "text", nullable: true),
                    MedicineDescription = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customerAddMedicineModels", x => x.CustomerAddMedicineModelId);
                });

            migrationBuilder.CreateTable(
                name: "customerHelpIssueModels",
                columns: table => new
                {
                    customerhelpissueid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerHelpName = table.Column<string>(type: "text", nullable: true),
                    CustomerHelpEmail = table.Column<string>(type: "text", nullable: true),
                    CustomerHelpMessage = table.Column<string>(type: "text", nullable: true),
                    CustomerHelpStatus = table.Column<string>(type: "text", nullable: true),
                    MobileNumber = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customerHelpIssueModels", x => x.customerhelpissueid);
                });

            migrationBuilder.CreateTable(
                name: "feedbackCusotmerModels",
                columns: table => new
                {
                    Freedbackcustomerid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Message = table.Column<string>(type: "text", nullable: true),
                    starStatus = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feedbackCusotmerModels", x => x.Freedbackcustomerid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customerAddMedicineModels");

            migrationBuilder.DropTable(
                name: "customerHelpIssueModels");

            migrationBuilder.DropTable(
                name: "feedbackCusotmerModels");

            migrationBuilder.DropColumn(
                name: "StatusRemarks",
                table: "userMediciness");
        }
    }
}
