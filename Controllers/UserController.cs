using ApiaryManagementSystem.Context;
using ApiaryManagementSystem.Models;
using ApiaryManagementSystem.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ApiaryManagementSystem.Controllers
{
    [Authorize]
    [Authorize(Policy = "AdminAndManager")]
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

        public async Task<IActionResult> Index()
        {
            var users = await _service.GetAll();
            return View(users);
        }

        private async Task LoadPositions()
        {
            var positions = await _context.Positions.ToListAsync();
            ViewBag.Positions = new SelectList(positions, "Id", "PositionName");
        }
    }
}