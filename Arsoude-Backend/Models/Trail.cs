using System.ComponentModel.DataAnnotations;

namespace Arsoude_Backend.Models
{
    public class Trail
    {
        public int id { get; set; }


        [Required]
        public string Name { get; set; }

     
        [Required, MaxLength(255, ErrorMessage ="Description Trop Longue")]
        public string Description { get; set; }

        /// <summary>
        /// Place where the trail starts (ex : Mont Saint-Grégoire)
        /// </summary>
        [Required]
        public string location { get; set; }

        /// <summary>
        /// Enum Defining what the trail is made for
        /// </summary>
        [Required]
        public Type type { get; set; }


        public string? ImageUrl {get; set;}

        [Required]
        public Coordinates StartingCoordinates { get; set; }

        [Required]
        public Coordinates EndingCoordinates { get; set; }

        public int OwnerId { get; set; }





    }
}
