using System.Security.Claims;
using ApiaryManagementSystem.Context;
using ApiaryManagementSystem.Models;
using ApiaryManagementSystem.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ApiaryManagementSystem.Controllers
{

    [Authorize(Policy = "Admin")]
    public class UserController : Controller
    {
        private readonly IUserService _service;
        private readonly ApplicationDbContext _context;

        public UserController(IUserService service, ApplicationDbContext context)
        {
            _service = service;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await LoadPositions();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            if (user.BirthDate == default(DateOnly))
            {
                ModelState.AddModelError("BirthDate", "Введите корректную дату в формате дд.мм.гггг");
            }
            if (ModelState.IsValid)
            {
                user.Id = 0;

                try
                {
                    await _service.Create(user);
                    return RedirectToAction("Create", "User");
                }
                catch
                {
                    ViewBag.Message = "Ошибка при добавлении пользователя";
                    await LoadPositions();
                    return View();
                }
            }

            await LoadPositions();
            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> AdminIndex(string? search, int? positionId)
        {
            ViewData["CurrentFilter"] = search;
            ViewData["CurrentPosition"] = positionId;

            var query = _context.Users
                .Include(u => u.Position)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                var term = search.Trim().ToLower();
                query = query.Where(u =>
                    (u.FirstName + " " + u.LastName).ToLower().Contains(term) ||
                    (u.LastName + " " + u.FirstName).ToLower().Contains(term));
            }

            if (positionId.HasValue && positionId.Value > 0)
            {
                query = query.Where(u => u.PositionId == positionId.Value);
            }

            var users = await query.ToListAsync();

            // список должностей для фильтра
            ViewBag.Positions = await _context.Positions
                .OrderBy(p => p.PositionName)
                .Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.PositionName
                })
                .ToListAsync();

            return View(users);
        }

        private async Task LoadPositions()
        {
            var positions = await _context.Positions.ToListAsync();
            ViewBag.Positions = new SelectList(positions, "Id", "PositionName");
        }

        // GET: User/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // запрещаем редактировать себя
            if (currentUserId != null && currentUserId == id.ToString())
                return Forbid();

            var user = await _context.Users
                .Include(u => u.Position)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
                return NotFound();

            // если в форме нужен список должностей
            ViewBag.Positions = await _context.Positions
                .Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.PositionName
                })
                .ToListAsync();

            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(User model)
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (currentUserId != null && currentUserId == model.Id.ToString())
                return Forbid();

            if (!ModelState.IsValid)
            {
                ViewBag.Positions = await _context.Positions
                    .Select(p => new SelectListItem
                    {
                        Value = p.Id.ToString(),
                        Text = p.PositionName
                    })
                    .ToListAsync();

                return View(model);
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == model.Id);
            if (user == null)
                return NotFound();

            user.LastName = model.LastName;
            user.FirstName = model.FirstName;
            user.MiddleName = model.MiddleName;
            user.Login = model.Login;
            user.Password = model.Password;
            user.BirthDate = model.BirthDate;
            user.Location = model.Location;
            user.PositionId = model.PositionId;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(AdminIndex));
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // запрещаем удалять себя
            if (currentUserId != null && currentUserId == id.ToString())
                return Forbid();

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
                return NotFound();

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(AdminIndex));
        }

    }
}