using ImporterLogicInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.In;
using Moq;
using System.Collections.Generic;
using System.Linq;
using WebApi.Controllers;

namespace WebApiTests
{
    [TestClass]
    public class ImporterControllerTest
    {
        [TestMethod]
        public void TestPostImporterOk()
        {
            ImportModel importModel = new ImportModel()
            {
                FilePath = "somePath",
                ImporterType = "json"
            };
            Mock<IImporterLogic> mock = new Mock<IImporterLogic>(MockBehavior.Strict);
            mock.Setup(m => m.ImportWithKnownInterface(It.IsAny<ImportModel>()));
            ImporterController controller = new ImporterController(mock.Object);

            var result = controller.Post(importModel);
            CreatedAtRouteResult createdAtRouteResult = result as CreatedAtRouteResult;

            mock.VerifyAll();
            Assert.AreEqual(201, createdAtRouteResult.StatusCode);
        }

        [TestMethod]
        public void TestGetImportersOk()
        {
            List<string> importersToReturn = new List<string>()
            {
                "Json", "Xml"
            };
            Mock<IImporterLogic> mock = new Mock<IImporterLogic>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll()).Returns(importersToReturn);
            ImporterController controller = new ImporterController(mock.Object);

            var result = controller.Get();
            OkObjectResult okResult = result as OkObjectResult;
            List<string> importers = okResult.Value as List<string>;

            mock.VerifyAll();
            Assert.AreEqual(importersToReturn.Count, importers.Count);
            Assert.AreEqual(importersToReturn.First(), importers.First());
            Assert.AreEqual(importersToReturn.Last(), importers.Last());
            Assert.AreEqual(200, okResult.StatusCode);
        }
    }
}
