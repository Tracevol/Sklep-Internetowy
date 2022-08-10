using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sklep.Data.Migrations
{
    public partial class M10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DTM",
                columns: table => new
                {
                    IdWyniku = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PozycjaKierowcy = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    ImieNazwisko = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Zespol = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Punkty = table.Column<string>(type: "nvarchar(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DTM", x => x.IdWyniku);
                });

            migrationBuilder.CreateTable(
                name: "Endurance",
                columns: table => new
                {
                    IdWyniku = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PozycjaKierowcy = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    ImieNazwisko = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Zespol = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Punkty = table.Column<string>(type: "nvarchar(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endurance", x => x.IdWyniku);
                });

            migrationBuilder.CreateTable(
                name: "FormulaE",
                columns: table => new
                {
                    IdWyniku = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PozycjaKierowcy = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    ImieNazwisko = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Zespol = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Punkty = table.Column<string>(type: "nvarchar(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormulaE", x => x.IdWyniku);
                });

            migrationBuilder.CreateTable(
                name: "IndyCar",
                columns: table => new
                {
                    IdWyniku = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PozycjaKierowcy = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    ImieNazwisko = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Zespol = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Punkty = table.Column<string>(type: "nvarchar(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndyCar", x => x.IdWyniku);
                });

            migrationBuilder.CreateTable(
                name: "WynikiF2",
                columns: table => new
                {
                    IdWyniku = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PozycjaKierowcy = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    ImieNazwisko = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Zespol = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Punkty = table.Column<string>(type: "nvarchar(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WynikiF2", x => x.IdWyniku);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DTM");

            migrationBuilder.DropTable(
                name: "Endurance");

            migrationBuilder.DropTable(
                name: "FormulaE");

            migrationBuilder.DropTable(
                name: "IndyCar");

            migrationBuilder.DropTable(
                name: "WynikiF2");
        }
    }
}
