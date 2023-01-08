using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TwojUrlop.DataAcess.Migrations
{
    public partial class UserStatusRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Status_StatusId",
                table: "User");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "User",
                type: "integer",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Status_StatusId",
                table: "User",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Status_StatusId",
                table: "User");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "User",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValue: 1);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Status_StatusId",
                table: "User",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id");
        }
    }
}
