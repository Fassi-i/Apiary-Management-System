using Microsoft.AspNetCore.Mvc;
using ApiaryManagementSystem.ViewModels;
using ApiaryManagementSystem.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using ApiaryManagementSystem.Models;
using ApiaryManagementSystem.Services.InspectionService;
using System.Security.Claims;
using ApiaryManagementSystem.Services.ApiaryServices;

namespace ApiaryManagementSystem.Controllers
{
    public class InspectionController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IInspectionService _inspectionService;
        private readonly IBeeColonyService _beeColonyService;

        public InspectionController(ApplicationDbContext context, IInspectionService inspectionService, IBeeColonyService beeColonyService)
        {
            _context = context;
            _inspectionService = inspectionService;
            _beeColonyService = beeColonyService;
        }

        public async Task<IActionResult> Details(int id)
        {
            var inspections = await _inspectionService.GetAll();
            var apiary = await _beeColonyService.GetById(id);

            inspections = inspections.Where(i => i.BeeColonyId == id).OrderByDescending(i => i.DateTime).ToList();

            ViewBag.ApiaryNumber = apiary.Number;
            ViewBag.ApiaryId = apiary.Id;
            return View(inspections);
        }

        public async Task<IActionResult> Create(int id)
        {
            var now = DateOnly.FromDateTime(DateTime.Now);

            var currentQueen = await _context.Queens
                .Include(i => i.BeeColony)
                .FirstOrDefaultAsync(q => q.BeeColonyId == id && (q.EndDate == null || q.EndDate > now));

            var currentBeeColony = currentQueen?.BeeColony;

            var queens = await _context.Queens
                .Where(q => q.EndDate == null || q.EndDate > now)
                .Select(q => new SelectListItem
                {
                    Value = q.Id.ToString(),
                    Text = q.BeeColonyId.HasValue
                        ? $"{q.Breed} {q.Line} {q.StartDate} - семья №{q.BeeColonyId}"
                        : $"{q.Breed} {q.Line} {q.StartDate} - свободна"
                })
                .ToListAsync();

            var apearies = await _context.Apiaries
                //Если нужны все пасеки - убрать Where
                .Where(a => a.OwnerId == Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                .Select(q => new SelectListItem
                {
                    Value = q.Id.ToString(),
                    Text = q.Name + " " + q.Address
                })
                .ToListAsync();

            var lastInspection = await _inspectionService.GetLast(id) ?? new Inspection();
            lastInspection.DateTime = DateTime.Now;
            lastInspection.Notes = string.Empty;

            return View(new InspectionCreateViewModel(id)
            {
                Queens = queens,
                QueenId = currentQueen?.Id,
                Inspection = lastInspection,
                Apearies = apearies,
                ApiatyId = currentBeeColony?.ApiaryId,
                BeeColony = currentBeeColony
            });
        }
    }
}
