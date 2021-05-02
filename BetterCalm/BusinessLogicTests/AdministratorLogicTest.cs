using System;
using System.Linq.Expressions;
using BusinessExceptions;
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

        [TestMethod]
        [ExpectedException(typeof(NullObjectException))]
        public void TestGetAdministratorNotExistentId()
        {
            var administratorId = 1;
            Mock<IRepository<Administrator>> mock = new Mock<IRepository<Administrator>>(MockBehavior.Strict);
            mock.Setup(m => m.GetById(administratorId)).Returns((Administrator)null);
            AdministratorLogic administratorLogic = new AdministratorLogic(mock.Object);

            Administrator result = administratorLogic.GetById(administratorId);

            mock.VerifyAll();
        }

        [TestMethod]
        public void TestCreateAdministratorOk()
        {
            Administrator administrator = new Administrator
            {
                Name = "Juan",
                Email = "Juan@gmail.com",
                Password = "Password01",
            };
            Mock<IRepository<Administrator>> mock = new Mock<IRepository<Administrator>>(MockBehavior.Strict);
            mock.Setup(m => m.Add(It.IsAny<Administrator>())).Returns(administrator);
            AdministratorLogic administratorLogic = new AdministratorLogic(mock.Object);

            Administrator response = administratorLogic.Add(administrator);

            mock.VerifyAll();
        }

        [TestMethod]
        public void TestDeleteAdministratorOk()
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
            mock.Setup(m => m.Delete(administratorToReturn));
            AdministratorLogic administratorLogic = new AdministratorLogic(mock.Object);

            administratorLogic.DeleteById(administratorId);

            mock.VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(NullObjectException))]
        public void TestDeleteAdministratorNotExistentId()
        {
            var administratorId = 1;
            Mock<IRepository<Administrator>> mock = new Mock<IRepository<Administrator>>(MockBehavior.Strict);
            mock.Setup(m => m.GetById(administratorId)).Returns((Administrator)null);
            mock.Setup(m => m.Delete(It.IsAny<Administrator>()));
            AdministratorLogic administratorLogic = new AdministratorLogic(mock.Object);

            administratorLogic.DeleteById(administratorId);

            mock.VerifyAll();
        }

        [TestMethod]
        public void TestUpdateAdministratorOk()
        {
            var administratorId = 1;
            Administrator administratorModel = new Administrator
            {
                Id = administratorId,
                Name = "Juan",
                Email = "Juan@gmail.com",
                Password = "Password01",
            };
            Mock<IRepository<Administrator>> mock = new Mock<IRepository<Administrator>>(MockBehavior.Strict);
            mock.Setup(m => m.Exists(a => a.Id == administratorModel.Id)).Returns(true);
            mock.Setup(m => m.Update(administratorModel));
            AdministratorLogic administratorLogic = new AdministratorLogic(mock.Object);

            administratorLogic.Update(administratorModel);

            mock.VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(NullObjectException))]
        public void TestUpdateAdministratorNotExistent()
        {
            var administratorId = 1;
            Administrator administratorModel = new Administrator
            {
                Id = administratorId,
                Name = "Juan",
                Email = "Juan@gmail.com",
                Password = "Password01",
            };
            Mock<IRepository<Administrator>> mock = new Mock<IRepository<Administrator>>(MockBehavior.Strict);
            mock.Setup(m => m.Exists(a => a.Id == administratorModel.Id)).Returns(false);
            mock.Setup(m => m.Update(administratorModel));
            AdministratorLogic administratorLogic = new AdministratorLogic(mock.Object);

            administratorLogic.Update(administratorModel);

            mock.VerifyAll();
        }

        [TestMethod]
        public void TestGetAdministratorByEmailAndPasswordOk()
        {
            string email = "Juan@gmail.com";
            string password = "Password01";
            Administrator administratorToReturn = new Administrator
            {
                Name = "Juan",
                Email = email,
                Password = password,
            };
            Mock<IRepository<Administrator>> mock = new Mock<IRepository<Administrator>>(MockBehavior.Strict);
            mock.Setup(m => m.Get(It.IsAny<Expression<Func<Administrator, bool>>>())).Returns(administratorToReturn);
            AdministratorLogic administratorLogic = new AdministratorLogic(mock.Object);

            Administrator result = administratorLogic.GetByEmailAndPassword(email, password);

            mock.VerifyAll();
            Assert.AreEqual(administratorToReturn.Id, result.Id);
            Assert.AreEqual(administratorToReturn.Name, result.Name);
            Assert.AreEqual(administratorToReturn.Email, result.Email);
            Assert.AreEqual(administratorToReturn.Password, result.Password);
        }

        [TestMethod]
        [ExpectedException(typeof(NullObjectException))]
        public void TestGetAdministratorByNotExistantEmail()
        {
            string email = "Juan@gmail.com";
            string password = "Password01";
            Mock<IRepository<Administrator>> mock = new Mock<IRepository<Administrator>>(MockBehavior.Strict);
            mock.Setup(m => m.Get(It.IsAny<Expression<Func<Administrator, bool>>>())).Returns((Administrator)null);
            AdministratorLogic administratorLogic = new AdministratorLogic(mock.Object);

            Administrator result = administratorLogic.GetByEmailAndPassword(email, password);

            mock.VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(NullObjectException))]
        public void TestGetAdministratorByIncorrectPassword()
        {
            string email = "Juan@gmail.com";
            string password = "Password01";
            Mock<IRepository<Administrator>> mock = new Mock<IRepository<Administrator>>(MockBehavior.Strict);
            mock.Setup(m => m.Get(It.IsAny<Expression<Func<Administrator, bool>>>())).Returns((Administrator)null);
            AdministratorLogic administratorLogic = new AdministratorLogic(mock.Object);

            Administrator result = administratorLogic.GetByEmailAndPassword(email, password);

            mock.VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(NullObjectException))]
        public void TestCreateAdministratorWithAlreadyExistantEmail()
        {
            Administrator administrator = new Administrator
            {
                Name = "Juan",
                Email = "Juan@gmail.com",
                Password = "Password01",
            };
            Mock<IRepository<Administrator>> mock = new Mock<IRepository<Administrator>>(MockBehavior.Strict);
            mock.Setup(m => m.Add(It.IsAny<Administrator>())).Returns(administrator);
            AdministratorLogic administratorLogic = new AdministratorLogic(mock.Object);

            Administrator response = administratorLogic.Add(administrator);

            mock.VerifyAll();
        }
    }
}
