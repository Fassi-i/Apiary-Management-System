using System;
using ApiaryManagementSystem.Context;
using ApiaryManagementSystem.Services.UserService;
using Microsoft.EntityFrameworkCore;

namespace ApiaryManagementSystem.Services.UserRoleService
{
    public class UserRoleService : IUserRoleService
    {
        private readonly ApplicationDbContext _context;

        public UserRoleService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<string>> GetUserRolesAsync(int userId)
        {
            var user = await _context.Users
                .Include(u => u.Position) 
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null || user.Position == null)
                return new List<string>();

            return new List<string> { user.Position.PositionName };
        }
    }
}
