using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models
{
    public class Diskovi
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Film_na_disku { get; set; }
        [Required]
        [Range(1,30)]
        public int Broj_diskova { get; set; }
        [JsonIgnore]
        public List<Film> Filmovi { get; set; }
        [JsonIgnore]
        public List<Clanovi>  Clanovi { get; set; }
    }
}