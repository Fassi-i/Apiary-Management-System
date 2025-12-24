using System.Security.Claims;
using ApiaryManagementSystem.Context;
using ApiaryManagementSystem.Models;
using ApiaryManagementSystem.Services.QueenService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ApiaryManagementSystem.Controllers
{
    public class QueenController : Controller
    {
        private readonly IQueenService _service;
        private readonly ApplicationDbContext _context;

        public QueenController(IQueenService service, ApplicationDbContext context)
        {
            _service = service;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            int ownerId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));

            bool isAdmin = User.IsInRole("Администратор");
            bool isSenior = User.IsInRole("Старший пчеловод") || isAdmin;

            IQueryable<Queen> queensQuery = _context.Queens
                .Include(q => q.BeeColony)
                    .ThenInclude(c => c.Apiary);

            IQueryable<BeeColony> coloniesQuery = _context.BeeColonies
                .Include(c => c.Apiary);

            // обычный пчеловод — только свои
            if (!isSenior)
            {
                queensQuery = queensQuery
                    .Where(q => q.BeeColony == null || q.BeeColony.Apiary.OwnerId == ownerId);

                coloniesQuery = coloniesQuery
                    .Where(c => c.Apiary.OwnerId == ownerId);
            }

            var queens = await queensQuery.ToListAsync();
            var beeColonies = await coloniesQuery
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = $"{c.Apiary.Name} — семья {c.Number}"
                })
                .ToListAsync();

            ViewBag.BeeColonies = beeColonies;

            return View(queens);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeColony(int id, int? beeColonyId)
        {
            var queen = await _context.Queens.FirstOrDefaultAsync(q => q.Id == id);
            if (queen == null)
                return NotFound();

            queen.BeeColonyId = beeColonyId;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        // Редактирование матки по Id матки (обычное)
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            int ownerId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var queen = await _service.GetByIdAsync(id);
            if (queen == null)
                return View("NotFound");

            var colonies = await _context.BeeColonies
                .Include(c => c.Apiary)
                .Where(c => c.Apiary.OwnerId == ownerId)
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = $"{c.Apiary.Name} — семья {c.Number}"
                })
                .ToListAsync();

            ViewBag.BeeColonies = colonies;

            return View(queen);
        }

        // POST по Id матки
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Queen queen)
        {
            if (id != queen.Id)
                return NotFound();

            if (!ModelState.IsValid)
            {
                int ownerId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
                ViewBag.BeeColonies = await _context.BeeColonies
                    .Include(c => c.Apiary)
                    .Where(c => c.Apiary.OwnerId == ownerId)
                    .Select(c => new SelectListItem
                    {
                        Value = c.Id.ToString(),
                        Text = $"{c.Apiary.Name} — семья {c.Number}"
                    })
                    .ToListAsync();

                return View(queen);
            }

            await _service.Update(queen);
            return RedirectToAction(nameof(Index));
        }

        // Редактирование матки по Id пчелосемьи
        [HttpGet]
        public async Task<IActionResult> EditByColony(int id)
        {
            var queen = await _service.GetByBeeColonyIdAsync(id);
            if (queen == null)
                return View("NotFound");

            return RedirectToAction(nameof(Edit), new { id = queen.Id });
        }


        // GET: Queen/Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            int ownerId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var colonies = await _context.BeeColonies
                .Include(c => c.Apiary)
                .Where(c => c.Apiary.OwnerId == ownerId)
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = $"{c.Apiary.Name} — семья {c.Number}"
                })
                .ToListAsync();

            ViewBag.BeeColonies = colonies;

            // новая матка по умолчанию без привязки к семье
            var model = new Queen
            {
                StartDate = DateOnly.FromDateTime(DateTime.Today)
            };

            return View(model);
        }

        // POST: Queen/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Queen queen)
        {
            if (!ModelState.IsValid)
            {
                int ownerId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));

                ViewBag.BeeColonies = await _context.BeeColonies
                    .Include(c => c.Apiary)
                    .Where(c => c.Apiary.OwnerId == ownerId)
                    .Select(c => new SelectListItem
                    {
                        Value = c.Id.ToString(),
                        Text = $"{c.Apiary.Name} — семья {c.Number}"
                    })
                    .ToListAsync();

                return View(queen);
            }

            await _service.Create(queen);

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _context.Queens.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
                return NotFound();

            _context.Queens.Remove(user);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
