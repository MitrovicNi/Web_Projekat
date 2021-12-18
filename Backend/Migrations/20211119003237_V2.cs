using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_Projekat.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filmovi_Uloge_UlogeID_filma",
                table: "Filmovi");

            migrationBuilder.DropForeignKey(
                name: "FK_Glumci_Uloge_UlogeID_filma",
                table: "Glumci");

            migrationBuilder.DropTable(
                name: "Uloge");

            migrationBuilder.DropIndex(
                name: "IX_Filmovi_UlogeID_filma",
                table: "Filmovi");

            migrationBuilder.DropColumn(
                name: "Reziser",
                table: "Filmovi");

            migrationBuilder.DropColumn(
                name: "UlogeID_filma",
                table: "Filmovi");

            migrationBuilder.RenameColumn(
                name: "UlogeID_filma",
                table: "Glumci",
                newName: "FilmID");

            migrationBuilder.RenameIndex(
                name: "IX_Glumci_UlogeID_filma",
                table: "Glumci",
                newName: "IX_Glumci_FilmID");

            migrationBuilder.AddColumn<string>(
                name: "Datum_rodjenja",
                table: "Reziseri",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mesto_rodjenja",
                table: "Reziseri",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Datum_rodjenja",
                table: "Glumci",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mesto_rodjenja",
                table: "Glumci",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Film_na_disku",
                table: "Diskovi",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Clan_koji_je_pozajmio_disk",
                table: "Diskovi",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Sifra_diska",
                table: "Diskovi",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Datum_isteka_clanarine",
                table: "Clanovi",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Glumci_Filmovi_FilmID",
                table: "Glumci",
                column: "FilmID",
                principalTable: "Filmovi",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Glumci_Filmovi_FilmID",
                table: "Glumci");

            migrationBuilder.DropColumn(
                name: "Datum_rodjenja",
                table: "Reziseri");

            migrationBuilder.DropColumn(
                name: "Mesto_rodjenja",
                table: "Reziseri");

            migrationBuilder.DropColumn(
                name: "Datum_rodjenja",
                table: "Glumci");

            migrationBuilder.DropColumn(
                name: "Mesto_rodjenja",
                table: "Glumci");

            migrationBuilder.DropColumn(
                name: "Sifra_diska",
                table: "Diskovi");

            migrationBuilder.RenameColumn(
                name: "FilmID",
                table: "Glumci",
                newName: "UlogeID_filma");

            migrationBuilder.RenameIndex(
                name: "IX_Glumci_FilmID",
                table: "Glumci",
                newName: "IX_Glumci_UlogeID_filma");

            migrationBuilder.AddColumn<int>(
                name: "Reziser",
                table: "Filmovi",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UlogeID_filma",
                table: "Filmovi",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Film_na_disku",
                table: "Diskovi",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Clan_koji_je_pozajmio_disk",
                table: "Diskovi",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Datum_isteka_clanarine",
                table: "Clanovi",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Uloge",
                columns: table => new
                {
                    ID_filma = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_glumca = table.Column<int>(type: "int", nullable: false),
                    Tip_uloge = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uloge", x => x.ID_filma);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Filmovi_UlogeID_filma",
                table: "Filmovi",
                column: "UlogeID_filma");

            migrationBuilder.AddForeignKey(
                name: "FK_Filmovi_Uloge_UlogeID_filma",
                table: "Filmovi",
                column: "UlogeID_filma",
                principalTable: "Uloge",
                principalColumn: "ID_filma",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Glumci_Uloge_UlogeID_filma",
                table: "Glumci",
                column: "UlogeID_filma",
                principalTable: "Uloge",
                principalColumn: "ID_filma",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
