using System.Collections.Generic;
using System.Linq;

namespace PlayStore.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Profile_pic { get; set; }
        public ICollection<Item> LastViewed { get; set; }
        public bool Recv_emails { get; set; }

        public ICollection<Item> GetLatestTwentyFour()
        {
            var itemsViewedList = LastViewed.ToList();
            int count = itemsViewedList.Count;
            if (count > 24)
            {
                itemsViewedList.RemoveRange(0, count - 24);
            }
            return itemsViewedList;
        }
    }
}
