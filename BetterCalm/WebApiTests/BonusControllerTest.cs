﻿using AdapterExceptions;
using AdapterInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.In;
using Model.Out;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Controllers;

namespace WebApiTests
{
    [TestClass]
    public class BonusControllerTest
    {
        [TestMethod]
        public void TestGetBonusesOk()
        {
            BonusBasicInfoModel firstBonusToReturn = new BonusBasicInfoModel()
            {
                PacientId = 1,
                PacientEmail = "juan@gmail.com",
                ConsultationsQuantity = 6
            };
            BonusBasicInfoModel secondBonusToReturn = new BonusBasicInfoModel()
            {
                PacientId = 2,
                PacientEmail = "fede@gmail.com",
                ConsultationsQuantity = 5
            };
            List<BonusBasicInfoModel> bonusesToReturn = new List<BonusBasicInfoModel>() { firstBonusToReturn, secondBonusToReturn };
            Mock<IBonusLogicAdapter> mock = new Mock<IBonusLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll()).Returns(bonusesToReturn);
            BonusController controller = new BonusController(mock.Object);

            var result = controller.Get();
            OkObjectResult okResult = result as OkObjectResult;
            List<BonusBasicInfoModel> bonuses = okResult.Value as List<BonusBasicInfoModel>;

            mock.VerifyAll();
            Assert.AreEqual(bonusesToReturn.Count, bonuses.Count);
        }

        [TestMethod]
        public void TestApproveBonusOk()
        {
            BonusModel bonusModel = new BonusModel()
            {
                PacientId = 1,
                Approved = true,
                Amount = 0.25
            };
            Mock<IBonusLogicAdapter> mock = new Mock<IBonusLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.Update(bonusModel));
            BonusController controller = new BonusController(mock.Object);

            var response = controller.Update(bonusModel);
            StatusCodeResult statusCodeResult = response as StatusCodeResult;

            mock.VerifyAll();
            Assert.AreEqual(204, statusCodeResult.StatusCode);
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void TestApproveBonusNotExistPacientId()
        {
            BonusModel bonusModel = new BonusModel()
            {
                PacientId = 1,
                Approved = true,
                Amount = 0.25
            };
            Mock<IBonusLogicAdapter> mock = new Mock<IBonusLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.Update(bonusModel)).Throws(new NotFoundException("Not found object")); ;
            BonusController controller = new BonusController(mock.Object);

            var response = controller.Update(bonusModel);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestApproveBonusInvalidAmount()
        {
            BonusModel bonusModel = new BonusModel()
            {
                PacientId = 1,
                Approved = true,
                Amount = 5
            };
            Mock<IBonusLogicAdapter> mock = new Mock<IBonusLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.Update(bonusModel)).Throws(new InvalidAttributeException("Amount value is invalid"));
            BonusController controller = new BonusController(mock.Object);

            var response = controller.Update(bonusModel);
        }

        [TestMethod]
        public void TestDenyBonusOk()
        {
            BonusModel bonusModel = new BonusModel()
            {
                PacientId = 1,
                Approved = false,
                Amount = 0
            };
            Mock<IBonusLogicAdapter> mock = new Mock<IBonusLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.Update(bonusModel));
            BonusController controller = new BonusController(mock.Object);

            var response = controller.Update(bonusModel);
            StatusCodeResult statusCodeResult = response as StatusCodeResult;

            mock.VerifyAll();
            Assert.AreEqual(204, statusCodeResult.StatusCode);
        }
    }
}