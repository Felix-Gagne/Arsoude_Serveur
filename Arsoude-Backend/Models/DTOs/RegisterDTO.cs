using Arsoude_Backend.Models.Validations;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Arsoude_Backend.Models.DTOs
{
    public class RegisterDTO
    {
        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [AreaCode]
        public String AreaCode { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Les mots de passe ne correspondent pas.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

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
