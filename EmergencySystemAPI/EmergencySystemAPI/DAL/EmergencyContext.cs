using EmergencySystemAPI.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace EmergencySystemAPI.DAL
{
    public class EmergencyContext : DbContext
    {
        public EmergencyContext() : base("EmergencyContext")
        {
            
        }

        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Ambulance> Ambulances { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ambulance>().HasKey(t => new { t.HospitalId, t.Id });
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}