using ApiaryManagementSystem.Models;

namespace ApiaryManagementSystem.Services.InspectionService
{
    public interface IInspectionService
    {
        Task Create(Inspection inspection);
        Task<List<Inspection>> GetAll();
        Task<Inspection> GetLast(int id);
    }
}
