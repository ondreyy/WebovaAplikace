using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebovaAplikace.Models
{
    public class Pristup
    {
        [Key]
        public string? Heslo { get; set; } = null;
    }
}
