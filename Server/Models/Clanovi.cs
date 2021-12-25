using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models
{
    public class Clanovi
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Range(1,2000)]
        public int Broj_clanske_karte { get; set; }
        [Required]
        [MaxLength(50)]
        public string Ime { get; set; }
        [Required]
        [MaxLength(50)]
        public string Prezime { get; set; }
        [Required]
        [MaxLength(15)]
        public string Datum_isteka_clanarine { get; set; }
        [MaxLength(15)]
        public string Datum_iznajmljivanja_diska { get; set; }
        [MaxLength(15)]
        public string Datum_vracanja_diska { get; set; }
        [JsonIgnore]
        public Diskovi Diskovi { get; set; }
    }
}