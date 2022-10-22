using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer
{
    public class Vacation
    {
        [Key]
        public int ID { get; private set; }

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

        [Required]
        public User Applicant { get; set; }

        private Vacation()
        {
        }

        public Vacation(DateTime beginningDate, DateTime endDate, DateTime dateOfCreation, bool halfDayVacation, bool accepted, string typeofVacation, User applicant)
        {
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
