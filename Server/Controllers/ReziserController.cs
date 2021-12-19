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
    public class ReziserController : ControllerBase
    {
       public VideoKlubContext Context { get; set; }
       public ReziserController(VideoKlubContext context)
        {
            Context=context;
        }
        [Route("PreuzmiRezisera/{Ime}/{Prezime}")]
        [HttpGet]
        public async Task<ActionResult> PreuzmiRezisera(string Ime, string Prezime)
        {
            try
            {
                var reziseri=Context.Reziseri.Where(p =>p.Ime==Ime).Where(p=>p.Prezime==Prezime);
                var reziser= await reziseri.ToListAsync();
                return Ok
                (
                  reziser.Select(p =>
                  new
                   {
                     ID=p.ID,
                     Ime=p.Ime,
                     Prezime =p.Prezime,
                     Datum_rodjenja=p.Datum_rodjenja,
                     Mesto_rodjenja =p.Mesto_rodjenja
                    }).ToList()
               );
                
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("DodatiRezisera")]
        [HttpPost]
        public async Task<ActionResult> DodatiRezisera([FromBody] Reziseri reziser)
        {
            if (string.IsNullOrWhiteSpace(reziser.Ime) || reziser.Ime.Length>50)
            {
                return BadRequest("Pogrešno ime!");
            }
            if (string.IsNullOrWhiteSpace(reziser.Prezime) || reziser.Prezime.Length>50)
            {
                return BadRequest("Pogrešno prezime!");
            }
            if (string.IsNullOrWhiteSpace(reziser.Datum_rodjenja) || reziser.Datum_rodjenja.Length>15)
            {
                return BadRequest("Pogrešan datum rodjenja!");
            }
            if (string.IsNullOrWhiteSpace(reziser.Mesto_rodjenja) || reziser.Mesto_rodjenja.Length>50)
            {
                return BadRequest("Pogrešno mesto rodjenja!");
            }
            try
            {
                Context.Reziseri.Add(reziser);
                await Context.SaveChangesAsync();
                return Ok("Reziser je dodat!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("PromenitiRezisera")]
        [HttpPut]
        public async Task<ActionResult> PromenitiRezisera([FromBody] Reziseri reziser)
        {
            if (string.IsNullOrWhiteSpace(reziser.Ime) || reziser.Ime.Length>50)
            {
                return BadRequest("Pogrešno ime!");
            }
            if (string.IsNullOrWhiteSpace(reziser.Prezime) || reziser.Prezime.Length>50)
            {
                return BadRequest("Pogrešno prezime!");
            }
            if (string.IsNullOrWhiteSpace(reziser.Datum_rodjenja) || reziser.Datum_rodjenja.Length>15)
            {
                return BadRequest("Pogrešan datum rodjenja!");
            }
            if (string.IsNullOrWhiteSpace(reziser.Mesto_rodjenja) || reziser.Mesto_rodjenja.Length>50)
            {
                return BadRequest("Pogrešno mesto rodjenja!");
            }
            try
            {
                Context.Reziseri.Update(reziser);
                await Context.SaveChangesAsync();
                return Ok("Uspešno izmenjen reziser!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("IzbrisatiRezisera/{id}")]
        [HttpDelete]
        public async Task<ActionResult> IzbrisatiRezisera(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Pogrešan ID!");
            }
            try
            {
                var reziser = await Context.Reziseri.FindAsync(id);
                var r =reziser.Ime+" "+reziser.Prezime ;
                Context.Reziseri.Remove(reziser);
                await Context.SaveChangesAsync();
                return Ok($"Uspešno izbrisan režiser sa imenom i prezimenom: {r}");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}