using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebovaAplikace.Models;

namespace WebovaAplikace.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}