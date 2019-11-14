using AutoMapper;
using System;
using System.Linq;
using System.Data.Entity;
using System.Web.Http;
using VidlyMvc.Models;
using VidlyMvc.Models.Dtos;

namespace VidlyMvc.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET/api/movies
        public IHttpActionResult GetMovies()
        {
            var moviesDto = _context.Movies
                .Include(m => m.Genre)
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);

            if (moviesDto == null)
            {
                return NotFound();
            }

            return Ok(moviesDto);
        }

        // GET/api/movies/id
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        // POST/api/customers
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);

            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        // PUT/api/movie/id
        public IHttpActionResult UpdatedMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
            {
                return NotFound();
            }

            Mapper.Map(movieDto, movieInDb);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE/movie/id
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movieInDb);

            _context.SaveChanges();

            return Ok();
        }
    }
}
