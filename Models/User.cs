using System.ComponentModel.DataAnnotations;

namespace PlayStore.Models
{
    public class User
    {

        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Profile_pic { get; set; }
        public ICollection<Review>? LastViewed { get; set; }
        public bool Recv_emails { get; set; }

    }
}
