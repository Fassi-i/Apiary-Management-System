using System.ComponentModel.DataAnnotations;

namespace ApiaryManagementSystem.Models
{
    public class Crop
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public float ColoniesPerHectare { get; set; }
    }
}
