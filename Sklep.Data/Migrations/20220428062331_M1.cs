using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sklep.Data.Migrations
{
    public partial class M1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ciekawostki",
                columns: table => new
                {
                    IdCiekawostki = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinkTytul = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Tytul = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Tresc = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Zdjecie = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Pozycja = table.Column<string>(type: "nvarchar(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciekawostki", x => x.IdCiekawostki);
                });

            migrationBuilder.CreateTable(
                name: "Parametry",
                columns: table => new
                {
                    IdParametru = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kod = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Nazwa = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Wartosc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parametry", x => x.IdParametru);
                });

            migrationBuilder.CreateTable(
                name: "Rodzaj",
                columns: table => new
                {
                    IdRodzaju = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rodzaj", x => x.IdRodzaju);
                });

            migrationBuilder.CreateTable(
                name: "SprzedazSamochodu",
                columns: table => new
                {
                    IdSprzedazy = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marka = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    KrajPochodzenia = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Przebieg = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Cena = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Lokalizacja = table.Column<string>(type: "nvarchar(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SprzedazSamochodu", x => x.IdSprzedazy);
                });

            migrationBuilder.CreateTable(
                name: "Strona",
                columns: table => new
                {
                    IdStrona = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinkTytul = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Tytul = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    TablicaOgloszen = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    CiekawostkiMotoryzacja = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InformacjeMotoryzacja = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pozycja = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Strona", x => x.IdStrona);
                });

            migrationBuilder.CreateTable(
                name: "Wyniki",
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
                    table.PrimaryKey("PK_Wyniki", x => x.IdWyniku);
                });

            migrationBuilder.CreateTable(
                name: "Ogloszenia",
                columns: table => new
                {
                    IdOgloszenia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cena = table.Column<decimal>(type: "money", nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdRodzaju = table.Column<int>(type: "int", nullable: false),
                    RodzajIdRodzaju = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ogloszenia", x => x.IdOgloszenia);
                    table.ForeignKey(
                        name: "FK_Ogloszenia_Rodzaj_RodzajIdRodzaju",
                        column: x => x.RodzajIdRodzaju,
                        principalTable: "Rodzaj",
                        principalColumn: "IdRodzaju",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ogloszenia_RodzajIdRodzaju",
                table: "Ogloszenia",
                column: "RodzajIdRodzaju");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ciekawostki");

            migrationBuilder.DropTable(
                name: "Ogloszenia");

            migrationBuilder.DropTable(
                name: "Parametry");

            migrationBuilder.DropTable(
                name: "SprzedazSamochodu");

            migrationBuilder.DropTable(
                name: "Strona");

            migrationBuilder.DropTable(
                name: "Wyniki");

            migrationBuilder.DropTable(
                name: "Rodzaj");
        }
    }
}
