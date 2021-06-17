using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessExceptions;
using BusinessLogic;
using DataAccessInterface;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ValidatorInterface;

namespace BusinessLogicTests
{
    [TestClass]
    public class AdministratorLogicTest
    {
        [TestMethod]
        public void TestGetAdministratorByIdOk()
        {
            int administratorId = 1;
            Administrator administratorToReturn = new Administrator
            {
                Id = administratorId,
                Name = "Juan",
                Email = "Juan@gmail.com",
                Password = "Password01",
            };
            Mock<IRepository<Administrator>> mock = new Mock<IRepository<Administrator>>(MockBehavior.Strict);
            mock.Setup(m => m.GetById(administratorId)).Returns(administratorToReturn);
            Mock<IValidator<Administrator>> validatorMock = new Mock<IValidator<Administrator>>(MockBehavior.Strict);
            validatorMock.Setup(m => m.Validate(It.IsAny<Administrator>()));
            AdministratorLogic administratorLogic = new AdministratorLogic(mock.Object, validatorMock.Object);

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
            int administratorId = 1;
            Mock<IRepository<Administrator>> mock = new Mock<IRepository<Administrator>>(MockBehavior.Strict);
            mock.Setup(m => m.GetById(administratorId)).Returns((Administrator)null);
            Mock<IValidator<Administrator>> validatorMock = new Mock<IValidator<Administrator>>(MockBehavior.Strict);
            validatorMock.Setup(m => m.Validate(It.IsAny<Administrator>())).Throws(new NullObjectException("Not exist Administrator"));
            AdministratorLogic administratorLogic = new AdministratorLogic(mock.Object, validatorMock.Object);

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
            mock.Setup(m => m.Exists(It.IsAny<Expression<Func<Administrator, bool>>>())).Returns(false);
            Mock<IValidator<Administrator>> validatorMock = new Mock<IValidator<Administrator>>(MockBehavior.Strict);
            validatorMock.Setup(m => m.Validate(It.IsAny<Administrator>()));
            AdministratorLogic administratorLogic = new AdministratorLogic(mock.Object, validatorMock.Object);

            Administrator response = administratorLogic.Add(administrator);

            mock.VerifyAll();
        }

        [TestMethod]
        public void TestDeleteAdministratorOk()
        {
            int administratorId = 1;
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
            Mock<IValidator<Administrator>> validatorMock = new Mock<IValidator<Administrator>>(MockBehavior.Strict);
            validatorMock.Setup(m => m.Validate(It.IsAny<Administrator>()));
            AdministratorLogic administratorLogic = new AdministratorLogic(mock.Object, validatorMock.Object);

            administratorLogic.DeleteById(administratorId);

            mock.VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(NullObjectException))]
        public void TestDeleteAdministratorNotExistentId()
        {
            int administratorId = 1;
            Mock<IRepository<Administrator>> mock = new Mock<IRepository<Administrator>>(MockBehavior.Strict);
            mock.Setup(m => m.GetById(administratorId)).Returns((Administrator)null);
            mock.Setup(m => m.Delete(It.IsAny<Administrator>()));
            Mock<IValidator<Administrator>> validatorMock = new Mock<IValidator<Administrator>>(MockBehavior.Strict);
            validatorMock.Setup(m => m.Validate(It.IsAny<Administrator>())).Throws(new NullObjectException("Not exist Administrator"));
            AdministratorLogic administratorLogic = new AdministratorLogic(mock.Object, validatorMock.Object);

            administratorLogic.DeleteById(administratorId);

            mock.VerifyAll();
        }

        [TestMethod]
        public void TestUpdateAdministratorOk()
        {
            int administratorId = 1;
            Administrator administratorModel = new Administrator
            {
                Id = administratorId,
                Name = "Juan",
                Email = "Juan@gmail.com",
                Password = "Password01",
            };
            Mock<IRepository<Administrator>> mock = new Mock<IRepository<Administrator>>(MockBehavior.Strict);
            mock.Setup(m => m.Exists(a => a.Id == administratorId)).Returns(true);
            mock.Setup(m => m.Update(administratorModel));
            Mock<IValidator<Administrator>> validatorMock = new Mock<IValidator<Administrator>>(MockBehavior.Strict);
            validatorMock.Setup(m => m.Validate(It.IsAny<Administrator>()));
            AdministratorLogic administratorLogic = new AdministratorLogic(mock.Object, validatorMock.Object);

            administratorLogic.Update(administratorId, administratorModel);

            mock.VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(NullObjectException))]
        public void TestUpdateAdministratorNotExistent()
        {
            int administratorId = 1;
            Administrator administratorModel = new Administrator
            {
                Id = administratorId,
                Name = "Juan",
                Email = "Juan@gmail.com",
                Password = "Password01",
            };
            Mock<IRepository<Administrator>> mock = new Mock<IRepository<Administrator>>(MockBehavior.Strict);
            mock.Setup(m => m.Exists(a => a.Id == administratorId)).Returns(false);
            mock.Setup(m => m.Update(administratorModel));
            Mock<IValidator<Administrator>> validatorMock = new Mock<IValidator<Administrator>>(MockBehavior.Strict);
            validatorMock.Setup(m => m.Validate(It.IsAny<Administrator>())).Throws(new NullObjectException("Not exist Administrator"));
            AdministratorLogic administratorLogic = new AdministratorLogic(mock.Object, validatorMock.Object);

            administratorLogic.Update(administratorId, administratorModel);

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
            Mock<IValidator<Administrator>> validatorMock = new Mock<IValidator<Administrator>>(MockBehavior.Strict);
            validatorMock.Setup(m => m.Validate(It.IsAny<Administrator>()));
            AdministratorLogic administratorLogic = new AdministratorLogic(mock.Object, validatorMock.Object);

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
            Mock<IValidator<Administrator>> validatorMock = new Mock<IValidator<Administrator>>(MockBehavior.Strict);
            validatorMock.Setup(m => m.Validate(It.IsAny<Administrator>())).Throws(new NullObjectException("Not exist Administrator"));
            AdministratorLogic administratorLogic = new AdministratorLogic(mock.Object, validatorMock.Object);

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
            Mock<IValidator<Administrator>> validatorMock = new Mock<IValidator<Administrator>>(MockBehavior.Strict);
            validatorMock.Setup(m => m.Validate(It.IsAny<Administrator>())).Throws(new NullObjectException("Not exist Administrator"));
            AdministratorLogic administratorLogic = new AdministratorLogic(mock.Object, validatorMock.Object);

            Administrator result = administratorLogic.GetByEmailAndPassword(email, password);

            mock.VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(AlreadyExistException))]
        public void TestCreateAdministratorWithAlreadyExistantEmail()
        {
            Administrator administrator = new Administrator
            {
                Name = "Juan",
                Email = "Juan@gmail.com",
                Password = "Password01",
            };
            Mock<IRepository<Administrator>> mock = new Mock<IRepository<Administrator>>(MockBehavior.Strict);
            mock.Setup(m => m.Exists(It.IsAny<Expression<Func<Administrator, bool>>>())).Returns(true);
            Mock<IValidator<Administrator>> validatorMock = new Mock<IValidator<Administrator>>(MockBehavior.Strict);
            AdministratorLogic administratorLogic = new AdministratorLogic(mock.Object, validatorMock.Object);

            Administrator response = administratorLogic.Add(administrator);

            mock.VerifyAll();
        }

        [TestMethod]
        public void TestGetAdministratorsOk()
        {
            Administrator firstAdministratorToReturn = new Administrator
            {
                Name = "Juan",
                Email = "Juan@gmail.com",
                Password = "Password01",
            };
            Administrator secondAdministratorToReturn = new Administrator
            {
                Name = "Fede",
                Email = "fede@gmail.com",
                Password = "Password01",
            };
            List<Administrator> administratorsToReturn = new List<Administrator>() { firstAdministratorToReturn, secondAdministratorToReturn };
            Mock<IRepository<Administrator>> mock = new Mock<IRepository<Administrator>>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll(It.IsAny<Expression<Func<Administrator, bool>>>())).Returns(administratorsToReturn);
            Mock<IValidator<Administrator>> validatorMock = new Mock<IValidator<Administrator>>(MockBehavior.Strict);
            validatorMock.Setup(m => m.Validate(It.IsAny<Administrator>()));
            AdministratorLogic administratorLogic = new AdministratorLogic(mock.Object, validatorMock.Object);

            List<Administrator> result = administratorLogic.GetAll();

            mock.VerifyAll();
            Assert.AreEqual(administratorsToReturn.Count, result.Count);
        }
    }
}
