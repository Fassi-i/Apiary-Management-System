using ApiaryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiaryManagementSystem.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Apiary> Apiaries { get; set; }
        //public DbSet<ApiaryStatus> ApiaryStatuses { get; set; }                   //УБРАТЬ
        public DbSet<BeeColony> BeeColonies { get; set; }
        public DbSet<ColonyDisease> ColonyDiseases { get; set; }
        //public DbSet<ColonyNote> ColonyNotes { get; set; }                        //УБРАТЬ
        public DbSet<ColonyPollination> ColonyPollinations { get; set; }
        public DbSet<ColonyProduct> ColonyProducts { get; set; }
        public DbSet<ColonySwarming> ColonySwarmings { get; set; }
        public DbSet<ColonyWintering> ColonyWinterings { get; set; }
        public DbSet<Crop> Crops { get; set; }
        public DbSet<Disease> Diseases { get; set; }                              
        public DbSet<Inspection> Inspections { get; set; }
        public DbSet<PollinationLocation> PollinationLocations { get; set; }
        public DbSet<Position> Positions { get; set; }                              
        //public DbSet<Product> Products { get; set; }                              //УБРАТЬ
        public DbSet<Queen> Queens { get; set; }
        public DbSet<Therapy> Therapies { get; set; }       
        //public DbSet<TherapyType> TherapyTypes { get; set; }                      //УБРАТЬ
        public DbSet<Unit> Units { get; set; }
        public DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}
