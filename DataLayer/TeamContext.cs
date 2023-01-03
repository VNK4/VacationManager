using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;

namespace DataLayer
{
    public class TeamContext : IDB<Team, string>
    {
        VacationManagerDbContext context;

        public TeamContext(VacationManagerDbContext context)
        {
            this.context = context;
        }

        public Task CreateAsync(Team item)
        {
            throw new NotImplementedException();
        }

        

        public Task<IEnumerable<Team>> ReadAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Team> ReadAsync(string key)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Team item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string key)
        {
            throw new NotImplementedException();
        }
    }
}
