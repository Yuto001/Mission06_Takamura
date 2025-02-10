using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Takamura.Models;
using SQLitePCL;

namespace Mission06_Takamura.Controllers
{
    public class HomeController : Controller
    {
        private FilmDatabaseContext _context;

        public HomeController(FilmDatabaseContext temp)
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetToKnow()
        {
            return View();
        }

        [HttpGet]
        public IActionResult FilmDatabase()
        {
            return View();
        }
        [HttpPost]
        public IActionResult FilmDatabase(FilmInfo response)
        {
            _context.FilmInfos.Add(response);
            _context.SaveChanges();

            return View("Confirmation", response);
        }
     
    }
}
