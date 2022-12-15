using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TwojUrlop.DataAcess.Migrations
{
    public partial class mainmodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "YearsOfWork",
                table: "User",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "VacationRequestStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Value = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacationRequestStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VacationSize",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Value = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacationSize", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Year",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Value = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Year", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VacationRequest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DaysCount = table.Column<int>(type: "integer", nullable: false),
                    StatusId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacationRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VacationRequest_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VacationRequest_VacationRequestStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "VacationRequestStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserVacationInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    YearId = table.Column<int>(type: "integer", nullable: false),
                    DaysLeft = table.Column<int>(type: "integer", nullable: false),
                    VacationSizeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserVacationInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserVacationInfo_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserVacationInfo_VacationSize_VacationSizeId",
                        column: x => x.VacationSizeId,
                        principalTable: "VacationSize",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserVacationInfo_Year_YearId",
                        column: x => x.YearId,
                        principalTable: "Year",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vacation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DaysCount = table.Column<int>(type: "integer", nullable: false),
                    YearId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vacation_Year_YearId",
                        column: x => x.YearId,
                        principalTable: "Year",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VacationRequestYear",
                columns: table => new
                {
                    VacationRequestId = table.Column<int>(type: "integer", nullable: false),
                    YearId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacationRequestYear", x => new { x.VacationRequestId, x.YearId });
                    table.ForeignKey(
                        name: "FK_VacationRequestYear_VacationRequest_VacationRequestId",
                        column: x => x.VacationRequestId,
                        principalTable: "VacationRequest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VacationRequestYear_Year_YearId",
                        column: x => x.YearId,
                        principalTable: "Year",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserVacation",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    VacationId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserVacation", x => new { x.UserId, x.VacationId });
                    table.ForeignKey(
                        name: "FK_UserVacation_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserVacation_Vacation_VacationId",
                        column: x => x.VacationId,
                        principalTable: "Vacation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserVacation_VacationId",
                table: "UserVacation",
                column: "VacationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserVacationInfo_UserId",
                table: "UserVacationInfo",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserVacationInfo_VacationSizeId",
                table: "UserVacationInfo",
                column: "VacationSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserVacationInfo_YearId",
                table: "UserVacationInfo",
                column: "YearId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacation_YearId",
                table: "Vacation",
                column: "YearId");

            migrationBuilder.CreateIndex(
                name: "IX_VacationRequest_StatusId",
                table: "VacationRequest",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_VacationRequest_UserId",
                table: "VacationRequest",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_VacationRequestYear_YearId",
                table: "VacationRequestYear",
                column: "YearId");

            migrationBuilder.CreateIndex(
                name: "IX_Year_Value",
                table: "Year",
                column: "Value",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserVacation");

            migrationBuilder.DropTable(
                name: "UserVacationInfo");

            migrationBuilder.DropTable(
                name: "VacationRequestYear");

            migrationBuilder.DropTable(
                name: "Vacation");

            migrationBuilder.DropTable(
                name: "VacationSize");

            migrationBuilder.DropTable(
                name: "VacationRequest");

            migrationBuilder.DropTable(
                name: "Year");

            migrationBuilder.DropTable(
                name: "VacationRequestStatus");

            migrationBuilder.DropColumn(
                name: "YearsOfWork",
                table: "User");
        }
    }
}
