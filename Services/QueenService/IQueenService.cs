using ApiaryManagementSystem.Models;

namespace ApiaryManagementSystem.Services.QueenService
{
    public interface IQueenService
    {
        Task<(bool IsSuccess, string Message)> Update(Queen queen);
        Task<Queen> GetByIdAsync(int id);
        Task<Queen> GetByBeeColonyIdAsync(int id);
        Task<(bool IsSuccess, string Message)> Create(Queen queen);
    }
}
