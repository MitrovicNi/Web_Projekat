using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_Projekat.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Diskovi",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Film_na_disku = table.Column<int>(type: "int", nullable: false),
                    Clan_koji_je_pozajmio_disk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diskovi", x => x.ID);
                });

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

            migrationBuilder.CreateTable(
                name: "Clanovi",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Broj_clanske_karte = table.Column<int>(type: "int", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Datum_isteka_clanarine = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    DiskoviID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clanovi", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Clanovi_Diskovi_DiskoviID",
                        column: x => x.DiskoviID,
                        principalTable: "Diskovi",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Filmovi",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naslov = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Reziser = table.Column<int>(type: "int", nullable: false),
                    Tip = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Rejting = table.Column<int>(type: "int", nullable: false),
                    Godina = table.Column<int>(type: "int", nullable: false),
                    Nominacija_za_nagrade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Dobijene_nagrade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DiskoviID = table.Column<int>(type: "int", nullable: true),
                    UlogeID_filma = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmovi", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Filmovi_Diskovi_DiskoviID",
                        column: x => x.DiskoviID,
                        principalTable: "Diskovi",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Filmovi_Uloge_UlogeID_filma",
                        column: x => x.UlogeID_filma,
                        principalTable: "Uloge",
                        principalColumn: "ID_filma",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Glumci",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UlogeID_filma = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Glumci", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Glumci_Uloge_UlogeID_filma",
                        column: x => x.UlogeID_filma,
                        principalTable: "Uloge",
                        principalColumn: "ID_filma",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reziseri",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FilmID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reziseri", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Reziseri_Filmovi_FilmID",
                        column: x => x.FilmID,
                        principalTable: "Filmovi",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clanovi_DiskoviID",
                table: "Clanovi",
                column: "DiskoviID");

            migrationBuilder.CreateIndex(
                name: "IX_Filmovi_DiskoviID",
                table: "Filmovi",
                column: "DiskoviID");

            migrationBuilder.CreateIndex(
                name: "IX_Filmovi_UlogeID_filma",
                table: "Filmovi",
                column: "UlogeID_filma");

            migrationBuilder.CreateIndex(
                name: "IX_Glumci_UlogeID_filma",
                table: "Glumci",
                column: "UlogeID_filma");

            migrationBuilder.CreateIndex(
                name: "IX_Reziseri_FilmID",
                table: "Reziseri",
                column: "FilmID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clanovi");

            migrationBuilder.DropTable(
                name: "Glumci");

            migrationBuilder.DropTable(
                name: "Reziseri");

            migrationBuilder.DropTable(
                name: "Filmovi");

            migrationBuilder.DropTable(
                name: "Diskovi");

            migrationBuilder.DropTable(
                name: "Uloge");
        }
    }
}
