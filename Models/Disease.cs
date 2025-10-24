using System.ComponentModel.DataAnnotations;

namespace ApiaryManagementSystem.Models
{
    public class Disease
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}   
