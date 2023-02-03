using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BusinessLayer;

namespace PresentationLayerWeb.Models;

public class PasswordViewModel
{
    [Required, DisplayName("Current password")]
    public string CurrentPassword { get; set; }
    [Required, DisplayName("New password")]
    public string NewPassword { get; set; }
    [Required, DisplayName("Confirm password"), Compare("NewPassword")]
    public string ConfirmPassword { get; set; }
}