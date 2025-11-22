using ApiaryManagementSystem.Models;

namespace ApiaryManagementSystem.Services.UserService
{
    public interface IUserService
    {
        Task<(bool IsSuccess, string Message)> CreateUserAsync(User user);
        Task<List<User>> GetAllUsersAsync();
    }
}
