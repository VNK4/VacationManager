using BusinessLayer;
using DataLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PresentationLayerWeb.Models;

namespace PresentationLayerWeb.Controllers;

[Authorize(Roles = "CEO")]
public class UsersController : Controller
{
    private readonly VacationManagerDbContext _context;
    private readonly IdentityContext _identityContext;
    private readonly IDB<Team, string> _teamContext;
    private readonly SignInManager<User> _signInManager;

    public enum Filter
    {
        Username,
        FirstName,
        LastName,
        Role
    }
    
    public UsersController(VacationManagerDbContext context, IdentityContext identityContext, IDB<Team, string> teamContext, SignInManager<User> signInManager)
    {
        _context = context;
        _identityContext = identityContext;
        _teamContext = teamContext;
        _signInManager = signInManager;

        _context.Users.Include(u => u.Team).ToList();
    }
    
    public async Task<IActionResult> Index(string searchString, int filter)
    {
        var users = await _identityContext.GetAllUsersAsync();
        
        if (!string.IsNullOrEmpty(searchString))
        {
            users = filter switch
            {
                0 => users.Where(p => p.UserName.Contains(searchString)),
                1 => users.Where(p => p.FirstName.Contains(searchString)),
                2 => users.Where(p => p.LastName.Contains(searchString)),
                3 => users.Where(p => p.Role.ToString().Contains(searchString)),
                _ => users
            };
        }
        
        return View(users);
    }
    public async Task<IActionResult> Create()
    {
        return View();
    }
    
    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Username,FirstName,LastName,Password,ConfirmPassword,Role")] RegisterViewModel registerViewModel)
    {
        var username = registerViewModel.Username;
        var firstName = registerViewModel.FirstName;
        var lastName = registerViewModel.LastName;
        var password = registerViewModel.Password;
        var confirmation = registerViewModel.ConfirmPassword;
        var role = registerViewModel.Role;

        if (password != confirmation) 
            return View(registerViewModel);
        
        await _identityContext.CreateUserAsync(username, password, firstName, lastName, role);
        return RedirectToAction(nameof(Index));
    }
    
    public async Task<IActionResult> Info(string id)
    {
        if (id == null || _context.Projects == null)
        {
            return NotFound();
        }

        var user = await _context.Users.FindAsync(id);
        
        ViewData["TeamId"] = new SelectList(_context.Teams, "Id", "Name", user.TeamId);
        
        if (user == null)
        {
            return NotFound();
        }

        return View(ConvertToViewModel(user));
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Info(string id, [Bind("Username,FirstName,LastName,Role,TeamId")] UserViewModel userViewModel)
    {
        if (ModelState.IsValid)
        {
            var user = await _context.Users.FindAsync(id);

            var username = userViewModel.Username;
            var firstName = userViewModel.FirstName;
            var lastName = userViewModel.LastName;
            var role = userViewModel.Role;
            var team = await _teamContext.ReadAsync(userViewModel.TeamId);
            
            await _identityContext.UpdateUserAsync(username, firstName, lastName, team, role);
            return RedirectToAction(nameof(Index));
        }

        return View(userViewModel);
    }
    
    public async Task<IActionResult> Delete(string id)
    {
        if (id == null || _context.Projects == null)
        {
            return NotFound();
        }

        var user = await _context.Users.FindAsync(id);
        
        if (user == null)
        {
            return NotFound();
        }

        return View(user);
    }
    
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(string id)
    {
        if (_context.Users == null)
        {
            return Problem("Entity set 'VacationManagerDbContext.Users' is null.");
        }
        
        var user = await _context.Users.FindAsync(id);
        
        if (user != null)
        {
            await _identityContext.DeleteUserByNameAsync(user.UserName);
        }

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> ChangePassword(string id)
    {
        return View();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ChangePassword(string id, [Bind("CurrentPassword,NewPassword,ConfirmPassword")] PasswordViewModel passwordViewModel)
    {
        var user = await _context.Users.FindAsync(id);
        
        if (user != null)
        {
            await _identityContext.ChangeUserPasswordAsync(user, passwordViewModel.CurrentPassword,
                passwordViewModel.NewPassword);
        }

        return RedirectToAction(nameof(Index));
    }
    
    [NonAction]
    private static UserViewModel ConvertToViewModel(User user)
    {
        return new UserViewModel
        {
            Id = user.Id,
            Username = user.UserName,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Role = user.Role,
            Team = user.Team
        };
    }
}