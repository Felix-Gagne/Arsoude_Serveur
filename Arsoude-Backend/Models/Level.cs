using System.Text.Json.Serialization;

namespace Arsoude_Backend.Models
{
    public class Level
    {
        public int Id { get; set; }

        public int CurrentLevel { get; set; }

        public int Experience { get; set; }

        public int PreviousLevelExperience { get; set; }

        public int NextLevelExperience { get; set; }

        public int UserId { get; set; }
    }
}
