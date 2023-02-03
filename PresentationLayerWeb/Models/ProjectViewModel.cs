using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BusinessLayer;

namespace PresentationLayerWeb.Models;

public class ProjectViewModel
{
    public string? Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    public List<Team>? Teams { get; set; }
}