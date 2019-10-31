using Microsoft.EntityFrameworkCore.Migrations;

namespace BookApi.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookAH",
                columns: table => new
                {
                    ISBN_10 = table.Column<string>(maxLength: 40, nullable: false),
                    Title = table.Column<string>(nullable: true),
                    SmallThumbnail = table.Column<string>(nullable: true),
                    Authors = table.Column<string>(nullable: true),
                    Publisher = table.Column<string>(nullable: true),
                    PublishedDate = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAH", x => x.ISBN_10);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookAH");
        }
    }
}
