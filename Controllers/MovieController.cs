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




        }
    }

