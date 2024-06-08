using System.ComponentModel.DataAnnotations;

namespace netflixProjectBackendDotNet.Api.Models.Request
{
    public class LoginRequest : IValidatableObject
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(string.IsNullOrEmpty(Email))
            {
                yield return new ValidationResult("Email cannot be empty");
            }
            if (string.IsNullOrEmpty(Password))
            {
                yield return new ValidationResult("Password cannot be empty");
            }
        }
    }
}
