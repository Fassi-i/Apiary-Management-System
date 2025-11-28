using ApiaryManagementSystem.Context;
using ApiaryManagementSystem.Models;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace ApiaryManagementSystem.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(bool IsSuccess, string Message)> Create(User user)
        //public async Task<(bool IsSuccess, string Message)> CreateUserAsync(User user)
        {
            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return (true, "Пользователь успешно добавлен");
            }
            catch (Exception ex)
            {
                return (false, $"Ошибка при сохранении: {ex.Message}");
            }
            
        }

        public async Task<List<User>> GetAll()
        //public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.Include(u => u.Position).ToListAsync();
        }
    }
}
