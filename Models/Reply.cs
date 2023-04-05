namespace PlayStore.Models
{
    public class Reply
    {
        
        public int Id { get; set; }
        public string? Author { get; set; }
        public DateTime Date { get; set; }
        public string? Text { get; set; }

        public int ReviewId { get; set; }

        public Review Review = null!;
    }
}
