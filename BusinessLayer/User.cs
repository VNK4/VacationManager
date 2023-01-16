using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLayer
{
    
    public class User : IdentityUser
    {

        #region Username/Password
        //[Required]
        //public string Username { get; set; }

        //[Required]
        //public string Password { get; set; }
        #endregion

        #region FirstName/LastName

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        #endregion

        #region Role [Role]

        //[Required]
        //public Role Role { get; set; }
        #endregion

        #region Team [Team]

        //[ForeignKey("Team")]
        //public string TeamId { get; set; }

        //[Required]
        public Team Team { get; set; }

        #endregion

        #region Vacations IList
        public IList<Vacation> Vacations { get; set; }

        #endregion


        private User()
        {
        }

        public User(string firstName, string lastName)
        {
            
            FirstName = firstName;
            LastName = lastName;
            this.Team = null;                   //WHY NULL
            Vacations = new List<Vacation>();   //has no list in constructor
            
        }

        public User(string id, string userName, string passwordHash, string firstName, string lastName, Team team)
            : this(firstName, lastName) 
        {
            Id= id;
            UserName= userName;
            PasswordHash= passwordHash;
            Team = team;
        }

        public override string ToString()
        {
            return string.Format($"{Id} {UserName} {PasswordHash} {FirstName} {LastName} {Team}");
        }

        public static explicit operator User(ValueTask<IdentityUser> v) 
        {
            throw new NotImplementedException();
        }

    }
}
