﻿using System;
using AdapterExceptions;
using AdapterInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.In;
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

        [TestMethod]
        public void TestGetAdministratorNotExistent()
        {
            var administratorId = 1;
            Mock<IAdministratorLogicAdapter> mock = new Mock<IAdministratorLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.GetById(administratorId)).Throws(new NullObjectMappingException("The Administrator doesn't exists"));
            AdministratorController controller = new AdministratorController(mock.Object);

            var result = controller.GetById(administratorId);
            var okResult = result as ObjectResult;

            mock.VerifyAll();
            Assert.AreEqual(404, okResult.StatusCode);
        }

        [TestMethod]
        public void TestPostAdministratorOk()
        {
            var administratorId = 1;
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
            var statusCodeResult = result as StatusCodeResult;

            mock.VerifyAll();
            Assert.AreEqual(204, statusCodeResult.StatusCode);
        }

        [TestMethod]
        public void TestPostAdministratorInvalidName()
        {
            AdministratorModel administratorModel = new AdministratorModel
            {
                Name = "",
                Email = "Juan@gmail.com",
                Password = "Password01",
            };
            Mock<IAdministratorLogicAdapter> mock = new Mock<IAdministratorLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.Add(It.IsAny<AdministratorModel>())).Throws(new ArgumentException("Invalid name"));
            AdministratorController controller = new AdministratorController(mock.Object);

            var result = controller.Post(administratorModel);
            var badResult = result as BadRequestObjectResult;

            mock.VerifyAll();
            Assert.AreEqual(400, badResult.StatusCode);
        }

        [TestMethod]
        public void TestDeleteAdministratorOk()
        {
            int administratorId = 1;
            Mock<IAdministratorLogicAdapter> mock = new Mock<IAdministratorLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.Delete(administratorId));
            AdministratorController controller = new AdministratorController(mock.Object);

            var response = controller.DeleteById(administratorId);
            var statusCodeResult = response as StatusCodeResult;

            mock.VerifyAll();
            Assert.AreEqual(204, statusCodeResult.StatusCode);
        }

        [TestMethod]
        public void TestUpdateAdministratorOk()
        {
            AdministratorModel administratorModel = new AdministratorModel
            {
                Id = 1,
                Name = "Juan",
                Email = "Juan@gmail.com",
                Password = "Password01",
            };
            Mock<IAdministratorLogicAdapter> mock = new Mock<IAdministratorLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.Update(It.IsAny<AdministratorModel>()));
            AdministratorController controller = new AdministratorController(mock.Object);

            var response = controller.Update(administratorModel);
            var statusCodeResult = response as StatusCodeResult;

            mock.VerifyAll();
            Assert.AreEqual(204, statusCodeResult.StatusCode);
        }
    }
}
