﻿using System.Text.Json.Serialization;

namespace Arsoude_Backend.Models
{
    public class Hike
    {

        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int Time { get; set; }

        public int Distance { get; set; }

        public int UserId { get; set; }

        public int TrailId { get; set; }

        public bool IsCompleted { get; set; }

        [JsonIgnore]
        public virtual Trail? Trail { get; set; }

        [JsonIgnore]
        public virtual User? User { get; set; }

    }
}
