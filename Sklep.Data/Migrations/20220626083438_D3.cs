using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sklep.Data.Migrations
{
    public partial class D3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Telefon",
                table: "SprzedazSamochodu",
                type: "nvarchar(MAX)",
                maxLength: 12,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Telefon",
                table: "SprzedazSamochodu");
        }
    }
}
