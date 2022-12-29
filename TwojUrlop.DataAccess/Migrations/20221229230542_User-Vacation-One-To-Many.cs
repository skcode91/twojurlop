using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TwojUrlop.DataAcess.Migrations
{
    public partial class UserVacationOneToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserVacation");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Vacation",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Vacation_UserId",
                table: "Vacation",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vacation_User_UserId",
                table: "Vacation",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacation_User_UserId",
                table: "Vacation");

            migrationBuilder.DropIndex(
                name: "IX_Vacation_UserId",
                table: "Vacation");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Vacation");

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
        }
    }
}
