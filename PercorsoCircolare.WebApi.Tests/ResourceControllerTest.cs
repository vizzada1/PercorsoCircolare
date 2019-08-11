using Microsoft.VisualStudio.TestTools.UnitTesting;
using PercorsoCircolare.WebApi.Controllers;

namespace PercorsoCircolare.WebApi.Tests
{
    [TestClass]
    public class ResourceControllerTest
    {
        [TestMethod]
        public void IsControllerDefined()
        {
            var controller = new ResourceController();
            Assert.IsNotNull(controller);
        }
    }
}
