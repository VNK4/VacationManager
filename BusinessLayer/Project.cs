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
        public string Id { get; private set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public IList<Team> Teams { get; set; }

        public Project()
        {
        }

        public Project(string id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
            Teams = new List<Team>();
        }
        
    }
}
