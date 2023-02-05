using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BusinessLayer;

namespace PresentationLayerWeb.Models;

public class RegisterViewModel : IValidatableObject
{
    public string? Id { get; set; }
    [Required]
    public string Username { get; set; }
    [Required, DisplayName("First Name")]
    public string FirstName { get; set; }
    [Required, DisplayName("Last Name")]
    public string LastName { get; set; }
    [Required]
    public string Password { get; set; }
    [Required, DisplayName("Confirm password")]
    public string ConfirmPassword { get; set; }
    [Required]
    public Role Role { get; set; }
    public Team? Team { get; set; }
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (Password.Length < 8)
        {
            yield return new ValidationResult("Password must be at least 8 symbols long!",
                new[] { nameof(Password) });
        }
        if (Password != ConfirmPassword)
        {
            yield return new ValidationResult("Passwords must match!",
                new[] { nameof(Password), nameof(ConfirmPassword) });
        }
    }
}