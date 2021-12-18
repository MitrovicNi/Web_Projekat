using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models
{
    public class Glumci
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Ime { get; set; }
        [Required]
        [MaxLength(50)]
        public string Prezime { get; set; }
        [Required]
        [MaxLength(15)]
        public string Datum_rodjenja { get; set; }
        [Required]
        [MaxLength(50)]
        public string Mesto_rodjenja { get; set; }
        [JsonIgnore]
        public Film Film { get; set; }
    }
}