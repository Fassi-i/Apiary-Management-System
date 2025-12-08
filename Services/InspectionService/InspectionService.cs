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

        public async Task<List<Inspection>> GetAll()
        {
            return await _context.Inspections.ToListAsync();
        }
    }
}
