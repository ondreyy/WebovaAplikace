using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebovaAplikace.Models
{
    public class Pristup
    {
        [Key]
        public string Uzivatel { get; set; }

        [Required]
        public string Heslo { get; set; }
    }
}
