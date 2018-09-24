using Microsoft.EntityFrameworkCore.Migrations;

namespace w3.Migrations
{
    public partial class database3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "notes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    title = table.Column<string>(nullable: true),
                    text = table.Column<string>(nullable: true),
                    type = table.Column<string>(nullable: true),
                    favourite = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notes", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "notes");
        }
    }
}
