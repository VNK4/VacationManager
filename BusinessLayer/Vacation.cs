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

        [Required]
        public bool HalfDayVacation { get; set; }

        [Required]
        public bool Accepted { get; set; }

        [Required]
        public string TypeofVacation { get; set; }


        [ForeignKey("User")]
        public string ApplicantID { get; private set; }
        [Required]
        public User Applicant { get; set; }

        private Vacation()
        {
        }

        public Vacation(string id, DateTime beginningDate, DateTime endDate, DateTime dateOfCreation, bool halfDayVacation, bool accepted, string typeofVacation, User applicant)
        {
            Id = id;
            BeginningDate = beginningDate;
            EndDate = endDate;
            DateOfCreation = dateOfCreation;
            HalfDayVacation = halfDayVacation;
            Accepted = accepted;
            TypeofVacation = typeofVacation;
            Applicant = applicant;
        }
    }
}
