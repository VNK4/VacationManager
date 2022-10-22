using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer
{
    public class Project
    {
        [Key]
        public int ID { get; private set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public List<Team> Teams { get; set; }

        public Project()
        {
        }

        public Project(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
