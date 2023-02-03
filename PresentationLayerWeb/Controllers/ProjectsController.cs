using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessLayer;
using DataLayer;
using Microsoft.AspNetCore.Authorization;
using PresentationLayerWeb.Models;

namespace PresentationLayerWeb.Controllers;

[Authorize(Roles = "CEO")]
public class ProjectsController : Controller
{
    private readonly VacationManagerDbContext _context;
    private readonly IDB<Project, string> _projectContext;

    public enum Filter
    {
        Name,
        Description
    }

    public ProjectsController(VacationManagerDbContext context, IDB<Project, string> projectContext)
    {
        _context = context;
        _projectContext = projectContext;
        _context.Projects.Include(p => p.Teams).ToList();
        _context.Teams.Include(t => t.TeamLeader).ToList();
    }
    
    public async Task<IActionResult> Index(string searchString, int filter)
    {
        var projects = await _projectContext.ReadAllAsync();
        
        if (!string.IsNullOrEmpty(searchString))
        {
            projects = filter switch
            {
                0 => projects.Where(p => p.Name.Contains(searchString)),
                1 => projects.Where(p => p.Description.Contains(searchString)),
                _ => projects
            };
        }
        
        return View(projects);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Name,Description")] ProjectViewModel projectViewModel)
    {
        if (ModelState.IsValid)
        {
            var name = projectViewModel.Name;
            var description = projectViewModel.Description;

            var project = new Project(name, description);

            await _projectContext.CreateAsync(project);
            return RedirectToAction(nameof(Index));
        }

        return View(projectViewModel);
    }

    public async Task<IActionResult> Info(string id)
    {
        if (id == null || _context.Projects == null)
        {
            return NotFound();
        }

        var project = await _context.Projects.FindAsync(id);
        if (project == null)
        {
            return NotFound();
        }

        return View(ConvertToViewModel(project));
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Info(string id, [Bind("Name,Description")] ProjectViewModel projectViewModel)
    {
        if (ModelState.IsValid)
        {
            var project = await _projectContext.ReadAsync(id);

            project.Name = projectViewModel.Name;
            project.Description = projectViewModel.Description;
            
            await _projectContext.UpdateAsync(project);
            return RedirectToAction(nameof(Index));
        }

        return View(projectViewModel);
    }

    public async Task<IActionResult> Delete(string id)
    {
        if (id == null || _context.Projects == null)
        {
            return NotFound();
        }

        var project = await _projectContext.ReadAsync(id);
        
        if (project == null)
        {
            return NotFound();
        }

        return View(project);
    }
    
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(string id)
    {
        if (_context.Projects == null)
        {
            return Problem("Entity set 'VacationManagerDbContext.Projects' is null.");
        }
        
        var project = await _projectContext.ReadAsync(id);
        
        if (project != null)
        {
            await _projectContext.DeleteAsync(project.Id);
        }

        return RedirectToAction(nameof(Index));
    }

    [NonAction]
    private static ProjectViewModel ConvertToViewModel(Project project)
    {
        return new ProjectViewModel
        {
            Id = project.Id,
            Name = project.Name,
            Description = project.Description,
            Teams = project.Teams
        };
    }
}