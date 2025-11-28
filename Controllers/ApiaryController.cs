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
        private readonly ApplicationDbContext _context;

        public ApiaryController(IApiaryService service, ApplicationDbContext context)
        {
            _service = service;
            _context = context;
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
                    return RedirectToAction("Create", "Apiary");
                }
                catch
                {
                    ViewBag.Message = "Ошибка при добавлении пасеки";
                    await LoadUsers();
                    return View();
                }
            }

            await LoadUsers();
            return View(apiary);
        }

        public async Task<IActionResult> Index()
        {
            var users = await _service.GetAll();
            return View(users);
        }

        private async Task LoadUsers()
        {
            var users = await _context.Users
                .Select(u => new
                {
                    u.Id,
                    FullName = $"{u.LastName} {u.FirstName} {u.MiddleName}"
                })
                .ToListAsync();

            ViewBag.Users = new SelectList(users, "Id", "FullName");
        }
    }
}