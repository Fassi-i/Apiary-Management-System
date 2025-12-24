using System;
using ApiaryManagementSystem.Context;
using ApiaryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiaryManagementSystem.Services.QueenService
{
    public class QueenService : IQueenService
    {
        private readonly ApplicationDbContext _context;

        public QueenService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(bool IsSuccess, string Message)> Create(Queen queen)
        {
            try
            {
                _context.Queens.Add(queen);
                await _context.SaveChangesAsync();
                return (true, "Матка успешно добавлена");
            }
            catch (Exception ex)
            {
                return (false, $"Ошибка при добавлении: {ex.Message}");
            }

        }
        public async Task<(bool IsSuccess, string Message)> Update(Queen queen)
        {
            try
            {
                _context.Queens.Update(queen);
                await _context.SaveChangesAsync();
                return (true, "Матка успешно обновлена");
            }
            catch (Exception ex)
            {
                return (false, $"Ошибка при обновлении: {ex.Message}");
            }
        }

        public async Task<Queen> GetByIdAsync(int id)
        {
            return await _context.Queens.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Queen> GetByBeeColonyIdAsync(int id)
        {
            return await _context.Queens.Include(q => q.BeeColony).FirstOrDefaultAsync(x => x.BeeColonyId == id);
        }
    }
}
