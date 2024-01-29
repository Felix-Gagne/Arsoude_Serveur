using Arsoude_Backend.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace Arsoude_Backend.Models
{
    public class Trail
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

     
        [Required, MaxLength(255, ErrorMessage = "Description Trop Longue")]
        public string Description { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public virtual TrailType Type { get; set; }


        public string? ImageUrl {get; set;}

        [Required]
        public virtual Coordinates StartingCoordinates { get; set; }

        [Required]
        public virtual Coordinates EndingCoordinates { get; set; }

        public int OwnerId { get; set; }
    }
}
