using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer
{
    [SerializableAttribute]
    public class User
    {
        [Key]
        public int ID { get; private set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public Role Role { get; set; }

        public Team Team { get; set; }

        private User()
        {
        }

        public User(string username, string password, string firstName, string lastName, Role role)
        {
            Username = username;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Role = role;
        }
    }
}
