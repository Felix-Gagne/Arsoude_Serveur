using System.ComponentModel.DataAnnotations;

namespace Arsoude_Backend.Models.Validations
{
    public class YearOfBirthRangeAttribute : ValidationAttribute
    {
        private readonly int _minYear;
        private readonly int _maxYear;

        public YearOfBirthRangeAttribute(int minYear)
        {
            _minYear = minYear;
            _maxYear = DateTime.Now.Year; 
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is int yearOfBirth)
            {
                if (yearOfBirth < _minYear || yearOfBirth > _maxYear)
                {
                    return new ValidationResult($"The year of birth must be between {_minYear} and {_maxYear}.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
