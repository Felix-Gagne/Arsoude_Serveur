using Arsoude_Backend.Models.Validations;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Text.Json.Serialization;

namespace Arsoude_Backend.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        [AreaCode]
        public string AreaCode { get; set; }

        public int? HouseNo { get; set; }

        public string? Street { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        [YearOfBirthRange(1900)]
        public int? YearOfBirth { get; set; }

        [Range(1, 12)]
        public int? MonthOfBirth { get; set; }

        [JsonIgnore]
        public virtual List<Trail> Trails { get; set; }

        [JsonIgnore]
        public virtual List<UserFavoriteTrail>? FavouriteTrails { get; set; }

        [Required]
        public string? IdentityUserId { get; set; }

        [JsonIgnore]
        public virtual IdentityUser? IdentityUser { get; set; }
    }
}
