﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Models;

namespace Web_Projekat.Migrations
{
    [DbContext(typeof(VideoKlubContext))]
    [Migration("20211119003910_V3")]
    partial class V3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Models.Clanovi", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Broj_clanske_karte")
                        .HasColumnType("int");

                    b.Property<string>("Datum_isteka_clanarine")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int?>("DiskoviID")
                        .HasColumnType("int");

                    b.Property<string>("Ime")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Prezime")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.HasIndex("DiskoviID");

                    b.ToTable("Clanovi");
                });

            modelBuilder.Entity("Models.Diskovi", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Clan_koji_je_pozajmio_disk")
                        .HasColumnType("int");

                    b.Property<string>("Film_na_disku")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sifra_diska")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Diskovi");
                });

            modelBuilder.Entity("Models.Film", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DiskoviID")
                        .HasColumnType("int");

                    b.Property<string>("Dobijene_nagrade")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Godina")
                        .HasColumnType("int");

                    b.Property<string>("Naslov")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nominacija_za_nagrade")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Rejting")
                        .HasColumnType("int");

                    b.Property<string>("Tip")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.HasIndex("DiskoviID");

                    b.ToTable("Filmovi");
                });

            modelBuilder.Entity("Models.Glumci", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Datum_rodjenja")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int?>("FilmID")
                        .HasColumnType("int");

                    b.Property<string>("Ime")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Mesto_rodjenja")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Prezime")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.HasIndex("FilmID");

                    b.ToTable("Glumci");
                });

            modelBuilder.Entity("Models.Reziseri", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Datum_rodjenja")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int?>("FilmID")
                        .HasColumnType("int");

                    b.Property<string>("Ime")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Mesto_rodjenja")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Prezime")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.HasIndex("FilmID");

                    b.ToTable("Reziseri");
                });

            modelBuilder.Entity("Models.Clanovi", b =>
                {
                    b.HasOne("Models.Diskovi", "Diskovi")
                        .WithMany("Clanovi")
                        .HasForeignKey("DiskoviID");

                    b.Navigation("Diskovi");
                });

            modelBuilder.Entity("Models.Film", b =>
                {
                    b.HasOne("Models.Diskovi", "Diskovi")
                        .WithMany("Filmovi")
                        .HasForeignKey("DiskoviID");

                    b.Navigation("Diskovi");
                });

            modelBuilder.Entity("Models.Glumci", b =>
                {
                    b.HasOne("Models.Film", "Film")
                        .WithMany("Glumci")
                        .HasForeignKey("FilmID");

                    b.Navigation("Film");
                });

            modelBuilder.Entity("Models.Reziseri", b =>
                {
                    b.HasOne("Models.Film", "Film")
                        .WithMany("Reziseri")
                        .HasForeignKey("FilmID");

                    b.Navigation("Film");
                });

            modelBuilder.Entity("Models.Diskovi", b =>
                {
                    b.Navigation("Clanovi");

                    b.Navigation("Filmovi");
                });

            modelBuilder.Entity("Models.Film", b =>
                {
                    b.Navigation("Glumci");

                    b.Navigation("Reziseri");
                });
#pragma warning restore 612, 618
        }
    }
}
