using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer
{
    public class Team
    {
        [Key]
        public int ID { get; private set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Project Project { get; set; }

        public User TeamLeader { get; set; }

        public Team()
        {
        }

        public Team(string name, Project project)
        {
            Name = name;
            Project = project;
        }
    }
}
