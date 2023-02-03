using System.ComponentModel;
using BusinessLayer;
using Microsoft.Build.Framework;

namespace PresentationLayerWeb.Models;

public class TeamViewModel
{
    public string? Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required, DisplayName("Project")]
    public string ProjectId { get; set; }
    [DisplayName("Team Leader")]
    public string? TeamLeaderId { get; set; }
    public List<User>? Users { get; set; }
}