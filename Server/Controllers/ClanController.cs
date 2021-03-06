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
               var clanovi =Context.Clanovi.Where(p =>p.Broj_clanske_karte==broj_clanske_karte).Where(p=>p.Diskovi==null);
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
                  }).LastOrDefault()
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
            var c=Context.Clanovi.Where(p=>p.Broj_clanske_karte==clan.Broj_clanske_karte).FirstOrDefault();
            if(c!=null)
            {
                return BadRequest("Ve?? postoji ??lan sa tim brojem ??lanske karte");
            }
            if(clan.Broj_clanske_karte<1 || clan.Broj_clanske_karte>2000)
            {
                return BadRequest("Pogre??an broj clanske karte!");
            }
            if(string.IsNullOrWhiteSpace(clan.Ime) || clan.Ime.Length>50)
            {
                return BadRequest("Pogre??no ime ??lana!");
            }
            if(string.IsNullOrWhiteSpace(clan.Prezime) || clan.Prezime.Length>50)
            {
                return BadRequest("Pogre??no prezime ??lana!");
            }
            if(string.IsNullOrWhiteSpace(clan.Datum_isteka_clanarine) || clan.Datum_isteka_clanarine.Length>15)
            {
                return BadRequest("Pogre??an datum isteka ??lanarine!");
            }
            try
            {
                Context.Clanovi.Add(clan);
                await Context.SaveChangesAsync();
                return Ok($"??lan je dodat! Broj ??lanske karte je: {clan.Broj_clanske_karte}");
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
            var c=Context.Clanovi.Where(p=>p.Broj_clanske_karte==clan.Broj_clanske_karte).FirstOrDefault();
            if(clan.Ime==null)
            clan.Ime=c.Ime;
            if(clan.Prezime==null)
            clan.Prezime=c.Prezime;
            if(clan.Datum_isteka_clanarine==null)
            clan.Datum_isteka_clanarine=c.Datum_isteka_clanarine;
            if(clan.Broj_clanske_karte<1 || clan.Broj_clanske_karte>2000)
            {
                return BadRequest("Pogre??an broj clanske karte!");
            }
            if(string.IsNullOrWhiteSpace(clan.Ime) || clan.Ime.Length>50)
            {
                return BadRequest("Pogre??no ime ??lana!");
            }
            if(string.IsNullOrWhiteSpace(clan.Prezime) || clan.Prezime.Length>50)
            {
                return BadRequest("Pogre??no prezime ??lana!");
            }
            if(string.IsNullOrWhiteSpace(clan.Datum_isteka_clanarine) || clan.Datum_isteka_clanarine.Length>15)
            {
                return BadRequest("Pogre??an datum isteka ??lanarine!");
            }
            try
            {
                Context.Clanovi.Update(clan);
                await Context.SaveChangesAsync();
                return Ok($"??lan sa ??lanskom kartom: {clan.Broj_clanske_karte} je uspe??no izmenjen!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("IzbrisatiClana/{broj_clanske_karte}")]
        [HttpDelete]
        public async Task<ActionResult> IzbrisatiClana(int broj_clanske_karte)
        {
            var clan=Context.Clanovi.Where(p=>p.Broj_clanske_karte==broj_clanske_karte).FirstOrDefault();
            if (clan==null)
            {
                return BadRequest("Ne postoji ??lan sa tim brojem ??lanske karte!");
            }
            try
            {
                int b=clan.Broj_clanske_karte;
                Context.Clanovi.Remove(clan);
                await Context.SaveChangesAsync();
                return Ok($"Uspe??no izbrisan ??lan sa brojem indeksa: {b}");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
    }
}