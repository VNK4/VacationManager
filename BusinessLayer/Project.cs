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
        public string ID { get; private set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public IList<Team> Teams { get; set; }

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
