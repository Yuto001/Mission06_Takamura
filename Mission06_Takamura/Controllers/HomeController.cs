using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Takamura.Models;
using SQLitePCL;
using static System.Net.Mime.MediaTypeNames;

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
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("FilmDatabase", new FilmInfo());
        }
        [HttpPost]
        public IActionResult FilmDatabase(FilmInfo response)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response);
                _context.SaveChanges();

                return View("Confirmation", response);
            }
            else
            {
                ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

                return View(response);
            }
        }

        public IActionResult MovieList()
        {
            // Linq
            var films = _context.Movies
                .Include(x => x.Category)
                .ToList();

            return View(films);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            FilmInfo recordToEdit = _context.Movies
                .Include(x => x.Category)
                .Single(x => x.MovieId == id);

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryId)
                .ToList();

            return View("FilmDatabase", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(FilmInfo updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();

            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == id);

            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(FilmInfo filminfo)
        {
            _context.Movies.Remove(filminfo);
            _context.SaveChanges();

            return RedirectToAction("MovieList");
        }
    }
}
