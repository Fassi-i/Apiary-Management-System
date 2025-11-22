using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiaryManagementSystem.Models
{
    public class Queen
    {
        [Key]
        public int Id { get; set; }
        public int BirthYear { get; set; }
        public string? Breed { get; set; }
        public string? Line { get; set; }

        public int BeeColonyId { get; set; }

        public BeeColony? BeeColony { get; set; }
    }
}
