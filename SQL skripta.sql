INSERT into [VideoKlubDB].[dbo].[Filmovi] (Naslov, Tip, Rejting, Godina, Nominacija_za_nagrade, Dobijene nagrade) VALUES ('Film1', 'akcioni', 9, 2018, 'Oskar', 'Zlatna Palma');
INSERT into [VideoKlubDB].[dbo].[Filmovi] (Naslov, Tip, Rejting, Godina, Nominacija_za_nagrade, Dobijene nagrade) VALUES ('Film2', 'triler', 8, 2020, 'nema', 'nema');

INSERT into [VideoKlubDB].[dbo].[Glumci] (Ime, Prezime, FilmID, Datum_rodjenja, Mesto_rodjenja) VALUES ('Marko', 'Markovic', 14, '10.03.1990', 'Novi Sad');
INSERT into [VideoKlubDB].[dbo].[Glumci] (Ime, Prezime, FilmID, Datum_rodjenja, Mesto_rodjenja) VALUES ('Milan', 'Milic', 15, '06.07.1993', 'Prokuplje');

INSERT into [VideoKlubDB].[dbo].[Reziseri] (Ime, Prezime, FilmID, Datum_rodjenja, Mesto_rodjenja) VALUES ('Petar', 'Petrovic', 14, '22.11.1971', 'Beograd');
INSERT into [VideoKlubDB].[dbo].[Reziseri] (Ime, Prezime, FilmID, Datum_rodjenja, Mesto_rodjenja) VALUES ('Pavle', 'Pavic', 15, '15.09.1980', 'Nis');

INSERT into [VideoKlubDB].[dbo].[Clanovi] (Broj_clanske_karte, Ime, Prezime, Datum_isteka_clanarine) VALUES (123, 'Nikola', 'Nikolic', '2022-07-22');
INSERT into [VideoKlubDB].[dbo].[Clanovi] (Broj_clanske_karte, Ime, Prezime, Datum_isteka_clanarine) VALUES (345, 'Stefan', 'Stefanovic', '2022-08-18');

INSERT into [VideoKlubDB].[dbo].[Diskovi] (Film_na_diksu, Broj_diskova) VALUES ('Film1', 15);
INSERT into [VideoKlubDB].[dbo].[Diskovi] (Film_na_diksu, Broj_diskova) VALUES ('Film2', 9);