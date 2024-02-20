using System.Text.Json.Serialization;

namespace Arsoude_Backend.Models
{
    public class Hike
    {

        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Time { get; set; }

        public int Distance { get; set; }

        public int UserId { get; set; }

        [JsonIgnore]
        public virtual Trail Trail { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }

    }
}
