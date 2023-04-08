using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayStore.Models
{
    public class Review
    {   
        public int Id { get; set; }

        public int ItemId { get; set; }

        public string? Author { get; set; }
        public string? Image { get; set; }
        public float Rating { get; set; }
        public DateTime Date { get; set; }
        public string? Text { get; set; }

        [ForeignKey("ReviewId")]
        public ICollection<Reply>? Replies { get; set; }

        public Item Item = null!;
}
}
