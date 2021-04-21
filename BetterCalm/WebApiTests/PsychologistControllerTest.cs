using System;
using AdapterExceptions;
using AdapterInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    }
}
