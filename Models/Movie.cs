using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayStore.Models
{
    public class Movie : Item
    {
        public string? TrailerLink { get; set; }
        public ICollection<Actor>? Cast { get; set; }
        public ICollection<CrewMember>? Credits { get; set; }
        
    }

    public class Actor
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Role { get; set; }
    }

    public class CrewMember
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Role { get; set; }
    }
}
