using System;
using System.Collections.Generic;
using System.Linq;
using Adapter;
using AdapterInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Out;
using Moq;
using WebApi.Controllers;

namespace WebApiTests
{
    [TestClass]
    public class ProblematicControllerTest
    {
        [TestMethod]
        public void TestGetProblematicsOk()
        {
            List<ProblematicBasicInfoModel> problematicsToReturn = new List<ProblematicBasicInfoModel>()
            {
                new ProblematicBasicInfoModel
                {
                    Name = "Estrés"
                },
                new ProblematicBasicInfoModel
                {
                    Name = "Ansiedad"
                },
            };
            Mock<IProblematicLogicAdapter> mock = new Mock<IProblematicLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll()).Returns(problematicsToReturn);
            ProblematicController controller = new ProblematicController(mock.Object);

            var result = controller.Get();
            var okResult = result as OkObjectResult;
            var problematics = okResult.Value as List<ProblematicBasicInfoModel>;

            mock.VerifyAll();
            Assert.AreEqual(problematics.First().Id, problematicsToReturn.First().Id);
            Assert.AreEqual(problematics.First().Name, problematicsToReturn.First().Name);
            Assert.AreEqual(200, okResult.StatusCode);
        }
    }
}
