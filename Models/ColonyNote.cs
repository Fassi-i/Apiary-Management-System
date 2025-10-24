using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiaryManagementSystem.Models
{
    public class ColonyNote
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public DateTime Date { get; set; }
        public string? Text { get; set; }

        public int BeeColonyId { get; set; }

        [NotMapped]
        public BeeColony? BeeColony { get; set; }
    }
}
