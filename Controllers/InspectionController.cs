using Microsoft.AspNetCore.Mvc;
using ApiaryManagementSystem.ViewModels;
using ApiaryManagementSystem.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using ApiaryManagementSystem.Models;
using ApiaryManagementSystem.Services.InspectionService;

namespace ApiaryManagementSystem.Controllers
{
    public class InspectionController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IInspectionService _inspectionService;

        public InspectionController(ApplicationDbContext context, IInspectionService inspectionService)
        {
            _context = context;
            _inspectionService = inspectionService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create(int id)
        {
            var viewModel = new InspectionCreateViewModel(id);

            var currentQueen = _context.Queens
                .FirstOrDefault(q => q.BeeColonyId == id && (q.EndDate == null || q.EndDate > DateOnly.FromDateTime(DateTime.Now)));

            viewModel.Queens = _context.Queens
                .Where(q => q.EndDate == null || q.EndDate > DateOnly.FromDateTime(DateTime.Now))
                .Select(q => new SelectListItem
                {
                    Value = q.Id.ToString(),
                    Text = q.BeeColonyId.HasValue
                        ? $"{q.Breed} {q.Line} {q.StartDate} - семья №{q.BeeColonyId}"
                        : $"{q.Breed} {q.Line} {q.StartDate} - свободна"
                })
                .ToList();

            if (currentQueen != null)
                viewModel.QueenId = currentQueen.Id;

            viewModel.Inspection = await _inspectionService.GetLast(id);
            var insp = await _inspectionService.GetAll();

            return View(viewModel);
        }
    }
}
