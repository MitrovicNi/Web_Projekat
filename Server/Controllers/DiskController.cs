using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Web_Projekat.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DiskController : ControllerBase
    {
       public VideoKlubContext Context { get; set; }
       public DiskController(VideoKlubContext context)
        {
            Context=context;
        }
        [Route("PreuzmiBrojDiskova/{film}")]
        [HttpGet]
        public async Task<ActionResult> PreuzmiDisk(string film)
        {
            try
            {
                var diskovi=Context.Diskovi.Where(p => p.Film_na_disku==film);
                var disk= await diskovi.ToListAsync();
                return Ok
                (
                    disk.Select(p =>
                    new 
                    {
                        Broj_diskova=p.Broj_diskova,
                    }).FirstOrDefault()
                );
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("DodatiDisk")]
        [HttpPost]
        public async Task<ActionResult> DodatiDisk([FromBody] Diskovi disk)
        {
            if(string.IsNullOrWhiteSpace(disk.Film_na_disku) || disk.Film_na_disku.Length>50)
            {
                return BadRequest("Pogrešan film na disku!");
            }
            
            if(disk.Broj_diskova<1 || disk.Broj_diskova>30)
            {
                return BadRequest("Pogrešan broj diskova!");
            }
            try
            {
                Context.Diskovi.Add(disk);
                await Context.SaveChangesAsync();
                return Ok($"Disk je dodat! Film na disku je: {disk.Film_na_disku}");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("PromenaDiska")]
        [HttpPut]
        public async Task<ActionResult> PromenitiDisk([FromBody] Diskovi disk)
        {
           if(string.IsNullOrWhiteSpace(disk.Film_na_disku) || disk.Film_na_disku.Length>50)
            {
                return BadRequest("Pogrešan film na disku!");
            }
            
            if(disk.Broj_diskova<1 || disk.Broj_diskova>30)
            {
                return BadRequest("Pogrešan broj diskova!");
            }
            try
            {
                Context.Diskovi.Update(disk);
                await Context.SaveChangesAsync();
                return Ok($"Disk sa filmom: {disk.Film_na_disku} je uspešno izmenjen!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("Pozajmidisk/{film}/{broj_clanske_karte}/{datum_iznajmljivanja}/{datum_vracanja}")]
        [HttpPut]
        public async Task<ActionResult> PozajmiDisk(string film,int broj_clanske_karte,string datum_iznajmljivanja,string datum_vracanja)
        {
            if(string.IsNullOrWhiteSpace(film) || film.Length > 50)
            {
                return BadRequest("Pogrešan film!");
            }
            if(broj_clanske_karte<1 || broj_clanske_karte>2000)
            {
                return BadRequest("Pogrešan broj clanske karte!");
            }
            try
            {
                var disk=Context.Diskovi.Where(p=>p.Film_na_disku==film ).FirstOrDefault();
                if(disk.Broj_diskova>0)
               {
                disk.Broj_diskova--;
                var clan=Context.Clanovi.Where(p=>p.Broj_clanske_karte==broj_clanske_karte).FirstOrDefault();
                Clanovi c =new Clanovi
                    {
                        Broj_clanske_karte=clan.Broj_clanske_karte,
                        Ime=clan.Ime,
                        Prezime=clan.Prezime,
                        Datum_isteka_clanarine=clan.Datum_isteka_clanarine,
                        Datum_iznajmljivanja_diska=datum_iznajmljivanja,
                        Datum_vracanja_diska=datum_vracanja,
                        Diskovi=disk
                    };
                    Context.Clanovi.Add(c);
                    Context.Diskovi.Update(disk);
                    await Context.SaveChangesAsync();
              }
              else
                {
                    return BadRequest("Svi diskovi sa ovim filmom su već pozajmljeni");
                }
                return Ok("Disk je uspešno dodeljen članu");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("Vratidisk/{film}/{broj_clanske_karte}")]
        [HttpPut]
        public async Task<ActionResult> VratiDisk(string film,int broj_clanske_karte)
        {
            if(string.IsNullOrWhiteSpace(film) || film.Length > 50)
            {
                return BadRequest("Pogrešan film!");
            }
            if(broj_clanske_karte<1 || broj_clanske_karte>2000)
            {
                return BadRequest("Pogrešan broj clanske karte!");
            }
            try
            {
                var disk=Context.Diskovi.Where(p=>p.Film_na_disku==film).FirstOrDefault();
                disk.Broj_diskova++;
                var clan=Context.Clanovi.Where(p=>p.Broj_clanske_karte==broj_clanske_karte).Where(p=>p.Diskovi.Film_na_disku==film).FirstOrDefault();
                Context.Diskovi.Update(disk);
                Context.Clanovi.Remove(clan);
                await Context.SaveChangesAsync();
                return Ok("Disk je uspešno vraćen u video klub");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("IzbrisatiDisk/{id}")]
        [HttpDelete]
        public async Task<ActionResult> IzbrisatiDisk(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Pogrešan ID!");
            }
            try
            {
                var disk = await Context.Diskovi.FindAsync(id);
                string d = disk.Film_na_disku;
                Context.Diskovi.Remove(disk);
                await Context.SaveChangesAsync();
                return Ok($"Uspešno izbrisan disk sa filmom: {d}");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
            
        
    }
}