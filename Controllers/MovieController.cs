using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlayStore.Data;
using PlayStore.Models;

namespace PlayStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
	{
        private readonly PlayStoreDbContext _context;
        public MovieController(PlayStoreDbContext context) => _context = context;

        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            movie.Reviews= new List<Review>();
            _context.Movie.Add(movie);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Movie), movie);
        }

        [HttpGet]
        public async Task<IActionResult> GetMovies()
        {
            var movies = await _context.Movie
                .Include(m => m.Cast)
                .Include(m => m.Credits)
                .Include(m => m.Reviews)
                .ToListAsync();

            return Ok(movies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovieById(int id)
        {

            var movie = await _context.Movie.FindAsync(id);

            if (movie == null)
            {
                return NotFound("App does not exist");
            }

            return Ok(movie);

        }

        [HttpDelete("movies/{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await _context.Movie.Include(m => m.Cast).Include(m => m.Credits).FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Actors.RemoveRange(movie.Cast);
            _context.Credits.RemoveRange(movie.Credits);
            _context.Movie.Remove(movie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPatch("trailer/edit/{id}")]
        public async Task<ActionResult<App>> updateTrailer(string trailer, int id)
        {

            var movie = await _context.Movie.FindAsync(id);

            if (movie == null)
            {
                return NotFound("app not found");
            }

            movie.TrailerLink = trailer;
            await _context.SaveChangesAsync();


            return Ok(movie);
        }




    }
    }

