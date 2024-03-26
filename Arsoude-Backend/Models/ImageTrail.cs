using System.ComponentModel.DataAnnotations;

namespace Arsoude_Backend.Models
{
    public class ImageTrail
    {
        public int Id { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public int TrailId { get; set; }
    }
}
