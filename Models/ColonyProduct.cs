using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiaryManagementSystem.Models
{
    public class ColonyProduct
    {
        [Key]
        public int Id { get; set; }
        public DateTime HarvestDate { get; set; }
        public float Amount { get; set; }

        public int BeeColonyId { get; set; }
        public Products Product { get; set; }
        //public ProductUnits? Unit { get; set; }                 

        public BeeColony? BeeColony { get; set; }              
    }

    //public enum ProductUnits
    //{
    //    кг, 
    //    г, 
    //    мг,
    //}

    public enum Products
    {
        Мёд, 
        Воск, 
        Пыльца, 
        Перга, 
        Прополис, 
        Маточное_молочко, 
        Пчелиный_яд, 
        Трутнёвый_гемогенат
    }
}
