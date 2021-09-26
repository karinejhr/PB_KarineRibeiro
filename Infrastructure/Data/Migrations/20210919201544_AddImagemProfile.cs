using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppChefIdentity.Data.Migrations
{
    public partial class AddImagemProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UriImage",
                table: "Profile",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UriImage",
                table: "Profile");
        }
    }
}
