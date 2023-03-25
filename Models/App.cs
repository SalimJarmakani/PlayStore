using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayStore.Models
{
    public class App : Item
    {
       
        public string? Image_1 { get; set; }
        public string? Image_2 { get; set; }
        public string? Image_3 { get; set; }


    }


}
