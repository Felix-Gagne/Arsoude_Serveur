using Arsoude_Backend.Models.Validations;

namespace Arsoude_Backend.Models.DTOs
{
    public class ModifUserDTO
    {
        public string? LastName { get; set; }

        public string? FirstName { get; set; }

        public string? AreaCode { get; set; }

        public int? HouseNo { get; set; }

        public string? Street { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public int? YearOfBirth { get; set; }

        public int? MonthOfBirth { get; set; }

        public string? AvatarUrl { get; set; }
    }
}
