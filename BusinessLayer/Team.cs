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
        public string ID { get; private set; }

        [Required]
        public string Name { get; set; }


        [ForeignKey("Project")]
        public string ProjectId { get; private set; }

        [Required]
        public Project Project { get; set; }


        [ForeignKey("TeamLeader")]
        public string TeamLeaderId { get; private set; }

        public User TeamLeader { get; set; }



        public IList<User> Users { get; set; }

        public Team()
        {
        }

        public Team(string id, string name, Project project, User teamLeader)
        {
            ID = id;
            Name = name;
            this.Project = null;
            this.TeamLeader = null;
            
        }

        public Team(string iD, string name, Project project, User teamLeader, IList<User> users) 
            : this(iD, name, project,teamLeader)
        {
            Name = name;
            Project = project;
            TeamLeader = teamLeader;
            Users = users;
        }
    }
}
