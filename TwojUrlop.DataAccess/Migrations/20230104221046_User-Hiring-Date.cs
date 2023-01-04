using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TwojUrlop.DataAcess.Migrations
{
    public partial class UserHiringDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "YearsOfWork",
                table: "User",
                newName: "NumberOfYearsWorkedOnHiringDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "HiringDate",
                table: "User",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HiringDate",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "NumberOfYearsWorkedOnHiringDate",
                table: "User",
                newName: "YearsOfWork");
        }
    }
}
