using BusinessLayer;
using DataLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PresentationLayerWeb.Models;

namespace PresentationLayerWeb.Controllers;

[AllowAnonymous]
public class AccountController : Controller
{
    private readonly VacationManagerDbContext _context;
    private readonly IdentityContext _identityContext;
    private readonly SignInManager<User> _signInManager;

    public enum Filter
    {
        Username,
        FirstName,
        LastName,
        Role
    }
    
    public AccountController(VacationManagerDbContext context, IdentityContext identityContext, SignInManager<User> signInManager)
    {
        _context = context;
        _identityContext = identityContext;
        _signInManager = signInManager;
    }
    
    public async Task<IActionResult> Login()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login([Bind("Username,Password,RememberMe")] LoginViewModel loginViewModel)
    {
        var user = await _identityContext.LogInUserAsync(loginViewModel.Username, loginViewModel.Password);

        if (user != null)
        {
            await _signInManager.SignInAsync(user, loginViewModel.RememberMe);
            return RedirectToAction("Index", "Home");
        }
        
        return View(loginViewModel);
        
    }
    
    public async Task<IActionResult> LogOut()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }

    public async Task<IActionResult> AccessDenied()
    {
        return View();
    }
    
}