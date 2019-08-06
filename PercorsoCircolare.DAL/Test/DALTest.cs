using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PercorsoCircolare.DAL.Entities;

namespace PercorsoCircolare.DAL.Test
{
    [TestClass]
    public class DALTest
    {
        public IEnumerable<Resource> ResourceTest()
        {
            using (var dm = new DALManager())
            {
                var repo = dm.Resources;
                return repo.GetAll();
            }
        }

        public void AddResourceTest()
        {
            using (var dm = new DALManager())
            {
                var repo = dm.Resources;
                var resource = new Resource
                    { FirstName = "Test", LastName = "Reti", EmailAddress = "test.reti@reti.it", IsActive = true };
                repo.Add(resource);
                UnitOfWork.Commit();
            }
        }

        public void DeleteResourceTest()
        {
            using (var dm = new DALManager())
            {
                var repo = dm.Resources;
                var resource = repo.First(r => r.Username == "retite1");
                repo.Delete(resource);
                UnitOfWork.Commit();
            }
        }

        [TestMethod]
        public void TestAll()
        {
            AddResourceTest();
            Assert.IsTrue(ResourceTest().Any());
            DeleteResourceTest();
        }

        //[TestMethod]
        //public void AddBuildingTest()
        //{
        //    using (var dm = new DALManager())
        //    {
        //        dm.Buildings.Add(new Building
        //        {
        //            Name = "Campus",
        //            Address = "Via ciao",
        //            IsActive = true
        //        });
        //        UnitOfWork.Commit();
        //    }
        //}
    }
}
