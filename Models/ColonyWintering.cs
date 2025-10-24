using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiaryManagementSystem.Models
{
    public class ColonyWintering
    {
        [Key]
        public int Id { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public string? Conditions { get; set; }

        public int BeeColonyId { get; set; }

        [NotMapped]
        public BeeColony? BeeColony { get; set; }
    }
}
