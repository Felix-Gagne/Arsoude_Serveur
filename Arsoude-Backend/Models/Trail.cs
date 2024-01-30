using Arsoude_Backend.Models.Enums;
using System.ComponentModel.DataAnnotations;
namespace Arsoude_Backend.Models
{
    public class Trail
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

     
        [Required, MaxLength(255, ErrorMessage = "Description Trop Longue")]
        public string Description { get; set; }

        /// <summary>
        /// Place where the trail starts (ex : Mont Saint-Grégoire)
        /// </summary>
        [Required]
        public string Location { get; set; }

        /// <summary>
        /// Enum Defining what the trail is made for
        /// </summary>
        [Required]
        public virtual TrailType Type { get; set; }


        public string? ImageUrl { get; set; }

        [Required]
        public virtual Coordinates StartingCoordinates { get; set; }
        [Required]
        public int StartingCoordinatesId { get; set; }

        [Required]
        public virtual Coordinates EndingCoordinates { get; set; }
        [Required]
        public int EndingCoordinatesId { get; set; }

        public int OwnerId { get; set; }
    }
}