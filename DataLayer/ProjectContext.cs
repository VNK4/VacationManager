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
        VacationManagerDbContext context;

        public ProjectContext(VacationManagerDbContext context)
        {
            this.context = context;
        }

        public async Task CreateAsync(Project item)
        {
            try
            {
                //TODO: Add team list 

                context.Projects.Add(item);
                await context.SaveChangesAsync();
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
                Project projectFromDb = await context.Projects.FindAsync(key);
                context.Projects.Remove(projectFromDb);
                await context.SaveChangesAsync();
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
                return await context.Projects.Include(t=> t.Teams).ToListAsync();
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
                return await context.Projects.
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
                context.Projects.Update(item);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
