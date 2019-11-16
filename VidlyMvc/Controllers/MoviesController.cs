using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using VidlyMvc.Models;
using VidlyMvc.ViewModels;
using System.Globalization;

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

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Genres = genres
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Create(Movie movie)
        {
            movie.DateAddedDb = DateTime.Today;

            _context.Movies.Add(movie);
            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };

                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
            {
                movie.DateAddedDb = DateTime.Today;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.NumberInStock = movie.NumberInStock;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Index()
        {
            var movies = _context.Movies.Include(c => c.Genre).ToList();

            if (User.IsInRole(RoleName.CanManageMovies))
            {
                return View("List", movies);
            }

            return View("ReadOnlyList", movies);
        }

        public ActionResult Details(int id)
        {
            var movies = _context.Movies.Include(c => c.Genre).ToList().SingleOrDefault(c => c.Id == id);

            movies.ReleaseDate.ToString(CultureInfo.GetCultureInfo("en-UK"));

            return View(movies);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            var viewModel = new MovieFormViewModel(movie)
            {
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }
    }
}