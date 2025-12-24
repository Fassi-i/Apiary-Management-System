using ApiaryManagementSystem.Context;
using ApiaryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiaryManagementSystem.Services.InspectionService
{
    public class InspectionService : IInspectionService
    {
        private readonly ApplicationDbContext _context;

        public InspectionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(Inspection inspection)
        {
            try
            {
                await _context.AddAsync(inspection);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Произошла ошибка при создании :(", ex);
            }
        }

        public async Task<Inspection> GetLast(int id)
        {
            var lastInspectionDate = _context.Inspections.Max(i => i.DateTime);
            var inspections = _context.Inspections.Where(i => i.DateTime == lastInspectionDate && i.BeeColonyId == id);
            if (inspections.Count() < 1)
            {
                return null;
            }
            else
            {
                return await inspections.FirstAsync();
            }
        }

        public async Task<List<Inspection>> GetAll()
        {
            return await _context.Inspections.ToListAsync();
        }
    }
}
