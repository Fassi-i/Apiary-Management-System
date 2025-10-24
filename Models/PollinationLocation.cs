using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiaryManagementSystem.Models
{
    public class PollinationLocation
    {
        [Key]
        public int Id { get; set; }
        public string? Address { get; set; }
        public float AreaHectares { get; set; }

        public int CropId { get; set; }

        [NotMapped]
        public Crop? Crop { get; set; }
    }
}
