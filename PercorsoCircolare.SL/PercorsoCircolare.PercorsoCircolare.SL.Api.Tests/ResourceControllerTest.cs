using Microsoft.VisualStudio.TestTools.UnitTesting;
using PercorsoCircolare.PercorsoCircolare.SL.Api.Controllers;

namespace PercorsoCircolare.PercorsoCircolare.SL.Api.Tests
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
