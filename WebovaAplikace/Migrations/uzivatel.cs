using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebovaAplikace.Migrations
{
    public partial class uzivatel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Heslo",
                table: "Pristup",
                newName: "Uzivatel");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Pristup",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Pristup");

            migrationBuilder.RenameColumn(
                name: "Uzivatel",
                table: "Pristup",
                newName: "Heslo");
        }
    }
}
