using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManagement.API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<Guid>(nullable: false),
                    StudentFirstName = table.Column<string>(maxLength: 50, nullable: false),
                    StudentLastName = table.Column<string>(maxLength: 50, nullable: false),
                    StudentDOB = table.Column<DateTime>(nullable: false),
                    StudentAddress = table.Column<string>(maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
