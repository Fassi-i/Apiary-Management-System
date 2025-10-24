using System.ComponentModel.DataAnnotations;

namespace ApiaryManagementSystem.Models
{
    public class TherapyType
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
