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
        VacationManagerDbContext context;

        public VacationContext(VacationManagerDbContext context)
        {
            this.context = context;
        }

        public async Task CreateAsync(Vacation item)
        {
            try
            {
                context.Vacations.Add(item);
                await context.SaveChangesAsync();
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
                return await context.Vacations.
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
                return await context.Vacations.
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
                context.Vacations.Update(item);
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
                Vacation vacationFromDb = await context.Vacations.FindAsync(key);
                context.Vacations.Remove(vacationFromDb);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
