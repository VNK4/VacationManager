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

public class VacationsController : Controller
{
    private readonly VacationManagerDbContext _context;
    private readonly IDB<Vacation, string> _vacationContext;
    private readonly IdentityContext _identityContext;

    public enum Filter
    {
        Date
    }
    
    public VacationsController(VacationManagerDbContext context, IDB<Vacation, string> vacationContext,
        IdentityContext identityContext)
    {
        _context = context;
        _vacationContext = vacationContext;
        _identityContext = identityContext;

        _context.Vacations.Include(v => v.Applicant).ToList();
        _context.Users.Include(v => v.Team).ToList();
    }
    
    [Authorize(Roles="Unassigned,Developer,CEO,TeamLead")]
    public async Task<IActionResult> Index(string searchString, int filter)
    {
        var vacations = await _vacationContext.ReadAllAsync();
        if (User.IsInRole(Role.CEO.ToString()))
        {
            ViewData["Title"] = "Vacations - CEO";
            
            if (!string.IsNullOrEmpty(searchString))
            {
                vacations = filter switch
                {
                    0 => vacations.Where(p => p.DateOfCreation > DateTime.Parse(searchString)),
                    _ => vacations
                };
            }
        }
        else if (User.IsInRole(Role.TeamLead.ToString()))
        {
            ViewData["Title"] = "Vacations - Team Leader";
            vacations = vacations.Where(v => v.Applicant.Team != null)
                .Where(v => v.Applicant.Team.TeamLeader.UserName == User.Identity.Name);
            if (!string.IsNullOrEmpty(searchString))
            {
                vacations = filter switch
                {
                    0 => vacations.Where(v => v.DateOfCreation > DateTime.Parse(searchString)),
                    _ => vacations
                };
            }
        }
        else
        {
            ViewData["Title"] = "Vacations - User";
            vacations = vacations.Where(v => v.Applicant.UserName == User.Identity.Name);
            if (!string.IsNullOrEmpty(searchString))
            {
                vacations = filter switch
                {
                    0 => vacations.Where(v => v.DateOfCreation > DateTime.Parse(searchString)),
                    _ => vacations
                };
            }
        }

        return View(vacations);
    }
    
    [Authorize(Roles="Unassigned,Developer,CEO,TeamLead")]
    public IActionResult Create()
    {
        ViewData["ApplicantID"] = new SelectList(_context.Users, "Id", "UserName");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles="Unassigned,Developer,CEO,TeamLead")]
    public async Task<IActionResult> Create(
        [Bind("BeginningDate,EndDate,VacationType")] VacationViewModel vacationViewModel)
    {
        if (ModelState.IsValid)
        {
            var beginningDate = vacationViewModel.BeginningDate;
            var endDate = vacationViewModel.EndDate;
            var vacationType = vacationViewModel.VacationType;
            var user = await _identityContext.FindUserByNameAsync(User.Identity.Name);

            var vacation = new Vacation(beginningDate, endDate, vacationType, user);

            await _vacationContext.CreateAsync(vacation);

            return RedirectToAction(nameof(Index));
        }

        return View(vacationViewModel);
    }
    
    [Authorize(Roles="Unassigned,Developer,CEO,TeamLead")]
    public async Task<IActionResult> Info(string id)
    {
        if (id == null || _context.Vacations == null)
        {
            return NotFound();
        }

        var vacation = await _vacationContext.ReadAsync(id);

        if (vacation == null)
        {
            return NotFound();
        }

        return View(ConvertToViewModel(vacation));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles="Unassigned,Developer,CEO,TeamLead")]
    public async Task<IActionResult> Info(string id,
        [Bind("BeginningDate,EndDate,VacationType")]
        VacationViewModel vacationViewModel)
    {
        if (ModelState.IsValid)
        {
            var vacation = await _vacationContext.ReadAsync(id);

            vacation.BeginningDate = vacationViewModel.BeginningDate;
            vacation.EndDate = vacationViewModel.EndDate;
            vacation.HalfDayVacation = false;
            vacation.Accepted = false;
            vacation.VacationType = vacationViewModel.VacationType;

            await _vacationContext.UpdateAsync(vacation);
            return RedirectToAction(nameof(Index));
        }

        return View(vacationViewModel);
    }
    
    [Authorize(Roles="Unassigned,Developer,CEO,TeamLead")]
    public async Task<IActionResult> Delete(string id)
    {
        if (id == null || _context.Vacations == null)
        {
            return NotFound();
        }

        var vacation = await _vacationContext.ReadAsync(id);

        if (vacation == null)
        {
            return NotFound();
        }

        return View(vacation);
    }
    
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    [Authorize(Roles="Unassigned,Developer,CEO,TeamLead")]
    public async Task<IActionResult> DeleteConfirmed(string id)
    {
        if (_context.Vacations == null)
        {
            return Problem("Entity set 'VacationManagerDbContext.Vacations' is null.");
        }

        var vacation = await _vacationContext.ReadAsync(id);

        if (vacation != null)
        {
            await _vacationContext.DeleteAsync(vacation.Id);
        }

        return RedirectToAction(nameof(Index));
    }
    
    [Authorize(Roles = "CEO,TeamLead")]
    public async Task<IActionResult> Approve(string id)
    {
        if (id == null || _context.Vacations == null)
        {
            return NotFound();
        }

        var vacation = await _vacationContext.ReadAsync(id);

        if (vacation == null)
        {
            return NotFound();
        }

        return View(ConvertToViewModel(vacation));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "CEO,TeamLead")]
    public async Task<IActionResult> Approve(string id,
        [Bind("BeginningDate,EndDate,DateOfCreation,HalfDayVacation,VacationType")]
        VacationViewModel vacationViewModel)
    {
        if (ModelState.IsValid)
        {
            var vacation = await _vacationContext.ReadAsync(id);
            
            vacation.HalfDayVacation = vacationViewModel.HalfDayVacation;
            vacation.Accepted = true;

            await _vacationContext.UpdateAsync(vacation);
            return RedirectToAction(nameof(Index));
        }

        return View(vacationViewModel);
    }
    
    [Authorize(Roles = "CEO,TeamLead")]
    public async Task<IActionResult> Reject(string id)
    {
        if (id == null || _context.Vacations == null)
        {
            return NotFound();
        }

        var vacation = await _vacationContext.ReadAsync(id);

        if (vacation == null)
        {
            return NotFound();
        }

        return View(vacation);
    }
    
    [HttpPost, ActionName("Reject")]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "CEO,TeamLead")]
    public async Task<IActionResult> RejectConfirmed(string id)
    {
        if (_context.Vacations == null)
        {
            return Problem("Entity set 'VacationManagerDbContext.Vacations' is null.");
        }

        var vacation = await _vacationContext.ReadAsync(id);

        if (vacation != null)
        {
            await _vacationContext.DeleteAsync(vacation.Id);
        }

        return RedirectToAction(nameof(Index));
    }

    
    [NonAction]
    private static VacationViewModel ConvertToViewModel(Vacation vacation)
    {
        return new VacationViewModel
        {
            Id = vacation.Id,
            BeginningDate = vacation.BeginningDate,
            EndDate = vacation.EndDate,
            DateOfCreation = vacation.DateOfCreation,
            HalfDayVacation = vacation.HalfDayVacation,
            Accepted = vacation.Accepted,
            VacationType = vacation.VacationType,
            Applicant = vacation.Applicant
        };
    }
}