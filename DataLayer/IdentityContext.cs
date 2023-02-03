﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BusinessLayer;

namespace DataLayer
{
    public class IdentityContext
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly VacationManagerDbContext _context;

        public IdentityContext(VacationManagerDbContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager) 
        {
            _context = context; 
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedDataAsync(string adminUsername, string adminPass)
        {
            var admins = _context.Users.Where(u => u.Role == Role.CEO).ToList();
            if (admins.Count == 0)
            {
                await CreateAdminAccountAsync(adminUsername, adminPass);
            }
        }

        private async Task CreateAdminAccountAsync(string username, string password)
        {
            await CreateUserAsync(username, password, "admin", "admin", Role.CEO);
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
                
                IdentityResult result = await _userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
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
                        case Role.CEO:
                            await _userManager.AddToRoleAsync(user, Role.CEO.ToString());
                            break;
                    }
                }
                else
                {
                    throw new ArgumentException("Duplicate username!");
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

        public async Task UpdateUserAsync(string username, string firstName, string lastname, Team team, Role role) 
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

                await _userManager.RemoveFromRoleAsync(user, user.Role.ToString());
                user.Role = role;
                await _userManager.AddToRoleAsync(user, user.Role.ToString());
                await _userManager.UpdateAsync(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task ChangeUserPasswordAsync(User user, string currentPassword, string newPassword)
        {
            await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
        }
    }
}
