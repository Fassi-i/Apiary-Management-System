//using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations;

namespace ApiaryManagementSystem.Models
{
    public class ApiaryUser
    {
        [Key]
        public int ApiaryId { get; set; }
        [Key]
        public int UserId { get; set; }

        public Apiary? Apiary { get; set; }
        public User? User { get; set; }
    }
}
