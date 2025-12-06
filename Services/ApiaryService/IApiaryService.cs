using ApiaryManagementSystem.Context;
using ApiaryManagementSystem.Models;

namespace ApiaryManagementSystem.Services.ApiaryServices
{
    public interface IApiaryService
    {
        public Task Create(Apiary apiary);
        public Task<Apiary> GetById(int Id);
        public Task<List<Apiary>> GetAll();
        public Task<(bool IsSuccess, string Message)> Update(Apiary apiary);
        public Task Delete(int Id);
    }
}
