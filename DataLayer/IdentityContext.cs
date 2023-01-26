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
        private readonly UserManager<User> _userManager;
        private readonly VacationManagerDbContext _context;

        public IdentityContext(VacationManagerDbContext context, UserManager<User> userManager) 
        {
            _context = context; 
            _userManager = userManager;
        }

        public async Task SeedDataAsync(string adminUsername, string adminPass) 
        {
            var userRoles = await _context.UserRoles.CountAsync();
            if (userRoles == 0)
            {
                await ConfigureAdminAccountAsync(adminUsername, adminPass);
            }
        }

        public async Task ConfigureAdminAccountAsync(string username, string password) 
        {
            var adminIdentityUser = await _context.Users.FirstAsync();
            await _userManager.AddToRoleAsync(adminIdentityUser, Role.CEO.ToString());
            await _userManager.AddPasswordAsync(adminIdentityUser, password);
            await _userManager.SetUserNameAsync(adminIdentityUser, username);
        }

        public async Task CreateUserAsync(string username, string password, string firstname, string lastname, Role role)
        {
            try
            {
                var user = new User
                {
                    UserName = username,
                    FirstName = firstname,
                    LastName = lastname,
                    Role = role
                };
                
                await _userManager.CreateAsync(user, password);

                switch (role)
                {
                    case Role.Developer:
                        await _userManager.AddToRoleAsync(user, Role.Developer.ToString());
                        break;
                    case Role.TeamLead:
                        await _userManager.AddToRoleAsync(user, Role.TeamLead.ToString());
                        break;
                    case Role.Unassigned:
                        await _userManager.AddToRoleAsync(user, Role.Unassigned.ToString());
                        break;
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
                var user = await _userManager.FindByNameAsync(username);

                if (user == null)
                {
                    return null;
                }

                var result = await _userManager.PasswordValidators[0].ValidateAsync(_userManager, user, password);

                if (result.Succeeded)
                {
                    return await _context.Users.FindAsync(user.Id);
                }

                return null;
            }
            catch (Exception ex )
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync() 
        {
            try
            {
                return await _context.Users.ToListAsync();
            }
            catch (Exception ex )
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<User> FindUserByNameAsync(string name) 
        {
            try
            {
                return await _userManager.FindByNameAsync(name);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteUserByNameAsync(string name) 
        {
            try
            {
                var user = await FindUserByNameAsync(name);

                if (user == null)
                {
                    throw new InvalidOperationException("User not found!");
                }

                await _userManager.DeleteAsync(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateUserAsync(string id, string username, string firstName, string lastname, Team team, Role role) 
        {
            try
            {
                var user = await FindUserByNameAsync(username);
                
                if (user == null)
                {
                    throw new InvalidOperationException("User not found!");
                }
                
                user.UserName = username;
                user.FirstName = firstName;
                user.LastName = lastname;
                user.Team = team;
                user.Role = role;

                await _userManager.RemoveFromRoleAsync(user, user.Role.ToString());
                await _userManager.AddToRoleAsync(user, Role.CEO.ToString());
                await _userManager.UpdateAsync(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
