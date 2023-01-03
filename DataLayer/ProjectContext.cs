using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;

namespace DataLayer
{
    public class ProjectContext : IDB<Project, string>
    {
        VacationManagerDbContext context;

        public ProjectContext(VacationManagerDbContext context)
        {
            this.context = context;
        }

        public Task CreateAsync(Project item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string key)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Project>> ReadAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Project> ReadAsync(string key)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Project item)
        {
            throw new NotImplementedException();
        }
    }
}
