using System.Security.Claims;
using ApiaryManagementSystem.Context;
using ApiaryManagementSystem.Extensions;
using ApiaryManagementSystem.Models;
using ApiaryManagementSystem.Services.ApiaryServices;
using ApiaryManagementSystem.Services.InspectionService;
using ApiaryManagementSystem.Services.UserService;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ApiaryManagementSystem.Controllers
{
    [Authorize]
    public class BeeColonyController : Controller
    {
        private readonly IBeeColonyService _service;
        private readonly IInspectionService _inspectionService;
        private readonly ApplicationDbContext _context;

        public BeeColonyController(IBeeColonyService service, IInspectionService inspectionService, ApplicationDbContext context)
        {
            _service = service;
            _inspectionService = inspectionService;
            _context = context;
        }

        public async Task<IActionResult> Index(int apiaryId)
        {
            await User.AddUpdate(HttpContext, "CurrentApiaryId", apiaryId.ToString());

            var colonies = await _service.GetAll();
            var inspections = await _inspectionService.GetAll();

            var colonyIds = colonies.Select(c => c.Id).ToList();

            var lastInspections = inspections
                .Where(i => colonyIds.Contains(i.BeeColonyId))
                .GroupBy(i => i.BeeColonyId)
                .Select(g => g.OrderByDescending(i => i.DateTime).FirstOrDefault())
                .ToDictionary(i => i.BeeColonyId);

            ViewBag.LastInspections = lastInspections;
            return View(colonies.Where(x => x.ApiaryId == apiaryId).ToList());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BeeColony colony)
        {
            if (ModelState.IsValid)
            {
                colony.Id = 0;
                try
                {
                    if (colony.ApiaryId == 0)
                    {
                         colony.ApiaryId = User.GetInt("CurrentApiaryId");
                    }
                }
                catch
                {
                    ViewBag.Message = "Целевая пасека не выбрана";
                    return View();
                }

                try
                {
                    await _service.Create(colony);
                    return RedirectToAction("Index", "BeeColony");
                }
                catch
                {
                    ViewBag.Message = "Ошибка при добавлении пчелосемьи";
                    return View();
                }
            }

            return View(colony);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var colony = await _context.BeeColonies
                .Include(c => c.Apiary)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (colony == null) return NotFound();

            ViewBag.LastInspection = await _context.Inspections
                .Where(i => i.BeeColonyId == id)
                .OrderByDescending(i => i.DateTime)
                .FirstOrDefaultAsync();

            ViewBag.Inspections = await _context.Inspections
                .Where(i => i.BeeColonyId == id)
                .OrderByDescending(i => i.DateTime)
                .Take(10)
                .ToListAsync();

            ViewBag.Queen = await _context.Queens
                .FirstOrDefaultAsync(q => q.BeeColonyId == id);

            ViewBag.Diseases = await _context.ColonyDiseases
                .Include(cd => cd.Disease)
                .Where(cd => cd.Inspection.BeeColonyId == id)
                .ToListAsync();

            ViewBag.Therapies = await _context.Therapies
                .Include(t => t.TherapyType)
                .Where(t => t.Inspection.BeeColonyId == id)
                .ToListAsync();

            ViewBag.Products = await _context.ColonyProducts
                .Include(cp => cp.Product)
                .Include(cp => cp.Unit)
                .Where(cp => cp.BeeColonyId == id)
                .OrderByDescending(cp => cp.HarvestDate)
                .ToListAsync();

            ViewBag.Winterings = await _context.ColonyWinterings
                .Where(cw => cw.BeeColonyId == id)
                .OrderByDescending(cw => cw.StartYear)
                .ToListAsync();

            ViewBag.Notes = await _context.ColonyNotes
                .Where(cn => cn.BeeColonyId == id)
                .OrderByDescending(cn => cn.Date)
                .Take(5)
                .ToListAsync();

            ViewBag.Pollinations = await _context.ColonyPollinations
                .Include(cp => cp.PollinationLocation)
                .Where(cp => cp.BeeColonyId == id)
                .ToListAsync();

            ViewBag.Swarmings = await _context.ColonySwarmings
                .Where(cs => cs.BeeColonyId == id)
                .ToListAsync();

            return View(colony);
        }
    }
}