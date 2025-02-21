//using System.Diagnostics;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore.Metadata.Internal;
//using Mission06_Zorrilla.Models;
//using static Microsoft.EntityFrameworkCore.DbLoggerCategory;



using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Zorrilla.Models;
using System.Diagnostics;

namespace Mission06_Zorrilla.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext _context;
        public HomeController(AppDbContext iMovie) //contructor
        {
            _context = iMovie;
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
        public IActionResult AddMovie()
        {
            ViewBag.Category = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();
            return View();
        }
        [HttpPost]
        public IActionResult AddMovie(Movie response)
        {
            _context.Movies.Add(response); //Add record to the database to the AddedMovies table
            _context.SaveChanges();
            return View("Confirmation", response);
        }

        public IActionResult MovieWaitList()
        {
            var irequests = _context.Movies
                .Include(x => x.Category)
                .OrderBy(x => x.Title)
                .ToList();
            
            return View(irequests);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Movies
                .Single(x => x.MovieID == id);

            ViewBag.Category = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("AddMovie", recordToEdit);
        }
        [HttpPost]
        public IActionResult Edit(Movie response)
        {
            _context.Movies.Update(response);
            _context.SaveChanges();
            return RedirectToAction("MovieWaitList");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Movies
                .Single(m => m.MovieID == id);
            return View(recordToDelete);
            
        }
        [HttpPost]
        public IActionResult Delete(Movie moviet)
        {
            _context.Movies.Remove(moviet);
            _context.SaveChanges();
            
            return RedirectToAction("MovieWaitList");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

