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

        [HttpPost]
        public async Task<ActionResult<App>> PostApp(App app)
        {
            app.Reviews= new List<Review>();
            _context.App.Add(app);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(App), app);
        }

        [HttpGet("GetAppsWithReviews")]
        public async Task<IActionResult> GetAppsWithReviews()
        {
            var apps = await _context.App.Include(a => a.Reviews).ThenInclude(r=>r.Replies).ToListAsync();

            if (apps == null || !apps.Any())
            {
                // If there are no apps, return a 404 Not Found HTTP status code.
                return NotFound();
            }

            return Ok(apps);
        }

        [HttpGet("GetAppWithReviews/{id}")]
        public async Task<IActionResult> GetAppWithReviews(int id)
        {
            var app = await _context.App.Include(a => a.Reviews).ThenInclude(r=> r.Replies).FirstOrDefaultAsync(a => a.Id == id);

            if (app == null)
            {
                // If the app doesn't exist, return a 404 Not Found HTTP status code.
                return NotFound();
            }

            return Ok(app);
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
        [HttpPost("AddReview/{id}")]
        public async Task<IActionResult> AddReview(int id,Review review)
        {
            if (review == null)
            {
                // If the request body is empty or invalid, return a 400 Bad Request HTTP status code.
                return BadRequest();
            }

            review.ItemId = id;

            review.Replies=new List<Reply>();

            // Find the item that the review belongs to.
            var item = await _context.Item.FindAsync(id);

            if (item == null)
            {
                // If the item doesn't exist, return a 404 Not Found HTTP status code.
                return NotFound();
            }

            // Add the review to the database.
            _context.Review.Add(review);

            // Update the item's average rating based on all of its reviews.
            //item.AverageRating = await _context.Review.Where(r => r.ItemId == review.ItemId).AverageAsync(r => r.Rating);

            // Save the changes to the data store.
            await _context.SaveChangesAsync();

            // Return the newly created review with the 201 Created HTTP status code.
            return CreatedAtAction(nameof(AddReview), new { id = review.Id }, review);
        }

        [HttpPost("AddReply/{id}")]
        public async Task<IActionResult> AddReply(int id, Reply reply)
        {
            if (reply == null)
            {
                // If the request body is empty or invalid, return a 400 Bad Request HTTP status code.
                return BadRequest();
            }

            reply.ReviewId = id;

            // Find the item that the review belongs to.
            var review = await _context.Review.FindAsync(id);

            if (review == null)
            {
                // If the item doesn't exist, return a 404 Not Found HTTP status code.
                return NotFound();
            }

            // Add the review to the database.
            _context.Reply.Add(reply);

            // Update the item's average rating based on all of its reviews.
            //item.AverageRating = await _context.Review.Where(r => r.ItemId == review.ItemId).AverageAsync(r => r.Rating);

            // Save the changes to the data store.
            await _context.SaveChangesAsync();

            // Return the newly created review with the 201 Created HTTP status code.
            return CreatedAtAction(nameof(AddReply), new { id = reply.Id }, reply);
        }

        [HttpPatch("images/edit/image1/{id}")]
        public async Task<ActionResult<App>> updateImage1(string image1, int id)
        {

            var app = await _context.App.FindAsync(id);

            if (app == null)
            {
                return NotFound("app not found");
            }

            app.Image_1 = image1;

            return Ok(app);
        }

        [HttpPatch("images/edit/{id}")]
        public async Task<ActionResult<App>> updateMainImage(string mainImage, int id)
        {

            var item = await _context.Item.FindAsync(id);

            if (item == null)
            {
                return NotFound("app not found");
            }

            item.MainImage = mainImage;
            await _context.SaveChangesAsync();


            return Ok(item);
        }



        [HttpPatch("images/edit/image3/{id}")]
        public async Task<ActionResult<App>> updateImage3(string image3, int id)
        {

            var app = await _context.App.FindAsync(id);

            if (app == null)
            {
                return NotFound("app not found");
            }

            app.Image_3 = image3;

            return Ok(app);


        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var item = await _context.Item.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            var relatedReviews = _context.Review.Where(r => r.ItemId == id);

            _context.Review.RemoveRange(relatedReviews);
            _context.Item.Remove(item);

            await _context.SaveChangesAsync();

            return NoContent();
        }



    }

}
