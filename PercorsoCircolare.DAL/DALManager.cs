using System.Data.Entity;
using PercorsoCircolare.DAL.Entities;
using PercorsoCircolare.DAL.Interfaces;

namespace PercorsoCircolare.DAL
{
    public class DALManager : DbContext
    {
        private IRepository<Resource> resourceRepo;
        private IRepository<Building> buildingRepo;
        private IRepository<Room> roomRepo;
        private IRepository<Booking> bookingRepo;

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>().HasRequired(c => c.Resource)
                .WithMany()
                .WillCascadeOnDelete();
            modelBuilder.Entity<Room>().HasRequired(c => c.Building)
                .WithMany()
                .WillCascadeOnDelete();
        }

        public DALManager() : base("name=PercorsoCircolareConnectionString")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<DALManager>());
        }

        public virtual DbSet<Resource> ResourceCollection { get; set; }
        public virtual DbSet<Building> BuildingCollection { get; set; }
        public virtual DbSet<Room> RoomCollection { get; set; }
        public virtual DbSet<Booking> BookingCollection { get; set; }

        public IRepository<Resource> Resources => resourceRepo ?? (resourceRepo = new ResourceRepo());
        public IRepository<Building> Buildings => buildingRepo ?? (buildingRepo = new BuildingRepo());
        public IRepository<Room> Rooms => roomRepo ?? (roomRepo = new RoomRepo());
        public IRepository<Booking> Bookings => bookingRepo ?? (bookingRepo = new BookingRepo());
    }
}