using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Ecommerencesite.Migrations
{
    /// <inheritdoc />
    public partial class newddd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserSettingsModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    EmailNotifications = table.Column<bool>(type: "boolean", nullable: false),
                    SmsNotifications = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSettingsModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DashboardDataModels",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    SettingsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DashboardDataModels", x => x.id);
                    table.ForeignKey(
                        name: "FK_DashboardDataModels_UserSettingsModels_SettingsId",
                        column: x => x.SettingsId,
                        principalTable: "UserSettingsModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AvailableTestModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TestName = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Category = table.Column<string>(type: "text", nullable: false),
                    DashboardDataModelid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailableTestModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvailableTestModels_DashboardDataModels_DashboardDataModelid",
                        column: x => x.DashboardDataModelid,
                        principalTable: "DashboardDataModels",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "BloodGlucoseDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userid = table.Column<int>(type: "integer", nullable: false),
                    DayLabel = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<double>(type: "double precision", nullable: false),
                    RecordDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DashboardDataModelid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodGlucoseDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BloodGlucoseDatas_DashboardDataModels_DashboardDataModelid",
                        column: x => x.DashboardDataModelid,
                        principalTable: "DashboardDataModels",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "BloodPressureDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Userid = table.Column<int>(type: "integer", nullable: false),
                    Category = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<double>(type: "double precision", nullable: false),
                    DashboardDataModelid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodPressureDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BloodPressureDatas_DashboardDataModels_DashboardDataModelid",
                        column: x => x.DashboardDataModelid,
                        principalTable: "DashboardDataModels",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Userid = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    DashboardDataModelid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.id);
                    table.ForeignKey(
                        name: "FK_CartItems_DashboardDataModels_DashboardDataModelid",
                        column: x => x.DashboardDataModelid,
                        principalTable: "DashboardDataModels",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "HealthHistoryModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Condition = table.Column<string>(type: "text", nullable: false),
                    DiagnosedDate = table.Column<string>(type: "text", nullable: false),
                    DoctorNotes = table.Column<string>(type: "text", nullable: false),
                    DashboardDataModelid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthHistoryModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HealthHistoryModels_DashboardDataModels_DashboardDataModelid",
                        column: x => x.DashboardDataModelid,
                        principalTable: "DashboardDataModels",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "HistoryModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ActivityType = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Timestamp = table.Column<string>(type: "text", nullable: false),
                    DashboardDataModelid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoryModels_DashboardDataModels_DashboardDataModelid",
                        column: x => x.DashboardDataModelid,
                        principalTable: "DashboardDataModels",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "MedicationTrackerModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    MedicineName = table.Column<string>(type: "text", nullable: false),
                    Dosage = table.Column<string>(type: "text", nullable: false),
                    Timing = table.Column<string>(type: "text", nullable: false),
                    IsTaken = table.Column<bool>(type: "boolean", nullable: false),
                    DashboardDataModelid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicationTrackerModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicationTrackerModels_DashboardDataModels_DashboardDataMo~",
                        column: x => x.DashboardDataModelid,
                        principalTable: "DashboardDataModels",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "MonthlyProgressModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Month = table.Column<string>(type: "text", nullable: false),
                    MetricName = table.Column<string>(type: "text", nullable: false),
                    Score = table.Column<double>(type: "double precision", nullable: false),
                    DashboardDataModelid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlyProgressModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MonthlyProgressModels_DashboardDataModels_DashboardDataMode~",
                        column: x => x.DashboardDataModelid,
                        principalTable: "DashboardDataModels",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "PrescriptionModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    DoctorName = table.Column<string>(type: "text", nullable: false),
                    DateIssued = table.Column<string>(type: "text", nullable: false),
                    PrescriptionUrl = table.Column<string>(type: "text", nullable: false),
                    DashboardDataModelid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrescriptionModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrescriptionModels_DashboardDataModels_DashboardDataModelid",
                        column: x => x.DashboardDataModelid,
                        principalTable: "DashboardDataModels",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "SupportTicketModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Subject = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<string>(type: "text", nullable: false),
                    DashboardDataModelid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportTicketModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupportTicketModels_DashboardDataModels_DashboardDataModelid",
                        column: x => x.DashboardDataModelid,
                        principalTable: "DashboardDataModels",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "TestReportModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    TestName = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<string>(type: "text", nullable: false),
                    ResultSummary = table.Column<string>(type: "text", nullable: false),
                    ReportFileUrl = table.Column<string>(type: "text", nullable: false),
                    DashboardDataModelid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestReportModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestReportModels_DashboardDataModels_DashboardDataModelid",
                        column: x => x.DashboardDataModelid,
                        principalTable: "DashboardDataModels",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "WeightProgressDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<string>(type: "text", nullable: false),
                    Weight = table.Column<double>(type: "double precision", nullable: false),
                    DashboardDataModelid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeightProgressDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeightProgressDatas_DashboardDataModels_DashboardDataModelid",
                        column: x => x.DashboardDataModelid,
                        principalTable: "DashboardDataModels",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AvailableTestModels_DashboardDataModelid",
                table: "AvailableTestModels",
                column: "DashboardDataModelid");

            migrationBuilder.CreateIndex(
                name: "IX_BloodGlucoseDatas_DashboardDataModelid",
                table: "BloodGlucoseDatas",
                column: "DashboardDataModelid");

            migrationBuilder.CreateIndex(
                name: "IX_BloodPressureDatas_DashboardDataModelid",
                table: "BloodPressureDatas",
                column: "DashboardDataModelid");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_DashboardDataModelid",
                table: "CartItems",
                column: "DashboardDataModelid");

            migrationBuilder.CreateIndex(
                name: "IX_DashboardDataModels_SettingsId",
                table: "DashboardDataModels",
                column: "SettingsId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthHistoryModels_DashboardDataModelid",
                table: "HealthHistoryModels",
                column: "DashboardDataModelid");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryModels_DashboardDataModelid",
                table: "HistoryModels",
                column: "DashboardDataModelid");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationTrackerModels_DashboardDataModelid",
                table: "MedicationTrackerModels",
                column: "DashboardDataModelid");

            migrationBuilder.CreateIndex(
                name: "IX_MonthlyProgressModels_DashboardDataModelid",
                table: "MonthlyProgressModels",
                column: "DashboardDataModelid");

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionModels_DashboardDataModelid",
                table: "PrescriptionModels",
                column: "DashboardDataModelid");

            migrationBuilder.CreateIndex(
                name: "IX_SupportTicketModels_DashboardDataModelid",
                table: "SupportTicketModels",
                column: "DashboardDataModelid");

            migrationBuilder.CreateIndex(
                name: "IX_TestReportModels_DashboardDataModelid",
                table: "TestReportModels",
                column: "DashboardDataModelid");

            migrationBuilder.CreateIndex(
                name: "IX_WeightProgressDatas_DashboardDataModelid",
                table: "WeightProgressDatas",
                column: "DashboardDataModelid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AvailableTestModels");

            migrationBuilder.DropTable(
                name: "BloodGlucoseDatas");

            migrationBuilder.DropTable(
                name: "BloodPressureDatas");

            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "HealthHistoryModels");

            migrationBuilder.DropTable(
                name: "HistoryModels");

            migrationBuilder.DropTable(
                name: "MedicationTrackerModels");

            migrationBuilder.DropTable(
                name: "MonthlyProgressModels");

            migrationBuilder.DropTable(
                name: "PrescriptionModels");

            migrationBuilder.DropTable(
                name: "SupportTicketModels");

            migrationBuilder.DropTable(
                name: "TestReportModels");

            migrationBuilder.DropTable(
                name: "WeightProgressDatas");

            migrationBuilder.DropTable(
                name: "DashboardDataModels");

            migrationBuilder.DropTable(
                name: "UserSettingsModels");
        }
    }
}
