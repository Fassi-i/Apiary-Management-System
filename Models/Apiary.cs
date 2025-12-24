using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiaryManagementSystem.Models
{
    public class Apiary
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsMobile { get; set; }
        public string? Address { get; set; }

        public int ApiaryStatus { get; set; }
        public int OwnerId { get; set; }

        public User? Owner { get; set; }
    }
}
