using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BusinessLayer;

namespace PresentationLayerWeb.Models;

public class VacationViewModel : IValidatableObject
{
    public string? Id { get; set; }
    [Required, DisplayName("Beginning Date"), DataType(DataType.Date)]
    public DateTime BeginningDate { get; set; }
    [Required, DisplayName("End Date"), DataType(DataType.Date)]
    public DateTime EndDate { get; set; }
    [DataType(DataType.Date)]
    public DateTime DateOfCreation { get; set; }
    [DisplayName("Half Day Vacation")]
    public bool HalfDayVacation { get; set; }
    public bool Accepted { get; set; }
    [Required, DisplayName("Vacation Type")]
    public VacationType VacationType { get; set; }
    public User? Applicant { get; set; }
    [DisplayName("Image")]
    public IFormFile? VacationImage { get; set; }
    public string? ImageFilePath { get; set; }
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (BeginningDate > EndDate)
        {
            yield return new ValidationResult("Beginning date must be earlier than end date!",
                new[] { nameof(BeginningDate), nameof(EndDate) });
        }

        if (BeginningDate < DateTime.Today || EndDate < DateTime.Today)
        {
            yield return new ValidationResult("The beginning and end date must be later than the current date!",
                new[] { nameof(BeginningDate), nameof(EndDate) });
        }
    }
}