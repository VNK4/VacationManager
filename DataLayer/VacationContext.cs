using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class VacationContext : IDB<Vacation, string>
    {
        private readonly VacationManagerDbContext _context;

        public VacationContext(VacationManagerDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Vacation item)
        {
            try
            {
                _context.Vacations.Add(item);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Vacation> ReadAsync(string key)
        {
            try
            {
                return await _context.Vacations.
                    Include(u => u.Applicant).
                    SingleAsync(v => v.Id == key);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Vacation>> ReadAllAsync()
        {
            try
            {
                return await _context.Vacations.
                    Include(u=> u.Applicant).
                    ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateAsync(Vacation item)
        {
            try
            {
                _context.Vacations.Update(item);
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
                var vacationFromDb = await _context.Vacations.FindAsync(key);
                _context.Vacations.Remove(vacationFromDb);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
