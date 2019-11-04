using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using VidlyMvc.Models;
using VidlyMvc.ViewModels;

namespace VidlyMvc.Controllers
{
    public class MoviesController : Controller
    {
        public ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var movies = _context.Movies.Include(c => c.Genre).ToList();

            return View(movies);
        }

        [Route("movie/details/{id}")]
        public ActionResult Details(int id)
        {
            var movies = _context.Movies.Include(c => c.Genre).ToList().SingleOrDefault(c => c.Id == id);

            return View(movies);
        }

        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek" };

            var customers = new List<Customer>
            {
                new Customer{Name = "Customer 1"},
                new Customer{Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }
    }
}