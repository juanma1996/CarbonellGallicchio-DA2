using System;
using AdapterInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Out;
using Moq;
using WebApi.Controllers;

namespace WebApiTests
{
    [TestClass]
    public class AdministratorControllerTest
    {
        [TestMethod]
        public void TestGetAdministratorByIdOk()
        {
            var administratorId = 1;
            AdministratorBasicInfoModel administratorToReturn = new AdministratorBasicInfoModel
            {
                Id = administratorId,
                Name = "Juan",
                Email = "Juan@gmail.com",
                Password = "Password01",
            };
            Mock<IAdministratorLogicAdapter> mock = new Mock<IAdministratorLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.GetById(administratorId)).Returns(administratorToReturn);
            AdministratorController controller = new AdministratorController(mock.Object);

            var result = controller.GetById(administratorId);
            var okResult = result as OkObjectResult;
            var administrator = okResult.Value as AdministratorBasicInfoModel;

            mock.VerifyAll();
            Assert.AreEqual(administratorToReturn.Id, administrator.Id);
            Assert.AreEqual(administratorToReturn.Name, administrator.Name);
            Assert.AreEqual(administratorToReturn.Email, administrator.Email);
            Assert.AreEqual(administratorToReturn.Password, administrator.Password);
        }
    }
}
