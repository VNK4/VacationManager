using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [Required, DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required, DisplayName("Last Name")]
        public string LastName { get; set; }
        [ForeignKey("Team")]
        public string? TeamId { get; set; }
        public Team? Team { get; set; }
        public IList<Vacation> Vacations { get; set; } = new List<Vacation>();
        
        [Required]
        public Role Role { get; set; }
    }
}
