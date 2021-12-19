using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_Projekat.Migrations
{
    public partial class V4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Clan_koji_je_pozajmio_disk",
                table: "Diskovi");

            migrationBuilder.RenameColumn(
                name: "Sifra_diska",
                table: "Diskovi",
                newName: "Broj_diskova");

            migrationBuilder.AlterColumn<string>(
                name: "Film_na_disku",
                table: "Diskovi",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Datum_iznajmljivanja_diska",
                table: "Diskovi",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Datum_vracanja_diska",
                table: "Diskovi",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Datum_iznajmljivanja_diska",
                table: "Diskovi");

            migrationBuilder.DropColumn(
                name: "Datum_vracanja_diska",
                table: "Diskovi");

            migrationBuilder.RenameColumn(
                name: "Broj_diskova",
                table: "Diskovi",
                newName: "Sifra_diska");

            migrationBuilder.AlterColumn<string>(
                name: "Film_na_disku",
                table: "Diskovi",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Clan_koji_je_pozajmio_disk",
                table: "Diskovi",
                type: "int",
                nullable: true);
        }
    }
}
