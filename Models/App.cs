using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayStore.Models
{
    public class App
    {
       
        public int Id { get; set; }
        public string MainImage { get; set; }
        [Required]
        public string Title { get; set; }
        public float AverageRating { get; set; }
        [Required]
        public string Genre { get; set; }
        public string Price { get; set; }
        public string image_1 { get; set; }
        public string image_2 { get; set; }
        public string image_3 { get; set; }

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
    }


}
