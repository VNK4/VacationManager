using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;

namespace DataLayer
{
    public class VacationContext : IDB<Vacation, string>
    {
        VacationManagerDbContext context;

        public VacationContext(VacationManagerDbContext context)
        {
            this.context = context;
        }

        public Task CreateAsync(Vacation item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string key)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Vacation>> ReadAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Vacation> ReadAsync(string key)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Vacation item)
        {
            throw new NotImplementedException();
        }
    }
}
