using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sklep.Data.Migrations
{
    public partial class D2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdTowaru",
                table: "ElementKoszyka",
                newName: "IdOgloszenia");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdOgloszenia",
                table: "ElementKoszyka",
                newName: "IdTowaru");
        }
    }
}
