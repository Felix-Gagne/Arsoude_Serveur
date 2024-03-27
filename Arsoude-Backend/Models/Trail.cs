using Arsoude_Backend.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [Required]
        public string Location { get; set; }

        [Required]
        public virtual TrailType Type { get; set; }

        public string? ImageUrl { get; set; }

        [Required]
        public virtual Coordinates StartingCoordinates { get; set; }
        
        public int StartingCoordinatesId { get; set; }

        [Required]
        public virtual Coordinates EndingCoordinates { get; set; }
        
        public int EndingCoordinatesId { get; set; }

        public DateTime? CreationDate { get; set; }

        public int OwnerId { get; set; }

        public bool isPublic { get; set; } = false;  

        public double? Distance { get; set; }

        public bool? IsApproved { get; set; }

        public double? Rating { get; set; }

        public int TotalRatings { get; set; } = 0;

        [JsonIgnore]
        public virtual List<Coordinates>? Coordinates { get; set; }

        [JsonIgnore]
        public virtual List<Comments>? Comments { get; set; }

        [JsonIgnore]
        public virtual List<ImageTrail>? ImageList { get; set; }


    }
}