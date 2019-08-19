using Microsoft.VisualStudio.TestTools.UnitTesting;
using PercorsoCircolare.PercorsoCircolare.SL.Api.Controllers;
using System.Web.Http.Results;
using PercorsoCircolare.PercorsoCircolare.SL.Api.Models;

namespace PercorsoCircolare.PercorsoCircolare.SL.Api.Tests
{
    [TestClass]
    public class ResourceUnitTest
    {
        [TestMethod]
        public void GetResourceById()
        {
            using (var controller = new ResourceController())
            {
                var result = controller.GetResource(15);
                var contentResult = (OkNegotiatedContentResult<ResourceVM>)result;
                Assert.IsNotNull(result);
                Assert.IsNotNull(contentResult);
                Assert.AreEqual(15, contentResult.Content.ResourceId);
            }
        }
    }
}
