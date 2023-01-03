using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace BusinessLayer
{
    [Serializable]
    public class User : IdentityUser
    {
        

        //[Required]
        //public string Username { get; set; }

        //[Required]
        //public string Password { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        //[Required]
        //public Role Role { get; set; }

        [Required]
        public Team Team { get; set; }

        public IList<Vacation> Vacations { get; set; }

        private User()
        {
        }

        public User(string firstName, string lastName, Team team)
        {
            
            FirstName = firstName;
            LastName = lastName;
            this.Team = null;
            Vacations = new List<Vacation>();
            
        }

        public User(string id, string userName, string passwordHash, string firstName, string lastName, Team team)
            : this(firstName, lastName, team) 
        {
            Id= id;
            UserName= userName;
            PasswordHash= passwordHash;
            Team = team;
        }

        public override string ToString()
        {
            return string.Format($"{Id} {FirstName} {LastName}");
        }

        public static explicit operator User(ValueTask<IdentityUser> v) 
        {
            throw new NotImplementedException();
        }

    }
}
