using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlayStore.Data;
using PlayStore.Models;
namespace PlayStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {

        private readonly PlayStoreDbContext _context;
        public UserController(PlayStoreDbContext context) => _context = context;


        [HttpPost]
        public IActionResult CreateUser([FromBody] User user, string password)
        {
            // Validate the user object and password
            if (user == null || string.IsNullOrWhiteSpace(password))
            {
                return BadRequest("Invalid user object or password.");
            }

            // Set the password for the user
            user.Password = password;
            user.LastViewed = new List<Item>();

            user.wishList = new List<Item>();
            // Add the user to the database
            // Your implementation of the database context may differ
            _context.User.Add(user);
            _context.SaveChanges();

            // Return a response with the user's username, profile picture, and lastViewed
            var response = new
            {
               
                Username = user.Username,
                Profile_pic = user.Profile_pic,
                LastViewed = user.LastViewed,
                Wishlist = user.wishList
            };

            return Ok(response);
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel loginModel)
        {
            // Validate the input parameters
            if (loginModel == null || string.IsNullOrWhiteSpace(loginModel.Username) || string.IsNullOrWhiteSpace(loginModel.Password))
            {
                return BadRequest("Invalid username or password.");
            }

            // Find the user in the database using the provided username and password
            var user = _context.User.SingleOrDefault(u => u.Username == loginModel.Username && u.Password == loginModel.Password);

            // If the user is not found or the password is incorrect, return a 401 Unauthorized status
            if (user == null)
            {
                return Unauthorized();
            }

            // If the user is found and the password is correct, create a response object with the desired properties and return it to the client
            var response = new
            {
                id = user.Id,
                Username = user.Username,
                Profile_pic = user.Profile_pic,
                LastViewed = user.LastViewed,
                isAdmin=false
            };

            return Ok(response);

        }

        [HttpPut("{userId}/lastViewed/{itemId}")]
        public IActionResult AddLastViewedItem(int userId, int itemId)
        {
            // Get the user and the item from the database
            var user = _context.User.Include(u => u.LastViewed).SingleOrDefault(u => u.Id == userId);
            var item = _context.Item.SingleOrDefault(i => i.Id == itemId);

            // Check if the user and item exist
            if (user == null || item == null)
            {
                return NotFound();
            }

            // Add the item to the user's last viewed items and save changes
            user.LastViewed.Add(item);
            _context.SaveChanges();

            // Return a 204 No Content status
            return NoContent();
        }

        [HttpDelete("{userId}/lastViewed/{itemId}")]
        public IActionResult RemoveLastViewedItem(int userId, int itemId)
        {
            // Get the user and the item from the database
            var user = _context.User.Include(u => u.LastViewed).SingleOrDefault(u => u.Id == userId);
            var item = _context.Item.SingleOrDefault(i => i.Id == itemId);

            // Check if the user and item exist
            if (user == null || item == null)
            {
                return NotFound();
            }

            // Remove the item from the user's last viewed items and save changes
            user.LastViewed.Remove(item);
            _context.SaveChanges();

            // Return a 204 No Content status
            return NoContent();
        }

        [HttpGet("{userId}/lastViewedAndWishList")]
        public IActionResult GetLastViewedItems(int userId)
        {
            // Get the user and their last viewed items from the database
            var user = _context.User.Include(u => u.LastViewed).ThenInclude(r=>r.Reviews).Include(u=>u.wishList).ThenInclude(r=>r.Reviews).SingleOrDefault(u => u.Id == userId);

            // Check if the user exists
            if (user == null)
            {
                return NotFound();
            }

            var respone = new {user.wishList, user.LastViewed };

            // Return the user's last viewed items
            return Ok(respone);
        }

        [HttpPut("{userId}/WishList/{itemId}")]
        public IActionResult AddWishListItem(int userId, int itemId)
        {
            // Get the user and the item from the database
            var user = _context.User.Include(u => u.wishList).SingleOrDefault(u => u.Id == userId);
            var item = _context.Item.SingleOrDefault(i => i.Id == itemId);

            // Check if the user and item exist
            if (user == null || item == null)
            {
                return NotFound();
            }

            // Add the item to the user's last viewed items and save changes
            user.wishList.Add(item);
            _context.SaveChanges();

            // Return a 204 No Content status
            return NoContent();
        }
    }
}




 
