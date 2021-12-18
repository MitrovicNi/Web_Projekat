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
    public class ClanController : ControllerBase
    {
       public VideoKlubContext Context { get; set; }
       public ClanController(VideoKlubContext context)
        {
            Context=context;
        }
        [Route("PreuzmiClana/{broj_clanske_karte}")]
        [HttpGet]
        public async Task<ActionResult> PreuzmiClana(int broj_clanske_karte)
        {
            try
            {
               var clanovi =Context.Clanovi.Where(p =>p.Broj_clanske_karte==broj_clanske_karte);
               var clan= await clanovi.ToListAsync();
               return Ok
               (
                  clan.Select(p =>
                  new
                  {
                     ID=p.ID,
                     Broj_clanske_karte=p.Broj_clanske_karte,
                     Ime =p.Ime,
                     Prezime =p.Prezime,
                     Datum_isteka_clanarine=p.Datum_isteka_clanarine,
                  }).FirstOrDefault()
               );
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("VratiDiskovePozajmljene/{broj_clanske_karte}")]
        [HttpGet]
        public async Task<ActionResult> PreuzmiDiskove(int broj_clanske_karte)
        {
            try
            {
               var clanovi =Context.Clanovi.Where(p =>p.Broj_clanske_karte==broj_clanske_karte).Include(p=>p.Diskovi).Where(p=>p.Diskovi!=null);
               var clan= await clanovi.ToListAsync();
               return Ok
               (
                  clan.Select(p =>
                  new
                  {
                     Film=p.Diskovi.Film_na_disku,
                     Datum_iznajmljivanja_diska=p.Datum_iznajmljivanja_diska,
                     Datum_vracanja_diska=p.Datum_vracanja_diska
                  }).ToList()
               );
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("DodatiClana")]
        [HttpPost]
        public async Task<ActionResult> DodatiClana([FromBody] Clanovi clan)
        {
            
            if(clan.Broj_clanske_karte<1 || clan.Broj_clanske_karte>2000)
            {
                return BadRequest("Pogrešan broj clanske karte!");
            }
            if(string.IsNullOrWhiteSpace(clan.Ime) || clan.Ime.Length>50)
            {
                return BadRequest("Pogrešno ime člana!");
            }
            if(string.IsNullOrWhiteSpace(clan.Prezime) || clan.Prezime.Length>50)
            {
                return BadRequest("Pogrešno prezime člana!");
            }
            if(string.IsNullOrWhiteSpace(clan.Datum_isteka_clanarine) || clan.Datum_isteka_clanarine.Length>15)
            {
                return BadRequest("Pogrešan datum isteka članarine!");
            }
            try
            {
                Context.Clanovi.Add(clan);
                await Context.SaveChangesAsync();
                return Ok($"Član je dodat! Broj članske karte je: {clan.Broj_clanske_karte}");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("PromenaClana")]
        [HttpPut]
        public async Task<ActionResult> PromenitiClana([FromBody] Clanovi clan)
        {
            if(clan.Broj_clanske_karte<1 || clan.Broj_clanske_karte>2000)
            {
                return BadRequest("Pogrešan broj clanske karte!");
            }
            if(string.IsNullOrWhiteSpace(clan.Ime) || clan.Ime.Length>50)
            {
                return BadRequest("Pogrešno ime člana!");
            }
            if(string.IsNullOrWhiteSpace(clan.Prezime) || clan.Prezime.Length>50)
            {
                return BadRequest("Pogrešno prezime člana!");
            }
            if(string.IsNullOrWhiteSpace(clan.Datum_isteka_clanarine) || clan.Datum_isteka_clanarine.Length>15)
            {
                return BadRequest("Pogrešan datum isteka članarine!");
            }
            try
            {
                Context.Clanovi.Update(clan);
                await Context.SaveChangesAsync();
                return Ok($"Član sa članskom kartom: {clan.Broj_clanske_karte} je uspešno izmenjen!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("IzbrisatiClana/{id}")]
        [HttpDelete]
        public async Task<ActionResult> IzbrisatiClana(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Pogrešan ID!");
            }
            try
            {
                var clan = await Context.Clanovi.FindAsync(id);
                int b = clan.Broj_clanske_karte;
                Context.Clanovi.Remove(clan);
                await Context.SaveChangesAsync();
                return Ok($"Uspešno izbrisan član sa brojem indeksa: {b}");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
    }
}