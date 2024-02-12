using Arsoude_Backend.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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
        
        public int StartingCoordinatesId { get; set; }

        [Required]
        public virtual Coordinates EndingCoordinates { get; set; }
        
        public int EndingCoordinatesId { get; set; }

        public int OwnerId { get; set; }
        public Boolean isPublic { get; set; } = false;


        public bool? IsApproved { get; set; }

        public bool Ispublic { get; set; }

        [JsonIgnore]
        public virtual List<Coordinates>? Coordinates { get; set; }
    }
}