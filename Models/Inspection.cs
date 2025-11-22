using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiaryManagementSystem.Models
{
    public class Inspection
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int StrengthInFrames { get; set; }
        public int TotalFrames { get; set; }
        public int BroodFrames { get; set; }
        public float FoodAmountKg { get; set; }
        public string? Notes { get; set; }

        public int BeeColonyId { get; set; }

        public BeeColony? BeeColony { get; set; }
    }
}
