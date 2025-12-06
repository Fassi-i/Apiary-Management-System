using ApiaryManagementSystem.Context;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiaryManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET метод для отображения формы
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST метод для обработки формы
        [HttpPost]
        public async Task<IActionResult> Login(string login, string password)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Login == login && u.Password == password);

            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, $"{user.LastName} {user.FirstName} {user.MiddleName}"),
                    new Claim("PositionId", user.PositionId.ToString()),
                    new Claim("Login", user.Login)
                };

                var principal = new ClaimsPrincipal(new ClaimsIdentity(claims, "CustomAuth"));

                await HttpContext.SignInAsync(principal);

                return RedirectToAction("Index", "Apiary");
            }

            ModelState.AddModelError("", "Неверный логин или пароль");
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
