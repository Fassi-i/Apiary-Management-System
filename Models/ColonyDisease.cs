using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiaryManagementSystem.Models
{
    public class ColonyDisease
    {
        [Key]
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int BeeColonyId { get; set; }
        public int DiseaseId { get; set; }

        [NotMapped]
        public BeeColony? BeeColony { get; set; }
        [NotMapped]
        public Disease? Disease { get; set; }
    }
}
