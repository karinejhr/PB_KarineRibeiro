using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppChefIdentity.Data.Migrations
{
    public partial class AddReceita : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Receita",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Origem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TempoPreparo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NivelDificuldade = table.Column<int>(type: "int", nullable: false),
                    ImagemUri = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receita", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Receita");
        }
    }
}
