using AdapterExceptions;
using AdapterInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.In;
using Model.Out;
using Moq;
using System.Collections.Generic;
using WebApi.Controllers;

namespace WebApiTests
{
    [TestClass]
    public class AdministratorControllerTest
    {
        [TestMethod]
        public void TestGetAdministratorByIdOk()
        {
            int administratorId = 1;
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

            var result = controller.Get(administratorId);
            OkObjectResult okResult = result as OkObjectResult;
            AdministratorBasicInfoModel administrator = okResult.Value as AdministratorBasicInfoModel;

            mock.VerifyAll();
            Assert.AreEqual(administratorToReturn.Id, administrator.Id);
            Assert.AreEqual(administratorToReturn.Name, administrator.Name);
            Assert.AreEqual(administratorToReturn.Email, administrator.Email);
            Assert.AreEqual(administratorToReturn.Password, administrator.Password);
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void TestGetAdministratorNotExistent()
        {
            int administratorId = 1;
            Mock<IAdministratorLogicAdapter> mock = new Mock<IAdministratorLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.GetById(administratorId)).Throws(new NotFoundException("The Administrator doesn't exists"));
            AdministratorController controller = new AdministratorController(mock.Object);

            var result = controller.Get(administratorId);
        }

        [TestMethod]
        public void TestPostAdministratorOk()
        {
            int administratorId = 1;
            AdministratorModel administratorModel = new AdministratorModel
            {
                Name = "Juan",
                Email = "Juan@gmail.com",
                Password = "Password01",
            };
            AdministratorBasicInfoModel administratorToReturn = new AdministratorBasicInfoModel
            {
                Id = administratorId,
                Name = "Juan",
                Email = "Juan@gmail.com",
                Password = "Password01",
            };
            Mock<IAdministratorLogicAdapter> mock = new Mock<IAdministratorLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.Add(It.IsAny<AdministratorModel>()));
            AdministratorController controller = new AdministratorController(mock.Object);

            var result = controller.Post(administratorModel);
            StatusCodeResult statusCodeResult = result as StatusCodeResult;

            mock.VerifyAll();
            Assert.AreEqual(204, statusCodeResult.StatusCode);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestPostAdministratorInvalidName()
        {
            AdministratorModel administratorModel = new AdministratorModel
            {
                Name = "",
                Email = "Juan@gmail.com",
                Password = "Password01",
            };
            Mock<IAdministratorLogicAdapter> mock = new Mock<IAdministratorLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.Add(It.IsAny<AdministratorModel>())).Throws(new InvalidAttributeException("Invalid name"));
            AdministratorController controller = new AdministratorController(mock.Object);

            var result = controller.Post(administratorModel);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestPostAdministratorInvalidEmail()
        {
            AdministratorModel administratorModel = new AdministratorModel
            {
                Name = "Juan",
                Email = "",
                Password = "Password01",
            };
            Mock<IAdministratorLogicAdapter> mock = new Mock<IAdministratorLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.Add(It.IsAny<AdministratorModel>())).Throws(new InvalidAttributeException("Invalid Email"));
            AdministratorController controller = new AdministratorController(mock.Object);

            var result = controller.Post(administratorModel);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestPostAdministratorInvalidPassword()
        {
            AdministratorModel administratorModel = new AdministratorModel
            {
                Name = "Juan",
                Email = "Juan@gmail.com",
                Password = "",
            };
            Mock<IAdministratorLogicAdapter> mock = new Mock<IAdministratorLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.Add(It.IsAny<AdministratorModel>())).Throws(new InvalidAttributeException("Invalid password"));
            AdministratorController controller = new AdministratorController(mock.Object);

            var result = controller.Post(administratorModel);
        }

        [TestMethod]
        public void TestDeleteAdministratorOk()
        {
            int administratorId = 1;
            Mock<IAdministratorLogicAdapter> mock = new Mock<IAdministratorLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.Delete(administratorId));
            AdministratorController controller = new AdministratorController(mock.Object);

            var response = controller.Delete(administratorId);
            StatusCodeResult statusCodeResult = response as StatusCodeResult;

            mock.VerifyAll();
            Assert.AreEqual(204, statusCodeResult.StatusCode);
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void TestDeleteAdministratorNotFound()
        {
            int administratorId = 1;
            Mock<IAdministratorLogicAdapter> mock = new Mock<IAdministratorLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.Delete(administratorId)).Throws(new NotFoundException(""));
            AdministratorController controller = new AdministratorController(mock.Object);

            var response = controller.Delete(administratorId);
        }

        [TestMethod]
        public void TestUpdateAdministratorOk()
        {
            int adminId = 1;
            AdministratorModel administratorModel = new AdministratorModel
            {
                Id = 1,
                Name = "Juan",
                Email = "Juan@gmail.com",
                Password = "Password01",
            };
            Mock<IAdministratorLogicAdapter> mock = new Mock<IAdministratorLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.Update(adminId, It.IsAny<AdministratorModel>()));
            AdministratorController controller = new AdministratorController(mock.Object);

            var response = controller.Put(adminId, administratorModel);
            StatusCodeResult statusCodeResult = response as StatusCodeResult;

            mock.VerifyAll();
            Assert.AreEqual(204, statusCodeResult.StatusCode);
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void TestUpdateAdministratorNotFound()
        {
            int adminId = 1;
            AdministratorModel administratorModel = new AdministratorModel
            {
                Id = 1,
                Name = "Juan",
                Email = "Juan@gmail.com",
                Password = "Password01",
            };
            Mock<IAdministratorLogicAdapter> mock = new Mock<IAdministratorLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.Update(adminId, It.IsAny<AdministratorModel>())).Throws(new NotFoundException("The Administrator doesn't exists"));
            AdministratorController controller = new AdministratorController(mock.Object);

            var response = controller.Put(adminId, administratorModel);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestUpdateAdministratorInvalidName()
        {
            int adminId = 1;
            AdministratorModel administratorModel = new AdministratorModel
            {
                Name = "",
                Email = "Juan@gmail.com",
                Password = "Password01",
            };
            Mock<IAdministratorLogicAdapter> mock = new Mock<IAdministratorLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.Update(adminId, It.IsAny<AdministratorModel>())).Throws(new InvalidAttributeException("Invalid name"));
            AdministratorController controller = new AdministratorController(mock.Object);

            var result = controller.Put(adminId, administratorModel);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestUpdateAdministratorInvalidEmail()
        {
            int adminId = 1;
            AdministratorModel administratorModel = new AdministratorModel
            {
                Name = "Juan",
                Email = "",
                Password = "Password01",
            };
            Mock<IAdministratorLogicAdapter> mock = new Mock<IAdministratorLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.Update(adminId, It.IsAny<AdministratorModel>())).Throws(new InvalidAttributeException("Invalid Email"));
            AdministratorController controller = new AdministratorController(mock.Object);

            var result = controller.Put(adminId, administratorModel);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestUpdateAdministratorInvalidPassword()
        {
            int adminId = 1;
            AdministratorModel administratorModel = new AdministratorModel
            {
                Name = "Juan",
                Email = "Juan@gmail.com",
                Password = "",
            };
            Mock<IAdministratorLogicAdapter> mock = new Mock<IAdministratorLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.Update(adminId, It.IsAny<AdministratorModel>())).Throws(new InvalidAttributeException("Invalid password"));
            AdministratorController controller = new AdministratorController(mock.Object);

            var result = controller.Put(adminId, administratorModel);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestPostAdministratorEmailAlreadyExistant()
        {
            AdministratorModel administratorModel = new AdministratorModel
            {
                Name = "Juan",
                Email = "oneMail@gmail.com",
                Password = "Password01",
            };
            Mock<IAdministratorLogicAdapter> mock = new Mock<IAdministratorLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.Add(It.IsAny<AdministratorModel>())).Throws(new InvalidAttributeException("Email already exists"));
            AdministratorController controller = new AdministratorController(mock.Object);

            var result = controller.Post(administratorModel);
        }

        [TestMethod]
        public void TestGetAdministratorsOk()
        {
            AdministratorBasicInfoModel firstAdministratorToReturn = new AdministratorBasicInfoModel
            {
                Id = 1,
                Name = "Juan",
                Email = "Juan@gmail.com",
                Password = "Password01",
            };
            AdministratorBasicInfoModel secondAdministratorToReturn = new AdministratorBasicInfoModel
            {
                Id = 2,
                Name = "Fede",
                Email = "fede@gmail.com",
                Password = "Password01",
            };
            List<AdministratorBasicInfoModel> administratorsToReturn = new List<AdministratorBasicInfoModel>() { firstAdministratorToReturn, secondAdministratorToReturn };
            Mock<IAdministratorLogicAdapter> mock = new Mock<IAdministratorLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll()).Returns(administratorsToReturn);
            AdministratorController controller = new AdministratorController(mock.Object);

            var result = controller.Get();
            OkObjectResult okResult = result as OkObjectResult;
            List<AdministratorBasicInfoModel> administrators = okResult.Value as List<AdministratorBasicInfoModel>;

            mock.VerifyAll();
            Assert.AreEqual(administratorsToReturn.Count, administrators.Count);
        }
    }
}
