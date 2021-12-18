using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class VideoKlubContext : DbContext
    {
        public DbSet<Film> Filmovi { get; set; }
        public DbSet<Reziseri> Reziseri { get; set; }
        public DbSet<Diskovi> Diskovi { get; set; }
        public DbSet<Glumci> Glumci { get; set; }
        public DbSet<Clanovi> Clanovi { get; set; }
        
        public VideoKlubContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}