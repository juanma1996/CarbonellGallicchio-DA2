using ImporterLogicInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApi.Controllers;

namespace WebApiTests
{
    [TestClass]
    public class ImporterControllerTest
    {
        [TestMethod]
        public void TestPostImporterOk()
        {
            string filePath = @"C:\Users\juan.gallicchio\Desktop\ejemplo.json";
            Mock<IImporterLogic> mock = new Mock<IImporterLogic>(MockBehavior.Strict);
            mock.Setup(m => m.InstantiateObjectWithKnownInterface(It.IsAny<string>()));
            ImporterController controller = new ImporterController(mock.Object);

            var result = controller.Post(filePath);
            CreatedAtRouteResult createdAtRouteResult = result as CreatedAtRouteResult;

            mock.VerifyAll();
            Assert.AreEqual(201, createdAtRouteResult.StatusCode);
        }
    }
}
