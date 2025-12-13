using ApiaryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ApiaryManagementSystem.ViewModels
{
    public class InspectionCreateViewModel
    {
        public Inspection? Inspection { get; set; }
        public BeeColony? BeeColony { get; set; }
        public Apiary? Apiary { get; set; }
        public int? QueenId { get; set; }
        public List<SelectListItem> Queens { get; set; }
        public List<Disease>? Diseases { get; set; }
        public List<Therapy>? Therapy { get; set; }
        public List<string>? Notes { get; set; }

        public InspectionCreateViewModel()
        {
            BeeColony = new BeeColony();
            BeeColony.Number = "123 (данная тестовая строка находится в ApiaryManagementSystem.ViewModels.InspectionCreateViewModel)";
        }

        public InspectionCreateViewModel(int id)
        {
            BeeColony = new BeeColony();
            BeeColony.Id = id;
            BeeColony.Number = "123 (данная тестовая строка находится в ApiaryManagementSystem.ViewModels.InspectionCreateViewModel)";
        }
    }
}
