using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sklep.Data.Migrations
{
    public partial class D1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ElementKoszyka",
                columns: table => new
                {
                    IdElementuKoszyka = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSesjiKoszyka = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdTowaru = table.Column<int>(type: "int", nullable: false),
                    OgloszeniaIdOgloszenia = table.Column<int>(type: "int", nullable: false),
                    Ilosc = table.Column<int>(type: "int", nullable: false),
                    Cena = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataUtworzenia = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElementKoszyka", x => x.IdElementuKoszyka);
                    table.ForeignKey(
                        name: "FK_ElementKoszyka_Ogloszenia_OgloszeniaIdOgloszenia",
                        column: x => x.OgloszeniaIdOgloszenia,
                        principalTable: "Ogloszenia",
                        principalColumn: "IdOgloszenia",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ElementKoszyka_OgloszeniaIdOgloszenia",
                table: "ElementKoszyka",
                column: "OgloszeniaIdOgloszenia");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ElementKoszyka");
        }
    }
}
