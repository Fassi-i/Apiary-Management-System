using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiaryManagementSystem.Models
{
    public class ColonyDisease
    {
        [Key]
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public int InspectionId { get; set; }
        public int DiseaseId { get; set; }

        public Inspection? Inspection { get; set; }
        public Disease? Disease { get; set; }
    }
}
