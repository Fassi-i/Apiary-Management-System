using ApiaryManagementSystem.Context;
using ApiaryManagementSystem.Models;

namespace ApiaryManagementSystem.Services.ApiaryServices
{
    public interface IBeeColonyService
    {
        public Task Create(BeeColony colony);
        public Task<BeeColony> GetById(int Id);
        public Task<List<BeeColony>> GetAll();
        public Task<BeeColony> Update(BeeColony colony);
        public Task Delete(int Id);
    }
}
