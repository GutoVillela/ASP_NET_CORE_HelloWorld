using Microsoft.EntityFrameworkCore.Migrations;

namespace HelloWorld.Migrations
{
    public partial class PrimeiroMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carros",
                columns: table => new
                {
                    CarroId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(nullable: true),
                    Modelo = table.Column<string>(nullable: true),
                    Ano = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carros", x => x.CarroId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carros");
        }
    }
}
