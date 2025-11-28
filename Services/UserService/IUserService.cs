using ApiaryManagementSystem.Models;

namespace ApiaryManagementSystem.Services.UserService
{
    public interface IUserService
    {
        Task<(bool IsSuccess, string Message)> Create(User user);
        Task<List<User>> GetAll();
    }
}
