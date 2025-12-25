using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiaryManagementSystem.Models
{
    public class Therapy
    {
        [Key]
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int InspectionId { get; set; }
        public int ColonyDiseaseId { get; set; }

        public string? TherapyType { get; set; }

        public Inspection? Inspection { get; set; }
        public ColonyDisease? ColonyDisease { get; set; }
    }
}
