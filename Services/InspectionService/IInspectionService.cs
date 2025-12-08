using ApiaryManagementSystem.Models;

namespace ApiaryManagementSystem.Services.InspectionService
{
    public interface IInspectionService
    {
        public Task<List<Inspection>> GetAll();
    }
}
