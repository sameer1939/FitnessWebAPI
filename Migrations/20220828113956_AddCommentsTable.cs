using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FitnessWebAPI.Migrations
{
    public partial class AddCommentsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Author = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    ParentId = table.Column<int>(nullable: true),
                    InsertedDate = table.Column<DateTime>(nullable: false),
                    InsertedBy = table.Column<int>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");
        }
    }
}
