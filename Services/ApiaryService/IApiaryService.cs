using ApiaryManagementSystem.Context;
using ApiaryManagementSystem.Models;

namespace ApiaryManagementSystem.Services.ApiaryServices
{
    public interface IApiaryService
    {
        public Task Create(Apiary apiary);
        public Task<Apiary> Get(int Id);
        public Task<List<Apiary>> GetAll();
        public Task<Apiary> Update(Apiary apiary);
        public Task Delete(int Id);
    }
}
