using ApiaryManagementSystem.Context;
using ApiaryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiaryManagementSystem.Services.ApiaryServices
{
    public class ApiaryService : IApiaryService
    {
        private readonly ApplicationDbContext _context;
        public ApiaryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(Apiary apiary)
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
                var apiary = await _context.Apiaries.FindAsync(Id);
                if (apiary == null)
                {
                    throw new InvalidOperationException($"ID {Id} не найдено :(");
                }

                _context.Apiaries.Remove(apiary);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Произошла ошибка при удалении :(", ex);
            }
        }

        public async Task<Apiary> Get(int Id)
        {
            try
            {
                var apiary = await _context.Apiaries.FindAsync(Id);
                if (apiary == null)
                {
                    throw new InvalidOperationException($"ID {Id} не найдено :(");
                }
                return apiary;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Произошла ошибка при получении :(", ex);
            }
        }

        public async Task<List<Apiary>> GetAll()
        {
            try
            {
                return await _context.Apiaries.Include(a => a.Owner).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Произошла ошибка при получении всех :(", ex);
            }
        }

        public async Task<Apiary> Update(Apiary apiary)
        {
            try
            {
                var existingApiary = await _context.Apiaries.FindAsync(apiary.Id);
                if (existingApiary == null)
                {
                    throw new InvalidOperationException($"ID {apiary.Id} не найдено :(");
                }

                _context.Entry(existingApiary).CurrentValues.SetValues(apiary);
                await _context.SaveChangesAsync();

                return existingApiary;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Произошла ошибка при обновлении :(", ex);
            }
        }

    }
}
