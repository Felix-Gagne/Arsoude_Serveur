using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Arsoude_Backend.Models.Validations
{
    public class AreaCodeAttribute : ValidationAttribute
    {
        private const string Pattern = @"^[A-Za-z]\d[A-Za-z] \d[A-Za-z]\d$";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value != null)
            {
                string areaCode = value.ToString();

                if(Regex.IsMatch(areaCode, Pattern))
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Invalid area code format.");
                }
            }
            else
            {
                return new ValidationResult("Area code was null.");
            }
        }
    }
}
