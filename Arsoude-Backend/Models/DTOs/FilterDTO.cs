using Arsoude_Backend.Models.Enums;

namespace Arsoude_Backend.Models.DTOs
{
    public class FilterDTO
    {
        public string? Keyword { get; set; }

        public TrailType? Type { get; set; }

        public Coordinates? Coordinates { get; set; }

        public int? Distance { get; set; }
    }
}
