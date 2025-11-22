using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiaryManagementSystem.Models
{
    public class ColonySwarming
    {
        [Key]
        public int Id { get; set; }
        public DateTime SwarmingDate { get; set; }

        public int BeeColonyId { get; set; }

        public BeeColony? BeeColony { get; set; }
    }
}
