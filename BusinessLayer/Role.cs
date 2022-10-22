using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer
{
    public class Role
    {
        [Key]
        public int ID { get; private set; }

        [Required]
        public string Name { get; set; }

        public List<User> User { get; set; }

        public Role()
        {
        }

        public Role(string name)
        {
            Name = name;
        }
    }
}
