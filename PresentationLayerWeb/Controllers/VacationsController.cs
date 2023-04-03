using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
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
    private readonly IWebHostEnvironment _webHostEnvironment;

    public enum Filter
    {
        Date
    }

    public VacationsController(VacationManagerDbContext context, IDB<Vacation, string> vacationContext,
        IdentityContext identityContext, IWebHostEnvironment webHostEnvironment)
    {
        _context = context;
        _vacationContext = vacationContext;
        _identityContext = identityContext;
        _webHostEnvironment = webHostEnvironment;

        _context.Vacations.Include(v => v.Applicant).ToList();
        _context.Users.Include(v => v.Team).ToList();
    }

    [Authorize(Roles = "Unassigned,Developer,CEO,TeamLead")]
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

    [Authorize(Roles = "Unassigned,Developer,CEO,TeamLead")]
    public IActionResult Create()
    {
        ViewData["ApplicantID"] = new SelectList(_context.Users, "Id", "UserName");
        return View(new VacationViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Unassigned,Developer,CEO,TeamLead")]
    public async Task<IActionResult> Create(
        [Bind("BeginningDate,EndDate,VacationType,VacationImage")]
        VacationViewModel vacationViewModel)
    {
        if (!ModelState.IsValid)
            return View(vacationViewModel);

        var beginningDate = vacationViewModel.BeginningDate;
        var endDate = vacationViewModel.EndDate;
        var vacationType = vacationViewModel.VacationType;
        var img = vacationViewModel.VacationImage;
        var user = await _identityContext.FindUserByNameAsync(User.Identity.Name);
        var filePath = string.Empty;
        if (img != null)
        {
            var uniqueFileName = CreateUniqueFileName(img.FileName);
            var uploads = Path.Combine(_webHostEnvironment.WebRootPath, "images");
            filePath = Path.Combine(uploads, uniqueFileName);
            await vacationViewModel.VacationImage.CopyToAsync(new FileStream(filePath, FileMode.Create));
            filePath = uniqueFileName;
        }

        var vacation = new Vacation(beginningDate, endDate, vacationType, user, filePath);

        await _vacationContext.CreateAsync(vacation);

        return RedirectToAction(nameof(Index));
    }

    [Authorize(Roles = "Unassigned,Developer,CEO,TeamLead")]
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
    [Authorize(Roles = "Unassigned,Developer,CEO,TeamLead")]
    public async Task<IActionResult> Info(string id,
        [Bind("BeginningDate,EndDate,VacationType,VacationImage")]
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
            
            var img = vacationViewModel.VacationImage;
            var filePath = string.Empty;
            if (img != null)
            {
                var uniqueFileName = CreateUniqueFileName(img.FileName);
                if(!Directory.Exists(Path.Combine(_webHostEnvironment.WebRootPath, "images")))
                {
                    Directory.CreateDirectory(Path.Combine(_webHostEnvironment.WebRootPath, "images"));
                }
                var uploads = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                filePath = Path.Combine(uploads, uniqueFileName);
                await vacationViewModel.VacationImage.CopyToAsync(new FileStream(filePath, FileMode.Create));
                filePath = uniqueFileName;
                System.IO.File.Delete(Path.Combine(_webHostEnvironment.WebRootPath, "images", vacation.ImageFilePath));
                vacation.ImageFilePath = filePath;
            }
            
            await _vacationContext.UpdateAsync(vacation);
            return RedirectToAction(nameof(Index));
        }

        return View(vacationViewModel);
    }

    [Authorize(Roles = "Unassigned,Developer,CEO,TeamLead")]
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
    [Authorize(Roles = "Unassigned,Developer,CEO,TeamLead")]
    public async Task<IActionResult> DeleteConfirmed(string id)
    {
        if (_context.Vacations == null)
        {
            return Problem("Entity set 'VacationManagerDbContext.Vacations' is null.");
        }

        var vacation = await _vacationContext.ReadAsync(id);

        if (vacation != null)
        {
            if (vacation.ImageFilePath != string.Empty)
            {
                var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", vacation.ImageFilePath);
                System.IO.File.Delete(Path.Combine(_webHostEnvironment.WebRootPath, "images", vacation.ImageFilePath));
            }
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
            if (vacation.ImageFilePath != string.Empty)
            {
                var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", vacation.ImageFilePath);
                System.IO.File.Delete(filePath);
            }
            await _vacationContext.DeleteAsync(vacation.Id);
        }

        return RedirectToAction(nameof(Index));
    }

    private static string CreateUniqueFileName(string fileName)
    {
        fileName = Path.GetFileName(fileName);
        return string.Concat(Path.GetFileNameWithoutExtension(fileName),
            "_",
            Guid.NewGuid().ToString().AsSpan(0, 4),
            Path.GetExtension(fileName));
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
            Applicant = vacation.Applicant,
            ImageFilePath = vacation.ImageFilePath
        };
    }
}