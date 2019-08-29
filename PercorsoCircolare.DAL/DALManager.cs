using System.Data.Entity;
using PercorsoCircolare.Entities;

namespace PercorsoCircolare.DAL
{
    public class DALManager : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        public DALManager() : base("name=PercorsoCircolareConnectionString")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<DALManager>());
        }

        public virtual DbSet<Resource> ResourceCollection { get; set; }
        public virtual DbSet<Building> BuildingCollection { get; set; }
        public virtual DbSet<Room> RoomCollection { get; set; }
        public virtual DbSet<Booking> BookingCollection { get; set; }

    }
}