using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mime;

namespace BusinessLayer
{
    public class Vacation
    {
        [Key]
        public string Id { get; private set; }

        [Required, DisplayName("Beginning Date"), DataType(DataType.Date)]
        public DateTime BeginningDate { get; set; }

        [Required, DisplayName("End Date"), DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Required, DisplayName("Date of Creation"), DataType(DataType.Date)]
        public DateTime DateOfCreation { get; set; }
        
        [DisplayName("Half Day")]
        public bool HalfDayVacation { get; set; }
        
        public bool Accepted { get; set; }

        [Required, DisplayName("Vacation Type")]
        public VacationType VacationType { get; set; }


        [ForeignKey("User")]
        public string ApplicantID { get; private set; }
        [Required]
        public User Applicant { get; set; }
        
        public string? ImageFilePath { get; set; }
        private Vacation()
        {
        }

        public Vacation(DateTime beginningDate, DateTime endDate, VacationType vacationType, User applicant, string? imageFilePath)
        {
            Id = Guid.NewGuid().ToString();
            BeginningDate = beginningDate;
            EndDate = endDate;
            DateOfCreation = DateTime.Now;
            VacationType = vacationType;
            Applicant = applicant;
            ImageFilePath = imageFilePath;
        }
        
    }
}
