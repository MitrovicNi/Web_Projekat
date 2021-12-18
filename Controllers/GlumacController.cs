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
    public class GlumacController : ControllerBase
    {
       public VideoKlubContext Context { get; set; }
       public GlumacController(VideoKlubContext context)
        {
            Context=context;
        }
        [Route("PreuzmiGlumca/{Ime}/{Prezime}")]
        [HttpGet]
        public async Task<ActionResult> PreuzmiGlumca(string Ime, string Prezime)
        {
            try
            {
                var glumci=Context.Glumci.Where(p =>p.Ime==Ime).Where(p=>p.Prezime==Prezime);
                var glumac= await glumci.ToListAsync();
                 return Ok
                (
                  glumac.Select(p =>
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
        [Route("DodatiGlumca")]
        [HttpPost]
        public async Task<ActionResult> DodatiRezisera([FromBody] Glumci glumac)
        {
            if (string.IsNullOrWhiteSpace(glumac.Ime) || glumac.Ime.Length>50)
            {
                return BadRequest("Pogrešno ime!");
            }
            if (string.IsNullOrWhiteSpace(glumac.Prezime) || glumac.Prezime.Length>50)
            {
                return BadRequest("Pogrešno prezime!");
            }
            if (string.IsNullOrWhiteSpace(glumac.Datum_rodjenja) || glumac.Datum_rodjenja.Length>15)
            {
                return BadRequest("Pogrešan datum rodjenja!");
            }
            if (string.IsNullOrWhiteSpace(glumac.Mesto_rodjenja) || glumac.Mesto_rodjenja.Length>50)
            {
                return BadRequest("Pogrešno mesto rodjenja!");
            }
            try
            {
                Context.Glumci.Add(glumac);
                await Context.SaveChangesAsync();
                return Ok("Glumac je dodat!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("PromenitiGlumca")]
        [HttpPut]
        public async Task<ActionResult> PromenitiGlumca([FromBody] Glumci glumac)
        {
            if (string.IsNullOrWhiteSpace(glumac.Ime) || glumac.Ime.Length>50)
            {
                return BadRequest("Pogrešno ime!");
            }
            if (string.IsNullOrWhiteSpace(glumac.Prezime) || glumac.Prezime.Length>50)
            {
                return BadRequest("Pogrešno prezime!");
            }
            if (string.IsNullOrWhiteSpace(glumac.Datum_rodjenja) || glumac.Datum_rodjenja.Length>15)
            {
                return BadRequest("Pogrešan datum rodjenja!");
            }
            if (string.IsNullOrWhiteSpace(glumac.Mesto_rodjenja) || glumac.Mesto_rodjenja.Length>50)
            {
                return BadRequest("Pogrešno mesto rodjenja!");
            }
            try
            {
                Context.Glumci.Update(glumac);
                await Context.SaveChangesAsync();
                return Ok("Uspešno izmenjen glumac!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("IzbrisatiGlumca/{id}")]
        [HttpDelete]
        public async Task<ActionResult> IzbrisatiGlumca(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Pogrešan ID!");
            }
            try
            {
                var glumac = await Context.Glumci.FindAsync(id);
                var g =glumac.Ime+" "+glumac.Prezime;
                Context.Glumci.Remove(glumac);
                await Context.SaveChangesAsync();
                return Ok($"Uspešno izbrisan glumac sa imenom i prezimenom: {g}");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}