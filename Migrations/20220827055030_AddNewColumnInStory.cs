using Microsoft.EntityFrameworkCore.Migrations;

namespace FitnessWebAPI.Migrations
{
    public partial class AddNewColumnInStory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Stories",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Stories");
        }
    }
}
