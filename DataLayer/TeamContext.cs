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
        private readonly VacationManagerDbContext _context;

        public TeamContext(VacationManagerDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Team item)
        {
            try
            {
                _context.Teams.Add(item);
                await _context.SaveChangesAsync();
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
                return await _context.Teams.
                    Include(p => p.Project).
                    Include(t => t.TeamLeader).
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
                return await _context.Teams.
                    Include(p => p.Project).
                    Include(t => t.TeamLeader).
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
                _context.Teams.Update(item);
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
                var teamFromDb = await _context.Teams.FindAsync(key);
                _context.Teams.Remove(teamFromDb);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
