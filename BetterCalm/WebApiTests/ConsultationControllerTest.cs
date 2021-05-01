using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Out;
using Model.In;
using Moq;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;
using AdapterInterface;

namespace WebApiTests
{
    [TestClass]
    public class ConsultationControllerTest
    {
        [TestMethod]
        public void TestPostConsultationOk()
        {
            var problematicId = 1;
            ConsultationModel consultationModel = new ConsultationModel
            {
                ProblematicId = problematicId,
                Pacient = new PacientModel
                {
                    Name = "Juan",
                    Surname = "Perez",
                    BirthDate = new DateTime(1996, 12, 05),
                    Email = "Juan@gmail.com",
                    Cellphone = "098342972"
                }
            };
            PsychologistBasicInfoModel psychologistToReturn = new PsychologistBasicInfoModel
            {
                Name = "Jorge",
                ConsultationMode = "Presencial",
                Direction = "Rio Negro 8156"
            };
            Mock<IConsultationLogicAdapter> mock = new Mock<IConsultationLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.Add(It.IsAny<ConsultationModel>())).Returns(psychologistToReturn);
            ConsultationController controller = new ConsultationController(mock.Object);

            var result = controller.Post(consultationModel);
            var okResult = result as CreatedAtRouteResult;
            var psychologistBasicInfoModel = okResult.Value as PsychologistBasicInfoModel;

            mock.VerifyAll();
            Assert.AreEqual(psychologistToReturn.Name, psychologistBasicInfoModel.Name);
            Assert.AreEqual(psychologistToReturn.ConsultationMode, psychologistBasicInfoModel.ConsultationMode);
            Assert.AreEqual(psychologistToReturn.Direction, psychologistBasicInfoModel.Direction);
        }
    }
}
