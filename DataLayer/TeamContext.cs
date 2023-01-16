using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class TeamContext : IDB<Team, string>
    {
        VacationManagerDbContext context;

        public TeamContext(VacationManagerDbContext context)
        {
            this.context = context;
        }

        public async Task CreateAsync(Team item)
        {
            try
            {
                context.Teams.Add(item);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Team>> ReadAllAsync()
        {
            try
            {
                return await context.Teams.
                    Include(p => p.Project).
                    Include(t => t.TeamLeaderId).
                    Include(u => u.Users).
                    ToArrayAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Team> ReadAsync(string key)
        {
            try
            {
                return await context.Teams.
                     Include(p => p.Project).
                    Include(t => t.TeamLeaderId).
                    Include(u => u.Users).
                    SingleAsync(t => t.Id == key);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message); 
            }
        }

        public async Task UpdateAsync(Team item)
        {
            try
            {
                context.Teams.Update(item);
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
                Team teamFromDb = await context.Teams.FindAsync(key);
                context.Teams.Remove(teamFromDb);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
