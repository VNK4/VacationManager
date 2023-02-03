using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BusinessLayer;

namespace PresentationLayerWeb.Models;

public class UserViewModel
{
    public string? Id { get; set; }
    [Required]
    public string Username { get; set; }
    [Required, DisplayName("First Name")]
    public string FirstName { get; set; }
    [Required, DisplayName("Last Name")]
    public string LastName { get; set; }
    [Required]
    public Role Role { get; set; }
    public string? TeamId { get; set; }
    public Team? Team { get; set; }
}