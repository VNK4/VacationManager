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

        //[Required]
        public Project Project { get; set; }



        [ForeignKey("TeamLeader")]
        public string TeamLeaderId { get; private set; }

        //[Required]
        public User TeamLeader { get; set; }



        public IList<User> Users { get; set; }

        public Team()
        {
        }

        public Team(string id, string name)
        {
            Id = id;
            Name = name;
            this.Project = null;       //WHY NULL
            this.TeamLeader = null;    //WHY NULL
            this.Users= new List<User>();
            
        }

        public Team(string id, string name, Project project, User teamLeader) 
            : this(id, name)
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
