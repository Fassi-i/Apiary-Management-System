using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiaryManagementSystem.Models
{
    public class BeeColony
    {
        [Key]
        public int Id { get; set; }
        public string? Number { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? DisbandmentDate { get; set; }

        public int ApiaryId { get; set; }

        public Apiary? Apiary { get; set; }
    }   
}
