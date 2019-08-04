using System.Data.Entity;
using PercorsoCircolare.DAL.Entities;
using PercorsoCircolare.DAL.Interfaces;

namespace PercorsoCircolare.DAL
{
    public class DALManager : DbContext, IDALManager
    {
        private IBuildingRepo buildingRepo;
        private IResourceRepo resourceRepo;
        private IRoomRepo roomRepo;
        private IBookingRepo bookingRepo;

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

        public IResourceRepo Resources => resourceRepo ?? (resourceRepo = new ResourceRepo());
        public IBuildingRepo Buildings => buildingRepo ?? (buildingRepo = new BuildingRepo());
        public IRoomRepo Rooms => roomRepo ?? (roomRepo = new RoomRepo());
        public IBookingRepo Bookings => bookingRepo ?? (bookingRepo = new BookingRepo());
    }
}