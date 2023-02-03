using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLayer
{
    public class Vacation
    {
        [Key]
        public string Id { get; private set; }

        [Required]
        public DateTime BeginningDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public DateTime DateOfCreation { get; set; }
        
        public bool HalfDayVacation { get; set; }
        
        public bool Accepted { get; set; }

        [Required]
        public VacationType VacationType { get; set; }


        [ForeignKey("User")]
        public string ApplicantID { get; private set; }
        [Required]
        public User Applicant { get; set; }

        private Vacation()
        {
        }

        public Vacation(DateTime beginningDate, DateTime endDate, VacationType vacationType, User applicant)
        {
            Id = Guid.NewGuid().ToString();
            BeginningDate = beginningDate;
            EndDate = endDate;
            DateOfCreation = DateTime.Now;
            VacationType = vacationType;
            Applicant = applicant;
        }

        public Vacation(DateTime beginningDate, DateTime endDate, bool halfDayVacation, bool accepted, VacationType vacationType, User applicant)
            : this(beginningDate, endDate, vacationType, applicant)
        {
            HalfDayVacation = halfDayVacation;
            Accepted = accepted;
        }
    }
}