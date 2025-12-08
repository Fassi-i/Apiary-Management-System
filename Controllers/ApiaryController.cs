using System.Security.Claims;
using ApiaryManagementSystem.Context;
using ApiaryManagementSystem.Models;
using ApiaryManagementSystem.Services.ApiaryServices;
using ApiaryManagementSystem.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ApiaryManagementSystem.Controllers
{
    [Authorize]
    public class ApiaryController : Controller
    {
        private readonly IApiaryService _service;
        private readonly IBeeColonyService _beeColonyService;
        private readonly ApplicationDbContext _context;

        public ApiaryController(IApiaryService service, IBeeColonyService beeColonyService,  ApplicationDbContext context)
        {
            _service = service;
            _beeColonyService = beeColonyService;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            
            var userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var apiaries = await _context.Apiaries
                .Include(a => a.Owner)
                .Where(a => a.OwnerId == userId)
                .ToListAsync();

            var beeColoniesCount = _context.BeeColonies
                .GroupBy(b => b.ApiaryId)
                .ToDictionary(
                    group => group.Key,
                    group =>
                    {
                        return group.Count();
                    }
                );
            ViewBag.ColoniesCount = beeColoniesCount;

            if (apiaries == null) return View(new List<Apiary>());
            return View(apiaries);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await LoadUsers();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Apiary apiary)
        {
            apiary.ApiaryStatusId = 1;
            if (ModelState.IsValid)
            {
                apiary.Id = 0;

                try
                {
                    await _service.Create(apiary);
                    return RedirectToAction("Index", "Apiary");
                }
                catch
                {
                    ViewBag.Message = "Ошибка при добавлении пасеки";
                    await LoadUsers();
                    return View();
                }
            }

            await LoadUsers();
            return RedirectToAction("Create", "Apiary");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            await LoadUsers();
            var user = await _service.GetById(id);
            return user == null ? View("NotFound") : View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Apiary user)
        {
            if (id != user.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                return View(user);
            }

            await _service.Update(user);
            return RedirectToAction("Index", "Apiary");
        }


        private async Task LoadUsers()
        {
            var users = await _context.Users
                .Include(u => u.Position) 
                .Select(u => new SelectListItem
                {
                    Value = u.Id.ToString(),
                    Text = $"{u.LastName} {u.FirstName} {u.MiddleName} - {u.Position.PositionName}"
                })
                .ToListAsync();

            ViewBag.Users = users;
        }
    }
}