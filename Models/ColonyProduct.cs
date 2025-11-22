using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiaryManagementSystem.Models
{
    public class ColonyProduct
    {
        [Key]
        public int Id { get; set; }
        public DateTime HarvestDate { get; set; }
        public int Amount { get; set; }

        public int BeeColonyId { get; set; }
        public int ProductId { get; set; }
        public int UnitId { get; set; }

        public BeeColony? BeeColony { get; set; }
        public Product? Product { get; set; }
        public Unit? Unit { get; set; }
    }
}
