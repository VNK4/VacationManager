using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLayer
{
    public class Team
    {
        [Key]
        public string Id { get; private set; }

        [Required]
        public string Name { get; set; }


        [ForeignKey("Project")]
        public string ProjectId { get; private set; }
        public Project? Project { get; set; }
        

        [ForeignKey("TeamLeader")]
        public string TeamLeaderId { get; private set; }
        public User? TeamLeader { get; set; }

        public IList<User> Users { get; set; } = new List<User>();

        public Team()
        {
        }

        public Team(string name)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
        }

        public Team(string name, Project? project, User? teamLeader) 
            : this(name)
        {
            Name = name;
            Project = project;
            TeamLeader = teamLeader;
        }

        public override string ToString()
        {
            return $"{Id}";
        }
    }
}
