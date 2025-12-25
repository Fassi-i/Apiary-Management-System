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
        public async Task<IActionResult> Index(int? apiaryId)
        {
            int ownerId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));

            bool isAdmin = User.IsInRole("Администратор");
            bool isSenior = User.IsInRole("Старший пчеловод") || isAdmin;

            // Базовый запрос маток
            IQueryable<Queen> queensQuery = _context.Queens
                .Include(q => q.BeeColony)
                    .ThenInclude(c => c.Apiary);

            // Базовый запрос семей для выпадашки "Изменить семью"
            IQueryable<BeeColony> coloniesQuery = _context.BeeColonies
                .Include(c => c.Apiary);

            // Обычный пчеловод — только свои
            if (!isSenior)
            {
                queensQuery = queensQuery
                    .Where(q => q.BeeColony == null || q.BeeColony.Apiary.OwnerId == ownerId);

                coloniesQuery = coloniesQuery
                    .Where(c => c.Apiary.OwnerId == ownerId);
            }

            // ФИЛЬТР по пасеке:
            // apiaryId == -1  -> "Не прикреплена"
            // apiaryId == N   -> матки, у которых BeeColony.ApiaryId == N
            if (apiaryId.HasValue)
            {
                if (apiaryId.Value == -1)
                {
                    queensQuery = queensQuery
                        .Where(q => q.BeeColony == null);
                }
                else
                {
                    queensQuery = queensQuery
                        .Where(q => q.BeeColony != null &&
                                    q.BeeColony.ApiaryId == apiaryId.Value);
                }
            }

            // Список маток после фильтра
            var queens = await queensQuery.ToListAsync();

            // Список семей для колонки "Изменить семью" (как было)
            var beeColonies = await coloniesQuery
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = $"{c.Apiary.Name} — семья {c.Number}"
                })
                .ToListAsync();

            ViewBag.BeeColonies = beeColonies;

            // Список пасек для фильтра + "Не прикреплена"
            var apiaryFilterItems = await _context.Apiaries
                .OrderBy(a => a.Name)
                .Select(a => new SelectListItem
                {
                    Value = a.Id.ToString(),
                    Text = a.Name
                })
                .ToListAsync();

            // "Не прикреплена" = -1
            apiaryFilterItems.Insert(0, new SelectListItem
            {
                Value = "-1",
                Text = "Не прикреплена"
            });

            // "Все пасеки" = пусто
            apiaryFilterItems.Insert(0, new SelectListItem
            {
                Value = "",
                Text = "Все пасеки"
            });

            ViewBag.ApiaryFilter = apiaryFilterItems;
            ViewData["CurrentApiaryFilter"] = apiaryId?.ToString();

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
