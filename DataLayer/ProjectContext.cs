using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class ProjectContext : IDB<Project, string>
    {
        private readonly VacationManagerDbContext _context;

        public ProjectContext(VacationManagerDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Project item)
        {
            try
            {
                _context.Projects.Add(item);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteAsync(string key)
        {
            try
            {
                var projectFromDb = await _context.Projects.FindAsync(key);
                _context.Projects.Remove(projectFromDb);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Project>> ReadAllAsync()
        {
            try
            {
                return await _context.Projects.Include(t=> t.Teams).ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Project> ReadAsync(string key)
        {
            try
            {
                return await _context.Projects.
                    Include(t => t.Teams).
                    SingleAsync(m => m.Id == key);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateAsync(Project item)
        {
            try
            {
                _context.Projects.Update(item);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
