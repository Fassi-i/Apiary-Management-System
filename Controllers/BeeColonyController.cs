using System.Security.Claims;
using ApiaryManagementSystem.Context;
using ApiaryManagementSystem.Extensions;
using ApiaryManagementSystem.Models;
using ApiaryManagementSystem.Services.ApiaryServices;
using ApiaryManagementSystem.Services.InspectionService;
using ApiaryManagementSystem.Services.QueenService;
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
        private readonly IApiaryService _apiaryService;
        private readonly IQueenService _queenService;
        private readonly ApplicationDbContext _context;

        public BeeColonyController(IQueenService queenService, IBeeColonyService service, IApiaryService apiaryService, IInspectionService inspectionService, ApplicationDbContext context)
        {
            _service = service;
            _inspectionService = inspectionService;
            _apiaryService = apiaryService;
            _queenService = queenService;
            _context = context;
        }

        public async Task<IActionResult> Index(int apiaryId)
        {
            await User.AddUpdate(HttpContext, "CurrentApiaryId", apiaryId.ToString());

            var colonies = await _service.GetAll();
            var inspections = await _inspectionService.GetAll();

            var filteredColonies = colonies.Where(x => x.ApiaryId == apiaryId);

            var sortedColonies = filteredColonies
                .OrderBy(c => c.DisbandmentDate)
                .ThenBy(c => c.Number)
                .ToList();

            var colonyIds = sortedColonies.Select(c => c.Id).ToList();

            var lastInspections = inspections
                .Where(i => colonyIds.Contains(i.BeeColonyId))
                .GroupBy(i => i.BeeColonyId)
                .Select(g => g.OrderByDescending(i => i.DateTime).FirstOrDefault())
                .Where(i => i != null)
                .ToDictionary(i => i.BeeColonyId);

            ViewBag.LastInspections = lastInspections;
            return View(sortedColonies);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var apiaries = await _apiaryService.GetAll();
            var apiariesList = apiaries
                .Where(a => a.Owner?.Id == Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier)))
                .Select(a => new SelectListItem
                {
                    Value = a.Id.ToString(),
                    Text = a.Name
                })
                .ToList();

            ViewBag.Apiaries = apiariesList;
            ViewBag.CurrentApiary = User.GetInt("CurrentApiaryId");

            var model = new BeeColony
            {
                Id = 0
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var apiaries = await _apiaryService.GetAll();
            var apiariesList = apiaries
                .Where(a => a.Owner?.Id == Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier)))
                .Select(a => new SelectListItem
                {
                    Value = a.Id.ToString(),
                    Text = a.Name
                })
                .ToList();

            ViewBag.Apiaries = apiariesList;
            ViewBag.CurrentApiary = User.GetInt("CurrentApiaryId");

            var beeColony = await _service.GetById(id);

            if (beeColony == null)
                return NotFound();

            return View(beeColony);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BeeColony colony)
        {
            if (!ModelState.IsValid)
            {
                var apiaries = await _apiaryService.GetAll();
                var apiariesList = apiaries
                    .Where(a => a.Owner?.Id == Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier)))
                    .Select(a => new SelectListItem
                    {
                        Value = a.Id.ToString(),
                        Text = a.Name
                    })
                    .ToList();

                ViewBag.Apiaries = apiariesList;
                ViewBag.CurrentApiary = User.GetInt("CurrentApiaryId");

                return View(colony);
            }

            await _service.Update(colony);

            // если админ или старший пчеловод — на AdminIndex
            if (User.IsInRole("Администратор") || User.IsInRole("Старший пчеловод"))
                return RedirectToAction("AdminIndex", "BeeColony");

            // обычный пчеловод — на Details
            return RedirectToAction("Details", new { id = colony.Id });
        }

        [HttpPost]
        public async Task<IActionResult> Create(BeeColony colony)
        {
            var curap = User.GetInt("CurrentApiaryId");

            if (colony.ApiaryId == 0 && curap != null)
            {
                colony.ApiaryId = curap;
                ModelState.Remove(nameof(colony.ApiaryId));
            }

            if (!ModelState.IsValid)
            {
                await FillApiariesViewBag();
                return View(colony);
            }

            colony.Id = 0;
            colony.CreationDate = DateTime.Now;

            try
            {
                await _service.Create(colony);
            }
            catch
            {
                await FillApiariesViewBag();
                return View(colony);
            }

            return RedirectToAction("Index", "BeeColony", new { apiaryId = colony.ApiaryId });
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var colony = await _context.BeeColonies
                .Include(c => c.Apiary)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (colony == null) return NotFound();
            if ((colony.ApiaryId != User.GetInt("CurrentApiaryId")) && User.IsInRole("Beekeeper")) 
                return RedirectToAction("AccessError", "Account");

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
                .Where(t => t.Inspection.BeeColonyId == id)
                .ToListAsync();

            ViewBag.Products = await _context.ColonyProducts
                .Where(cp => cp.BeeColonyId == id)
                .OrderByDescending(cp => cp.HarvestDate)
                .ToListAsync();

            ViewBag.Winterings = await _context.ColonyWinterings
                .Where(cw => cw.BeeColonyId == id)
                .OrderByDescending(cw => cw.StartYear)
                .ToListAsync();

            ViewBag.Notes = await _context.Inspections
                .Where(cn => cn.BeeColonyId == id)
                .Where(cn => cn.Notes != null)
                .OrderByDescending(cn => cn.DateTime)
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

        [HttpGet]
        public async Task<IActionResult> Disband(int id)
        {
            var colony = await _context.BeeColonies
                .Include(c => c.Apiary)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (colony == null) return NotFound();

            colony.DisbandmentDate = DateTime.Now;
            await _service.Update(colony);
            return RedirectToAction("Index", "BeeColony", new { apiaryId = colony.ApiaryId });
        }

        [HttpGet]
        public async Task<IActionResult> Restore(int id)
        {
            var colony = await _context.BeeColonies
                .Include(c => c.Apiary)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (colony == null) return NotFound();

            colony.DisbandmentDate = null;
            await _service.Update(colony);
            return RedirectToAction("Index", "BeeColony", new { apiaryId = colony.ApiaryId });
        }
        [Authorize(Policy = "SeniorBeekeeper")]
        public async Task<IActionResult> AdminIndex(int? apiaryId)
        {
            // Список пасек для выпадающего списка (Id + Name)
            ViewBag.Apiaries = await _context.Apiaries
                .OrderBy(a => a.Name)
                .Select(a => new SelectListItem
                {
                    Value = a.Id.ToString(), // фильтрация по Id
                    Text = a.Name            // показываем НАЗВАНИЕ пасеки
                })
                .ToListAsync();

            ViewData["CurrentApiary"] = apiaryId?.ToString();

            var query = _context.Apiaries
                .Include(a => a.Owner)
                .AsQueryable();

            // ФИЛЬТР: показываем только выбранную пасеку по её Id
            if (apiaryId.HasValue)
            {
                query = query.Where(a => a.Id == apiaryId.Value);
            }

            var apiaries = await query.ToListAsync();

            return View(apiaries);
        }








        [HttpGet]
        [Authorize(Policy = "SeniorBeekeeper")]
        public async Task<IActionResult> Delete(int id)
        {
            var queens = _context.Queens.ToList();
            foreach (var queen in queens)
            {
                if(queen.BeeColonyId == id)
                {
                    queen.BeeColonyId = null;
                    await _queenService.Update(queen);
                }
            }
            await _service.Delete(id);
            return RedirectToAction("AdminIndex", "BeeColony");
        }

        private async Task FillApiariesViewBag()
        {
            var apiaries = await _apiaryService.GetAll();
            var apiariesList = apiaries
                .Where(a => a.Owner?.Id == Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier)))
                .Select(a => new SelectListItem
                {
                    Value = a.Id.ToString(),
                    Text = a.Name
                })
                .ToList();

            ViewBag.Apiaries = apiariesList;
            ViewBag.CurrentApiary = User.GetInt("CurrentApiaryId");
        }

        [HttpGet]
        [Authorize(Policy = "AnyBeekeeper")] // доступ только пчеловодам и выше
        public async Task<IActionResult> ManageApiaries()
        {
            var userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));

            bool isAdmin = User.IsInRole("Администратор");
            bool isSenior = User.IsInRole("Старший пчеловод") || isAdmin;
            bool isBeekeeper = User.IsInRole("Пчеловод");

            IQueryable<BeeColony> query = _context.BeeColonies
                .Include(c => c.Apiary);

            IQueryable<Apiary> apiariesQuery = _context.Apiaries;

            if (isSenior)
            {
                // старший пчеловод/админ видит всё
            }
            else if (isBeekeeper)
            {
                // обычный пчеловод — только свои пасеки и семьи на них
                query = query.Where(c => c.Apiary.OwnerId == userId);
                apiariesQuery = apiariesQuery.Where(a => a.OwnerId == userId);
            }

            var colonies = await query
                .OrderBy(c => c.Apiary.Name)
                .ThenBy(c => c.Number)
                .ToListAsync();

            var apiaries = await apiariesQuery
                .OrderBy(a => a.Name)
                .Select(a => new SelectListItem
                {
                    Value = a.Id.ToString(),
                    Text = a.Name
                })
                .ToListAsync();

            ViewBag.Apiaries = apiaries;

            return View(colonies);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "AnyBeekeeper")]
        public async Task<IActionResult> ChangeApiary(int id, int apiaryId)
        {
            var colony = await _context.BeeColonies
                .Include(c => c.Apiary)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (colony == null)
                return NotFound();

            var userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            bool isAdmin = User.IsInRole("Администратор");
            bool isSenior = User.IsInRole("Старший пчеловод") || isAdmin;
            bool isBeekeeper = User.IsInRole("Пчеловод");

            if (!isSenior && isBeekeeper)
            {
                // пчеловод может менять только между СВОИМИ пасеками
                var allowedApiaryIds = await _context.Apiaries
                    .Where(a => a.OwnerId == userId)
                    .Select(a => a.Id)
                    .ToListAsync();

                // нельзя пересадить семью на чужую пасеку
                if (!allowedApiaryIds.Contains(apiaryId))
                    return Forbid();

                // и нельзя трогать семьи на чужих пасеках
                if (!allowedApiaryIds.Contains(colony.ApiaryId))
                    return Forbid();
            }

            colony.ApiaryId = apiaryId;
            await _service.Update(colony);

            return RedirectToAction(nameof(ManageApiaries));
        }

    }
}