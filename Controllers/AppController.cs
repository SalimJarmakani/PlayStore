using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlayStore.Data;
using PlayStore.Models;

namespace PlayStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppController : ControllerBase
    {
        private readonly PlayStoreDbContext _context;
        public AppController(PlayStoreDbContext context) => _context = context;
        [HttpGet]
        public async Task<IEnumerable<App>> Get() => await _context.App.ToListAsync();

        [HttpPost]
        public async Task<ActionResult<App>> PostApp(App app)
        {
            _context.App.Add(app);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(App), app);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<App>> GetAppById(int id)
        {

            var app = await _context.App.FindAsync(id);

            if (app == null)
            {
                return NotFound("App does not exist");
            }

            return Ok(app);


        }
        [HttpPatch("appReview/add/{id}")]
        public async Task<ActionResult<App>> updateReview(Review review, int id)
        {
            var app = await _context.App.FindAsync(id);
            if (app == null)
            {
                return NotFound("app not found");
            }

            app.Reviews.Add(review);

            return Ok(app);

        }
        [HttpPatch("images/edit/image1/{id}")]
        public async Task<ActionResult<App>> updateImage1(string image1, int id)
        {

            var app = await _context.App.FindAsync(id);

            if (app == null)
            {
                return NotFound("app not found");
            }

            app.image_1 = image1;

            return Ok(app);
        }

        [HttpPatch("images/edit/image2/{id}")]
        public async Task<ActionResult<App>> updateImage2(string image2, int id)
        {

            var app = await _context.App.FindAsync(id);

            if (app == null)
            {
                return NotFound("app not found");
            }

            app.image_2 = image2;

            return Ok(app);
        }

        [HttpPatch("images/edit/image3/{id}")]
        public async Task<ActionResult<App>> updateImage3(string image3, int id)
        {

            var app = await _context.App.FindAsync(id);

            if (app == null)
            {
                return NotFound("app not found");
            }

            app.image_3 = image3;

            return Ok(app);


        }



    }

}
