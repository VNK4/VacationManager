using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BusinessLayer;

namespace DataLayer
{
    class IdentityContext
    {
        UserManager<IdentityUser> userManager;
        ProjectContext projectContext;
        TeamContext teamContext;
        VacationContext vacationContext;
        VacationManagerDbContext context;

        public IdentityContext(VacationManagerDbContext context, UserManager<IdentityUser> userManager) 
        {
            this.context = context; 
            this.userManager = userManager;
            projectContext = new ProjectContext(context);
            vacationContext = new VacationContext(context);
            teamContext = new TeamContext(context);
            
        }

        public async Task SeedDataAsync(string adminPass, string adminUsername) 
        {
            int userRoles = await context.UserRoles.CountAsync();
            if (userRoles == 0)
            {
                await ConfigureAdminAccountAsync(adminPass, adminUsername);
            }
        }

        public async Task ConfigureAdminAccountAsync(string password, string username) 
        {
            IdentityUser adminIdentityUser = await context.Users.FirstAsync();
            await userManager.AddToRoleAsync(adminIdentityUser, Role.CEO.ToString());
            await userManager.AddPasswordAsync(adminIdentityUser, password);
            await userManager.SetUserNameAsync(adminIdentityUser, username);
        }

        public async Task CreateUserAsync(string username, string password, string firstname, string lastname, Role role, Team team, IList<Vacation> vacations) 
        {
            try
            {
                IdentityUser identityUser = new IdentityUser(username);
                identityUser.UserName = username;
                await userManager.CreateAsync(identityUser, password);

                if (role == Role.CEO)
                {
                    await userManager.AddToRoleAsync(identityUser, Role.CEO.ToString());
                }
                else
                {
                    await userManager.AddToRoleAsync(identityUser, Role.Unassigned.ToString());
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<User> LogInUserAsync(string username, string password) 
        {
            try
            {
                IdentityUser identityUser = await userManager.FindByNameAsync(username);

                if (identityUser == null)
                {
                    return null;
                }

                IdentityResult result = await userManager.PasswordValidators[0].ValidateAsync(userManager, identityUser, password);

                if (result.Succeeded)
                {
                    return (User)await context.Users.FindAsync(identityUser.Id);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex )
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync() 
        {
            try
            {
                return (IEnumerable < User >) await context.Users.ToListAsync();
            }
            catch (Exception ex )
            {

                throw ex;
            }
        }

        public async Task<User> FindUserbyNameAsync(string name) 
        {
            try
            {
                return (User)await userManager.FindByNameAsync(name);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task DeleteUserByNameAsync(string name) 
        {
            try
            {
                User user = await FindUserbyNameAsync(name);

                if (user == null)
                {
                    throw new InvalidOperationException("User not found!");
                }

                await userManager.DeleteAsync(user);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task UpdateUserAsync(string id, string firstName, string lastname) 
        {
            
        }
    }
}
