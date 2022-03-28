using System.ComponentModel.DataAnnotations;

namespace WebovaAplikace.Models
{
    public class Poznamka
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nadpis { get; set; } = String.Empty;

        [Required]
        public string Text { get; set; } = String.Empty;

        [Required]
        public DateTime CasPridani { get; set; }
    }
}
