using System.ComponentModel.DataAnnotations;

namespace PlayStore.Models
{
    public class Review
    {   
        public int Id { get; set; }
        public string? Author { get; set; }
        public string? Image { get; set; }
        public float Rating { get; set; }
        public DateTime Date { get; set; }
        public string? Text { get; set; }
        public ICollection<Reply>? Replies { get; set; }
    }
}
