using Microsoft.AspNetCore.Mvc;
using ApiaryManagementSystem.ViewModels;
using ApiaryManagementSystem.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using ApiaryManagementSystem.Models;
using ApiaryManagementSystem.Services.InspectionService;
using System.Security.Claims;
using ApiaryManagementSystem.Services.ApiaryServices;

namespace ApiaryManagementSystem.Controllers
{
    public class InspectionController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IInspectionService _inspectionService;
        private readonly IBeeColonyService _beeColonyService;

        public InspectionController(ApplicationDbContext context, IInspectionService inspectionService, IBeeColonyService beeColonyService)
        {
            _context = context;
            _inspectionService = inspectionService;
            _beeColonyService = beeColonyService;
        }

        public async Task<IActionResult> Details(int id)
        {
            var inspections = await _inspectionService.GetAll();
            var apiary = await _beeColonyService.GetById(id);

            inspections = inspections.Where(i => i.BeeColonyId == id).OrderByDescending(i => i.DateTime).ToList();

            ViewBag.ApiaryNumber = apiary.Number;
            ViewBag.ApiaryId = apiary.Id;
            return View(inspections);
        }

        public async Task<IActionResult> Create(int id)
        {
            var now = DateOnly.FromDateTime(DateTime.Now);

            var beeColony = await _context.BeeColonies
                .FirstOrDefaultAsync(c => c.Id == id);

            if (beeColony == null)
                return NotFound();

            var currentQueen = await _context.Queens
                .FirstOrDefaultAsync(q => q.BeeColonyId == id && (q.EndDate == null || q.EndDate > now));

            var queens = await _context.Queens
                .Where(q => q.EndDate == null || q.EndDate > now)
                .Select(q => new SelectListItem
                {
                    Value = q.Id.ToString(),
                    Text = q.BeeColonyId.HasValue
                        ? $"{q.Breed} {q.Line} {q.StartDate} - семья №{q.BeeColonyId}"
                        : $"{q.Breed} {q.Line} {q.StartDate} - свободна"
                })
                .ToListAsync();

            var ownerId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var apearies = await _context.Apiaries
                .Where(a => a.OwnerId == ownerId)
                .Select(a => new SelectListItem
                {
                    Value = a.Id.ToString(),
                    Text = a.Name + " " + a.Address
                })
                .ToListAsync();

            var lastInspection = await _inspectionService.GetLast(id) ?? new Inspection();
            lastInspection.DateTime = DateTime.Now;
            lastInspection.Notes = string.Empty;

            var diseases = await _context.Diseases.ToListAsync();

            var vm = new InspectionCreateViewModel(id)
            {
                Queens = queens,
                QueenId = currentQueen?.Id,
                Inspection = lastInspection,
                Apearies = apearies,
                ApiatyId = beeColony.ApiaryId,
                BeeColony = beeColony,
                Diseases = diseases,
                DiseaseTherapies = new List<InspectionDiseaseTherapyItem>
                {
                    new InspectionDiseaseTherapyItem()
                }
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InspectionCreateViewModel model)
        {
            if (model.BeeColony == null || model.BeeColony.Id == 0)
                return BadRequest("Не передан идентификатор семьи");

            var colonyId = model.BeeColony.Id;

            // 1. Сохраняем осмотр
            model.Inspection.BeeColonyId = colonyId;
            _context.Inspections.Add(model.Inspection);
            await _context.SaveChangesAsync();
            var inspectionId = model.Inspection.Id;

            // 2. Болезни и лечения
            if (model.DiseaseTherapies != null)
            {
                foreach (var item in model.DiseaseTherapies)
                {
                    if (!item.DiseaseId.HasValue)
                        continue;

                    // создаём конкретный случай болезни
                    var cd = new ColonyDisease
                    {
                        InspectionId = inspectionId,
                        DiseaseId = item.DiseaseId.Value,
                        StartDate = model.Inspection.DateTime.Date,
                        EndDate = null
                    };
                    _context.ColonyDiseases.Add(cd);
                    await _context.SaveChangesAsync(); // нужно, чтобы получить cd.Id

                    // если введено лечение — создаём Therapy и привязываем к этому ColonyDisease
                    if (!string.IsNullOrWhiteSpace(item.TherapyType) ||
                        item.TherapyStartDate.HasValue ||
                        item.TherapyEndDate.HasValue)
                    {
                        var therapy = new Therapy
                        {
                            InspectionId = inspectionId,
                            ColonyDiseaseId = cd.Id,
                            TherapyType = item.TherapyType,
                            StartDate = item.TherapyStartDate ?? model.Inspection.DateTime.Date,
                            EndDate = item.TherapyEndDate ?? model.Inspection.DateTime.Date
                        };
                        _context.Therapies.Add(therapy);
                    }
                }
            }

            // Смена матки
            if (model.QueenId.HasValue)
            {
                var queen = await _context.Queens
                    .FirstOrDefaultAsync(q => q.Id == model.QueenId.Value);

                if (queen != null)
                    queen.BeeColonyId = colonyId;
            }

            // Смена пасеки
            if (model.ApiatyId.HasValue)
            {
                var colony = await _context.BeeColonies
                    .FirstOrDefaultAsync(c => c.Id == colonyId);

                if (colony != null)
                    colony.ApiaryId = model.ApiatyId.Value;
            }

            await _context.SaveChangesAsync();

            return RedirectToAction("Details", "BeeColony", new { id = colonyId });
        }


    }
}
