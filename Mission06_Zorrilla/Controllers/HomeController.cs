using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Zorrilla.Models;

namespace Mission06_Zorrilla.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        private AddMovieContext _context;
        public HomeController(AddMovieContext someName) //contructor
        {
            _context = someName;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddMovie(Application response)
        {
            _context.AddedMovies.Add(response); //Add record to the database to the AddedMovies table
            _context.SaveChanges();
            return View("Confirmation", response);
        }
        public IActionResult GetToKnow()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
