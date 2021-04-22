using System;
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
    public class PsychologistControllerTest
    {
        [TestMethod]
        public void TestGetPsychologistByIdOk()
        {
            var psychologistId = 1;
            PsychologistBasicInfoModel psychologistToReturn = new PsychologistBasicInfoModel
            {
                Id = 1,
                Name = "Juan",
                Direction = "Rio negro",
                ConsultationMode = "Presencial",
                CreationDate = new DateTime(2021, 4, 20),
            };
            Mock<IPsychologistLogicAdapter> mock = new Mock<IPsychologistLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.GetById(psychologistId)).Returns(psychologistToReturn);
            PsychologistController controller = new PsychologistController(mock.Object);

            var result = controller.GetById(psychologistId);
            var okResult = result as OkObjectResult;
            var psychologist = okResult.Value as PsychologistBasicInfoModel;

            mock.VerifyAll();
            Assert.AreEqual(psychologistToReturn.Id, psychologist.Id);
            Assert.AreEqual(psychologistToReturn.Name, psychologist.Name);
            Assert.AreEqual(psychologistToReturn.Direction, psychologist.Direction);
            Assert.AreEqual(psychologistToReturn.ConsultationMode, psychologist.ConsultationMode);
            Assert.AreEqual(psychologistToReturn.CreationDate, psychologist.CreationDate);
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [TestMethod]
        public void TestGetPsychologistNotExistentId()
        {
            var psychologistId = 1;
            Mock<IPsychologistLogicAdapter> mock = new Mock<IPsychologistLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.GetById(psychologistId)).Throws(new NullObjectMappingException("prueba"));
            PsychologistController controller = new PsychologistController(mock.Object);

            var result = controller.GetById(psychologistId);
            var okResult = result as ObjectResult;

            mock.VerifyAll();
            Assert.AreEqual(404, okResult.StatusCode);
        }

        [TestMethod]
        public void TestPostPsychologistOk()
        {
            int psychologistId = 1;
            PsychologistModel psycologistModel = new PsychologistModel
            {
                Name = "Juan",
                Direction = "Rio negro",
                ConsultationMode = "Presencial",
                CreationDate = new DateTime(2021, 4, 20),
            };
            PsychologistBasicInfoModel psychologistToReturn = new PsychologistBasicInfoModel
            {
                Id = 1,
                Name = "Juan",
                Direction = "Rio negro",
                ConsultationMode = "Presencial",
                CreationDate = new DateTime(2021, 4, 20),
            };

            Mock<IPsychologistLogicAdapter> mock = new Mock<IPsychologistLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.Add(It.IsAny<PsychologistModel>())).Returns(psychologistToReturn);
            PsychologistController controller = new PsychologistController(mock.Object);

            var result = controller.Post(psycologistModel);
            var okResult = result as CreatedAtRouteResult;
            var psychologistBasicInfoModel = okResult.Value as PsychologistBasicInfoModel;

            mock.VerifyAll();
            Assert.AreEqual(psychologistId, psychologistBasicInfoModel.Id);

        }

        [TestMethod]
        public void TestDeletePsychologistOk()
        {
            int psychologistId = 1;
            Mock<IPsychologistLogicAdapter> mock = new Mock<IPsychologistLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.Delete(psychologistId));
            PsychologistController controller = new PsychologistController(mock.Object);

            var response = controller.DeleteById(psychologistId);
            var statusCodeResult = response as StatusCodeResult;

            mock.VerifyAll();
            Assert.AreEqual(204, statusCodeResult.StatusCode);
        }

        [TestMethod]
        public void TestDeletePsychologistNotFound()
        {
            int psychologistId = 1;
            Mock<IPsychologistLogicAdapter> mock = new Mock<IPsychologistLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.Delete(psychologistId)).Throws(new ArgumentException());
            PsychologistController controller = new PsychologistController(mock.Object);

            var response = controller.DeleteById(psychologistId);
            var statusCodeResult = response as StatusCodeResult;

            mock.VerifyAll();
            Assert.AreEqual(404, statusCodeResult.StatusCode);
        }

        [TestMethod]
        public void TestUpdatePsychologistOk()
        {
            var psychologistId = 1;
            PsychologistModel psycologistModel = new PsychologistModel
            {
                Name = "Juan",
                Direction = "Rio negro",
                ConsultationMode = "Presencial",
                CreationDate = new DateTime(2021, 4, 20),
            };
            Mock<IPsychologistLogicAdapter> mock = new Mock<IPsychologistLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.Update(It.IsAny<int>(), It.IsAny<PsychologistModel>()));
            PsychologistController controller = new PsychologistController(mock.Object);

            var response = controller.Update(psychologistId, psycologistModel);
            var statusCodeResult = response as StatusCodeResult;

            mock.VerifyAll();
            Assert.AreEqual(204, statusCodeResult.StatusCode);
        }
    }
}
