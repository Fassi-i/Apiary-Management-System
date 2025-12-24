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

        //Переделать
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

        //Переделать
        public async Task SoftDelete(int Id)
        {
            try
            {
                var apiary = await _context.Apiaries.FindAsync(Id);
                if (apiary == null)
                {
                    throw new InvalidOperationException($"ID {Id} не найдено :(");
                }
                apiary.ApiaryStatus = -1;
                _context.Apiaries.Update(apiary);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Произошла ошибка при удалении :(", ex);
            }
        }

        public async Task Repair(int Id)
        {
            try
            {
                var apiary = await _context.Apiaries.FindAsync(Id);
                if (apiary == null)
                {
                    throw new InvalidOperationException($"ID {Id} не найдено :(");
                }
                apiary.ApiaryStatus = 0;
                _context.Apiaries.Update(apiary);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Произошла ошибка при удалении :(", ex);
            }
        }

        public async Task<Apiary> GetById(int Id)
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

        //public async Task<List<Apiary>> GetByOwnerId(int Id)
        //{
        //    try
        //    {
        //        var apiary = await _context.Apiaries.Where(x => x.OwnerId == Id).ToListAsync();
        //        if (apiary == null)
        //        {
        //            throw new InvalidOperationException($"ID {Id} не найдено :(");
        //        }
        //        return apiary;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new InvalidOperationException("Произошла ошибка при получении :(", ex);
        //    }
        //}

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

        public async Task<(bool IsSuccess, string Message)> Update(Apiary apiary)
        {
            try
            {
                _context.Apiaries.Update(apiary);
                await _context.SaveChangesAsync();
                return (true, "Пасека успешно обновлена");
            }
            catch (Exception ex)
            {
                return (false, $"Ошибка при обновлении: {ex.Message}");
            }
        }

    }
}
