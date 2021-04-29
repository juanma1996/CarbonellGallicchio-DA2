using System;
using BusinessLogic;
using DataAccessInterface;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BusinessLogicTests
{
    [TestClass]
    public class AdministratorLogicTest
    {
        [TestMethod]
        public void TestGetAdministratorByIdOk()
        {
            var administratorId = 1;
            Administrator administratorToReturn = new Administrator
            {
                Id = administratorId,
                Name = "Juan",
                Email = "Juan@gmail.com",
                Password = "Password01",
            };
            Mock<IRepository<Administrator>> mock = new Mock<IRepository<Administrator>>(MockBehavior.Strict);
            mock.Setup(m => m.GetById(administratorId)).Returns(administratorToReturn);
            AdministratorLogic administratorLogic = new AdministratorLogic(mock.Object);

            Administrator result = administratorLogic.GetById(administratorId);

            mock.VerifyAll();
            Assert.AreEqual(administratorToReturn.Id, result.Id);
            Assert.AreEqual(administratorToReturn.Name, result.Name);
            Assert.AreEqual(administratorToReturn.Email, result.Email);
            Assert.AreEqual(administratorToReturn.Password, result.Password);
        }
    }
}
