using Arsoude_Backend.Models.Validations;
using System.ComponentModel.DataAnnotations;

namespace Arsoude_Backend.Models.DTOs
{
    public class InfoRegDTO
    {
        public string Username { get; set; }

        public int? HouseNo { get; set; }

        public string? Street { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        [YearOfBirthRange(1900)]
        public int? YearOfBirth { get; set; }

        [Range(1, 12)]
        public int? MonthOfBirth { get; set; }
    }
}
