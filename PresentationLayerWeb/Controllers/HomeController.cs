using System.Diagnostics;
using DataLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PresentationLayerWeb.Models;

namespace PresentationLayerWeb.Controllers;

[AllowAnonymous]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IdentityContext _identityContext;
    
    public HomeController(ILogger<HomeController> logger, IdentityContext identityContext)
    {
        _logger = logger;
        _identityContext = identityContext;
    }

    public async Task<IActionResult> Index()
    {
        await _identityContext.SeedDataAsync("administrator", "admin123");
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}