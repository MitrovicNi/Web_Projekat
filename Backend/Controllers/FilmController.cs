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
    public class FilmController : ControllerBase
    {
       public VideoKlubContext Context { get; set; }
       public FilmController(VideoKlubContext context)
        {
            Context=context;
        }

       
        [Route("Filmovi_naslov/{Naslov}")]
        [HttpGet]
        public async Task<ActionResult> Filmovi1 (string Naslov)
        {
            try
            {
                var filmovi=Context.Filmovi.Where(p=>p.Naslov==Naslov)
                .Include(p=>p.Reziseri)
                .Include(p=>p.Glumci);
                var film = await filmovi.ToListAsync();

                return Ok
                (
                    film.Select(p=>
                    new
                    {
                       id=p.ID,
                       naslov=p.Naslov,
                       reziser=p.Reziseri.Select(q =>
                       new{
                           Ime = q.Ime,
                           prezime= q.Prezime
                       }),
                       tip=p.Tip,
                       glumci =p.Glumci.Select(k =>
                       new 
                       {
                           ime_glumca=k.Ime,
                           prezime_glumca=k.Prezime
                       }),
                       rejting=p.Rejting,
                       godina=p.Godina,
                       nominacija_za_nagrade=p.Nominacija_za_nagrade,
                       dobijene_nagrade=p.Dobijene_nagrade
                    }).ToList()
                );
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("Filmovi_reziser/{Reziser_ime}/{Reziser_prezime}")]
        [HttpGet]
        public async Task<ActionResult> Filmovi2 (string Reziser_ime,string Reziser_prezime)
        {
            try
            {
                var filmovi=Context.Filmovi
                .Include(p=>p.Reziseri)
                .Include(p=>p.Glumci);
                var film = await filmovi.ToListAsync();

                return Ok
                (
                    film.Select(p=>
                    new
                    {
                       id=p.ID,
                       naslov=p.Naslov,
                       reziser=p.Reziseri.Where(q =>Reziser_ime.Contains(q.Ime)).Where(q =>Reziser_prezime.Contains(q.Prezime)).Select(q =>
                       new{
                           Ime = q.Ime,
                           prezime= q.Prezime
                       }),
                       tip=p.Tip,
                       glumci =p.Glumci.Select(q =>
                       new 
                       {
                           ime_glumca=q.Ime,
                           prezime_glumca=q.Prezime
                       }),
                       rejting=p.Rejting,
                       godina=p.Godina,
                       nominacija_za_nagrade=p.Nominacija_za_nagrade,
                       dobijene_nagrade=p.Dobijene_nagrade
                    }).ToList()
                );
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("Filmovi_glumac/{Glumac_ime}/{Glumac_prezime}")]
        [HttpGet]
        public async Task<ActionResult> Filmovi3 (string Glumac_ime,string Glumac_prezime)
        {
            try
            {
                var filmovi=Context.Filmovi
                .Include(p=>p.Reziseri)
                .Include(p=>p.Glumci);
                var film = await filmovi.ToListAsync();

                return Ok
                (
                    film.Select(p=>
                    new
                    {
                       id=p.ID,
                       naslov=p.Naslov,
                       reziser=p.Reziseri.Select(q =>
                       new{
                           Ime = q.Ime,
                           prezime= q.Prezime
                       }),
                       tip=p.Tip,
                       glumci =p.Glumci.Where(q =>Glumac_ime.Contains(q.Ime)).Where(q =>Glumac_prezime.Contains(q.Prezime)).Select(q =>
                       new 
                       {
                           ime_glumca=q.Ime,
                           prezime_glumca=q.Prezime
                       }),
                       rejting=p.Rejting,
                       godina=p.Godina,
                       nominacija_za_nagrade=p.Nominacija_za_nagrade,
                       dobijene_nagrade=p.Dobijene_nagrade
                    }).ToList()
                );
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("DodatiFilm")]
        [HttpPost]
        public async Task<ActionResult> DodajFilm([FromBody] Film film)
        {
            if(string.IsNullOrWhiteSpace(film.Naslov) || film.Naslov.Length > 50)
            {
                return BadRequest("Pogrešan naslov!");
            }
            if(string.IsNullOrWhiteSpace(film.Tip) || film.Tip.Length > 50)
            {
                return BadRequest("Pogrešan tip filma!");
            }
            if(film.Rejting<1 || film.Rejting>10)
            {
                return BadRequest("Pogrešan rejting filma!");
            }
            if(film.Godina<1930 || film.Godina>2021)
            {
                return BadRequest("Pogrešna godina!");
            }
            try
            {
                Context.Filmovi.Add(film);
                await Context.SaveChangesAsync();
                return Ok($"Film je dodat! Naslov je: {film.Naslov}");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("PromenaFilma")]
        [HttpPut]
        public async Task<ActionResult> PromeniFilm([FromBody] Film film)
        {
           if(string.IsNullOrWhiteSpace(film.Naslov) || film.Naslov.Length > 50)
            {
                return BadRequest("Pogrešan naslov!");
            }
            if(string.IsNullOrWhiteSpace(film.Tip) || film.Tip.Length > 50)
            {
                return BadRequest("Pogrešan tip filma!");
            }
            if(film.Rejting<1 || film.Rejting>10)
            {
                return BadRequest("Pogrešan rejting filma!");
            }
            if(film.Godina<1930 || film.Godina>2021)
            {
                return BadRequest("Pogrešna godina!");
            }
            try
            {
                Context.Filmovi.Update(film);
                await Context.SaveChangesAsync();
                return Ok($"Film sa naslovom: {film.Naslov} je uspešno izmenjen!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("IzbrisatiFilm/{id}")]
        [HttpDelete]
        public async Task<ActionResult> IzbrisatiFilm(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Pogrešan ID!");
            }
            try
            {
                var reziser = await Context.Reziseri.Where(p=>p.Film.ID==id).FirstOrDefaultAsync();
                var glumac=await Context.Glumci.Where(p=>p.Film.ID==id).FirstOrDefaultAsync();
                var film = await Context.Filmovi.FindAsync(id);
                var f = film.Naslov;
                Context.Glumci.Remove(glumac);
                Context.Reziseri.Remove(reziser);
                Context.Filmovi.Remove(film);
                await Context.SaveChangesAsync();
                return Ok($"Uspešno izbrisan film sa nazivom: {f}");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
