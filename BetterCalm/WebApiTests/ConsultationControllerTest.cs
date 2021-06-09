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
        public void TestPostConsultationPresenceModeOk()
        {
            int problematicId = 1;
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
            CreatedAtRouteResult okResult = result as CreatedAtRouteResult;
            PsychologistBasicInfoModel psychologistBasicInfoModel = okResult.Value as PsychologistBasicInfoModel;

            mock.VerifyAll();
            Assert.AreEqual(psychologistToReturn.Name, psychologistBasicInfoModel.Name);
            Assert.AreEqual(psychologistToReturn.ConsultationMode, psychologistBasicInfoModel.ConsultationMode);
            Assert.AreEqual(psychologistToReturn.Direction, psychologistBasicInfoModel.Direction);
        }

        [TestMethod]
        public void TestPostConsultationVirtualModeOk()
        {
            int problematicId = 1;
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
                ConsultationMode = "Virtual",
                Direction = "https://bettercalm.com.uy/meeting_id/a59e595a-27d1-423f-97e5-1ea7804af71f"
            };
            Mock<IConsultationLogicAdapter> mock = new Mock<IConsultationLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.Add(It.IsAny<ConsultationModel>())).Returns(psychologistToReturn);
            ConsultationController controller = new ConsultationController(mock.Object);

            var result = controller.Post(consultationModel);
            CreatedAtRouteResult okResult = result as CreatedAtRouteResult;
            PsychologistBasicInfoModel psychologistBasicInfoModel = okResult.Value as PsychologistBasicInfoModel;

            mock.VerifyAll();
            Assert.AreEqual(psychologistToReturn.Name, psychologistBasicInfoModel.Name);
            Assert.AreEqual(psychologistToReturn.ConsultationMode, psychologistBasicInfoModel.ConsultationMode);
            Assert.AreEqual(psychologistToReturn.Direction, psychologistBasicInfoModel.Direction);
        }

        [TestMethod]
        public void TestPostConsultationOk()
        {
            int problematicId = 1;
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
            CreatedAtRouteResult okResult = result as CreatedAtRouteResult;
            PsychologistBasicInfoModel psychologistBasicInfoModel = okResult.Value as PsychologistBasicInfoModel;

            mock.VerifyAll();
            Assert.AreEqual(psychologistToReturn.Name, psychologistBasicInfoModel.Name);
            Assert.AreEqual(psychologistToReturn.ConsultationMode, psychologistBasicInfoModel.ConsultationMode);
            Assert.AreEqual(psychologistToReturn.Direction, psychologistBasicInfoModel.Direction);
        }

        [TestMethod]
        public void TestPostConsultationGetCostOk()
        {
            int problematicId = 1;
            decimal cost = 500;
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
            ConsultationBasicInfoModel consultationToReturn = new ConsultationBasicInfoModel()
            {
                Cost = cost,
                Psychologist = psychologistToReturn
            };
            Mock<IConsultationLogicAdapter> mock = new Mock<IConsultationLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.Add(It.IsAny<ConsultationModel>())).Returns(psychologistToReturn);
            ConsultationController controller = new ConsultationController(mock.Object);

            var result = controller.Post(consultationModel);
            CreatedAtRouteResult okResult = result as CreatedAtRouteResult;
            ConsultationBasicInfoModel consultationBasicInfoModel = okResult.Value as ConsultationBasicInfoModel;

            mock.VerifyAll();
            Assert.AreEqual(cost, consultationBasicInfoModel.Cost);
            Assert.AreEqual(psychologistToReturn.Name, consultationBasicInfoModel.Psychologist.Name);
            Assert.AreEqual(psychologistToReturn.ConsultationMode, consultationBasicInfoModel.Psychologist.ConsultationMode);
            Assert.AreEqual(psychologistToReturn.Direction, consultationBasicInfoModel.Psychologist.Direction);
        }
    }
}
