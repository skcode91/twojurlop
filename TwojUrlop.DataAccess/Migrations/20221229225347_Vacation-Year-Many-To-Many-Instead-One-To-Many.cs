using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TwojUrlop.DataAcess.Migrations
{
    public partial class VacationYearManyToManyInsteadOneToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacation_Year_YearId",
                table: "Vacation");

            migrationBuilder.DropIndex(
                name: "IX_Vacation_YearId",
                table: "Vacation");

            migrationBuilder.DropColumn(
                name: "YearId",
                table: "Vacation");

            migrationBuilder.CreateTable(
                name: "VacationYear",
                columns: table => new
                {
                    VacationId = table.Column<int>(type: "integer", nullable: false),
                    YearId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacationYear", x => new { x.VacationId, x.YearId });
                    table.ForeignKey(
                        name: "FK_VacationYear_Vacation_VacationId",
                        column: x => x.VacationId,
                        principalTable: "Vacation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VacationYear_Year_YearId",
                        column: x => x.YearId,
                        principalTable: "Year",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VacationYear_YearId",
                table: "VacationYear",
                column: "YearId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VacationYear");

            migrationBuilder.AddColumn<int>(
                name: "YearId",
                table: "Vacation",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Vacation_YearId",
                table: "Vacation",
                column: "YearId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vacation_Year_YearId",
                table: "Vacation",
                column: "YearId",
                principalTable: "Year",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
