using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayStore.Models
{
    public class Item
    {

        public int Id { get; set; }
        public string? MainImage { get; set; }
        [Required]
        public string? Title { get; set; }
        public float AverageRating { get; set; }
        [Required]
        public string? Genre { get; set; }
        public string? Price { get; set; }
        public string? description { get; set; }

        public ICollection<Review> Reviews { get; set; }


        public float GetAverageRating()
        {
            if (Reviews == null || Reviews.Count == 0)
            {
                return 0;
            }
            else
            {
                float totalRating = 0;
                foreach (var review in Reviews)
                {
                    totalRating += review.Rating;
                }
                return totalRating / Reviews.Count;
            }
        }

        public ICollection<Review> getLatestFive()
        {
            var reviewList = Reviews.ToList();
            ICollection<Review> lastFive = new List<Review>();
            for (int i = 0; i < 5 && i < reviewList.Count; i++)
            {
                lastFive.Add(reviewList[reviewList.Count - 1 - i]);
            }
            return lastFive;
        }
    }


}
