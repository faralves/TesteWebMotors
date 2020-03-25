using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteWebMotors.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_AnuncioWebmotors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(nullable: true),
                    Modelo = table.Column<string>(nullable: true),
                    Versao = table.Column<string>(nullable: true),
                    Ano = table.Column<int>(nullable: false),
                    Quilometragem = table.Column<int>(nullable: false),
                    Observacao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_AnuncioWebmotors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_Marca",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                        //.Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Marca", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_Modelo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                        //.Annotation("SqlServer:Identity", "1, 1"),
                    MakeId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Modelo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_veiculo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                        //.Annotation("SqlServer:Identity", "1, 1"),
                    Make = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Version = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    KM = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    YearModel = table.Column<int>(nullable: false),
                    YearFab = table.Column<int>(nullable: false),
                    Color = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_veiculo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_versao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                        //.Annotation("SqlServer:Identity", "1, 1"),
                    ModelId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_versao", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_AnuncioWebmotors");

            migrationBuilder.DropTable(
                name: "tb_Marca");

            migrationBuilder.DropTable(
                name: "tb_Modelo");

            migrationBuilder.DropTable(
                name: "tb_veiculo");

            migrationBuilder.DropTable(
                name: "tb_versao");
        }
    }
}
