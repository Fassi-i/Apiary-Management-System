using ApiaryManagementSystem.Context;
using ApiaryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiaryManagementSystem.Services.ApiaryServices
{
    public class BeeColonyService : IBeeColonyService
    {
        private readonly ApplicationDbContext _context;

        public BeeColonyService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(BeeColony apiary)
        {
            try
            {
                await _context.AddAsync(apiary);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Произошла ошибка при создании :(", ex);
            }
        }

        public async Task Delete(int Id)
        {
            try
            {
                var apiary = await _context.BeeColonies.FindAsync(Id);
                if (apiary == null)
                {
                    throw new InvalidOperationException($"ID {Id} не найдено :(");
                }

                _context.BeeColonies.Remove(apiary);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Произошла ошибка при удалении :(", ex);
            }
        }

        public async Task<BeeColony> GetById(int Id)
        {
            try
            {
                var colony = await _context.BeeColonies.FindAsync(Id);
                if (colony == null)
                {
                    throw new InvalidOperationException($"ID {Id} не найдено :(");
                }
                return colony;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Произошла ошибка при получении :(", ex);
            }
        }

        public async Task<List<BeeColony>> GetAll()
        {
            try
            {
                return await _context.BeeColonies.Include(a => a.Apiary).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Произошла ошибка при получении всех :(", ex);
            }
        }

        public async Task<BeeColony> Update(BeeColony beeColony)
        {
            try
            {
                var existingBeeColony = await _context.BeeColonies.FindAsync(beeColony.Id);
                if (existingBeeColony == null)
                {
                    throw new InvalidOperationException($"ID {beeColony.Id} не найдено :(");
                }

                _context.Entry(existingBeeColony).CurrentValues.SetValues(beeColony);
                await _context.SaveChangesAsync();

                return existingBeeColony;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Произошла ошибка при обновлении :(", ex);
            }
        }

    }
}
