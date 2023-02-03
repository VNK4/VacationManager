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

namespace PresentationLayerWeb.Controllers
{
    [Authorize(Roles = "CEO")]
    public class TeamsController : Controller
    {
        private readonly VacationManagerDbContext _context;
        private readonly IDB<Team, string> _teamContext;
        private readonly IDB<Project, string> _projectContext;
        private readonly IdentityContext _identityContext;
        
        public enum Filter
        {
            Team,
            Project
        }
        
        public TeamsController(VacationManagerDbContext context, IDB<Team, string> teamContext,
            IDB<Project, string> projectContext, IdentityContext identityContext)
        {
            _context = context;
            _teamContext = teamContext;
            _projectContext = projectContext;
            _identityContext = identityContext;

            _context.Teams.Include(t => t.Project).ToList();
            _context.Teams.Include(t => t.TeamLeader).ToList();
        }
        
        public async Task<IActionResult> Index(string searchString, int filter)
        {
            var teams = await _teamContext.ReadAllAsync();
        
            if (!string.IsNullOrEmpty(searchString))
            {
                teams = filter switch
                {
                    0 => teams.Where(t => t.Name.Contains(searchString)),
                    1 => teams.Where(t => t.Project.Name.Contains(searchString)),
                    _ => teams
                };
            }
        
            return View(teams);
        }
        
        public IActionResult Create()
        {
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Name");
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,ProjectId")] TeamViewModel teamViewModel)
        {
            if (ModelState.IsValid)
            {
                var name = teamViewModel.Name;
                var project = await _projectContext.ReadAsync(teamViewModel.ProjectId);

                var team = new Team(name, project);

                await _teamContext.CreateAsync(team);

                return RedirectToAction(nameof(Index));
            }

            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Name");

            return View(teamViewModel);
        }
        
        public async Task<IActionResult> Info(string id)
        {
            if (id == null || _context.Teams == null)
            {
                return NotFound();
            }

            var team = await _teamContext.ReadAsync(id);

            if (team == null)
            {
                return NotFound();
            }

            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Name", team.ProjectId);
            List<User> teamLeaders =
                (from u in _context.Users
                    where u.Role == Role.TeamLead
                    select u).ToList();
            ViewData["TeamLeaderId"] = new SelectList(teamLeaders, "Id", "UserName", team.TeamLeaderId);
            return View(ConvertToViewModel(team));
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Info(string id, [Bind("Name,ProjectId,TeamLeaderId")] TeamViewModel teamViewModel)
        {
            if (ModelState.IsValid)
            {
                var team = await _teamContext.ReadAsync(id);

                team.Name = teamViewModel.Name;
                team.ProjectId = teamViewModel.ProjectId;  
                team.TeamLeaderId = teamViewModel.TeamLeaderId;

                var user = await _context.Users.FindAsync(teamViewModel.TeamLeaderId);

                await _identityContext.UpdateUserAsync(user.UserName, user.FirstName, user.LastName, team, user.Role);
                
                await _teamContext.UpdateAsync(team);
                return RedirectToAction(nameof(Index));
            }

            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Name", teamViewModel.ProjectId);
            List<User> teamLeaders =
                (from u in _context.Users
                    where u.Role == Role.TeamLead
                    select u).ToList();
            ViewData["TeamLeaderId"] = new SelectList(teamLeaders, "Id", "UserName", teamViewModel.TeamLeaderId);
            return View(teamViewModel);
        }
        
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Teams == null)
            {
                return NotFound();
            }

            var team = await _context.Teams
                .Include(t => t.Project)
                .Include(t => t.TeamLeader)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Teams == null)
            {
                return Problem("Entity set 'VacationManagerDbContext.Teams'  is null.");
            }

            var team = await _teamContext.ReadAsync(id);
            
            if (team != null)
            {
                _context.Teams.Remove(team);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [NonAction]
        private static TeamViewModel ConvertToViewModel(Team team)
        {
            return new TeamViewModel
            {
                Id = team.Id,
                Name = team.Name,
                ProjectId = team.ProjectId,
                TeamLeaderId = team.TeamLeaderId,
                Users = team.Users
            };
        }
    }
}