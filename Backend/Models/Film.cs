using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models
{
    public class Film
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Naslov { get; set; }
        [Required]
        [MaxLength(50)]
        public string Tip { get; set; }
        [Required]
        [Range(1,10)]
        public int Rejting { get; set; }
        [Required]
        [Range(1930,2021)]
        public int Godina { get; set; }
        [MaxLength(100)]
        public string Nominacija_za_nagrade { get; set; }
        [MaxLength(100)]
        public string Dobijene_nagrade { get; set; }
        [JsonIgnore]
        public Diskovi Diskovi { get; set; }
        
        public List<Reziseri> Reziseri { get; set; }
        
        public List<Glumci> Glumci { get; set; }
    }
}