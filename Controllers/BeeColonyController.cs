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
    }
}