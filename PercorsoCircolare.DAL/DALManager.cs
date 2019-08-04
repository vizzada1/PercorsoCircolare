using System.Data.Entity;
using PercorsoCircolare.DAL.Entities;
using PercorsoCircolare.DAL.Interfaces;

namespace PercorsoCircolare.DAL
{
    public class DALManager : DbContext, IDALManager
    {
        private IResourceRepo resourceRepo;

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Lesson>().HasRequired(c => c.Module)
        //        .WithMany()
        //        .WillCascadeOnDelete(false);
        //    modelBuilder.Entity<Lesson>().HasRequired(c => c.Course)
        //        .WithMany()
        //        .WillCascadeOnDelete(false);
        //    modelBuilder.Entity<Lesson>().HasRequired(c => c.Teacher)
        //        .WithMany()
        //        .WillCascadeOnDelete(false);
        //    modelBuilder.Entity<Lesson>().HasRequired(c => c.BackupTeacher)
        //        .WithMany()
        //        .WillCascadeOnDelete(false);
        //}

        public DALManager() : base("name=PercorsoCircolareConnectionString")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<DALManager>());
        }

        public virtual DbSet<Resource> ResourceCollection { get; set; }

        public IResourceRepo Resources => resourceRepo ?? (resourceRepo = new ResourceRepo());
    }
}
