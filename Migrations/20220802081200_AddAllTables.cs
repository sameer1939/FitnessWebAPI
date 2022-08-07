using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FitnessWebAPI.Migrations
{
    public partial class AddAllTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(nullable: false),
                    SubCategoryId = table.Column<int>(nullable: false),
                    HeadingName = table.Column<string>(nullable: true),
                    ShortArticle = table.Column<string>(nullable: true),
                    ArticleInEnglish = table.Column<string>(nullable: true),
                    ArticleInHindi = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Visible = table.Column<bool>(nullable: false),
                    InsertedDate = table.Column<DateTime>(nullable: false),
                    InsertedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_SubCategories_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_SubCategoryId",
                table: "Articles",
                column: "SubCategoryId");

           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");

           
        }
    }
}
