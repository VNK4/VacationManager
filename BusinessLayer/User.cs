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
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public Team? Team { get; set; }
        public IList<Vacation> Vacations { get; set; } = new List<Vacation>();
        
        [Required]
        public Role Role { get; set; }

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
