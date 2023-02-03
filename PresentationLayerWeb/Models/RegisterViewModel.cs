using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BusinessLayer;

namespace PresentationLayerWeb.Models;

public class RegisterViewModel
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
    [Required, DisplayName("Confirm password"), Compare("Password")]
    public string ConfirmPassword { get; set; }
    [Required]
    public Role Role { get; set; }
    public Team? Team { get; set; }
}