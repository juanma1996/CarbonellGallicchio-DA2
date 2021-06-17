using Adapter;
using Adapter.Mapper;
using Adapter.Mapper.Profiles;
using AdapterExceptions;
using AutoMapper;
using BusinessExceptions;
using BusinessLogicInterface;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.In;
using Model.Out;
using Moq;
using System;
using ValidatorInterface;

namespace AdapterTests
{
    [TestClass]
    public class ConsultationLogicAdapterTest
    {
        [TestMethod]
        public void TestConsultationMapOk()
        {
            ModelMapper mapper = new ModelMapper();
            MapperConfiguration configuration = new MapperConfiguration(mapper => mapper.AddProfile(new ConsultationProfile()));
            configuration.AssertConfigurationIsValid();
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void TestAdd()
        {
            ConsultationModel consultationModel = new ConsultationModel()
            {
                ProblematicId = 1
            };
            Mock<IConsultationLogic> mock = new Mock<IConsultationLogic>(MockBehavior.Strict);
            mock.Setup(m => m.Add(It.IsAny<Consultation>())).Throws(new NullObjectException("Not exist any playlist for this category"));
            ModelMapper mapper = new ModelMapper();
            Mock<IValidator<ConsultationModel>> mockValidatorConsultationModel = new Mock<IValidator<ConsultationModel>>(MockBehavior.Strict);
            mockValidatorConsultationModel.Setup(m => m.Validate(It.IsAny<ConsultationModel>()));
            Mock<IValidator<PacientModel>> mockValidatorPacientModel = new Mock<IValidator<PacientModel>>(MockBehavior.Strict);
            mockValidatorPacientModel.Setup(m => m.Validate(It.IsAny<PacientModel>()));
            ConsultationLogicAdapter consultationLogicAdapter = new ConsultationLogicAdapter(mock.Object, mapper,
                mockValidatorConsultationModel.Object, mockValidatorPacientModel.Object);

            consultationLogicAdapter.Add(consultationModel);

            mock.VerifyAll();
        }

        [TestMethod]
        public void TestAddConsultationGetCostOk()
        {
            decimal cost = 500;
            ConsultationModel consultationModel = new ConsultationModel
            {
                ProblematicId = 1,
                Pacient = new PacientModel
                {
                    Name = "Juan",
                    Surname = "Perez",
                    BirthDate = new DateTime(1996, 12, 05),
                    Email = "Juan@gmail.com",
                    Cellphone = "098342972"
                }
            };
            Psychologist psychologistToReturn = new Psychologist
            {
                Name = "Jorge",
                ConsultationMode = "Presencial",
                Direction = "Rio Negro 8156"
            };
            Consultation consultationToReturn = new Consultation()
            {
                Cost = cost,
                Psychologist = psychologistToReturn
            };
            Mock<IConsultationLogic> mock = new Mock<IConsultationLogic>(MockBehavior.Strict);
            mock.Setup(m => m.Add(It.IsAny<Consultation>())).Returns(consultationToReturn);
            ModelMapper mapper = new ModelMapper();
            Mock<IValidator<ConsultationModel>> mockValidatorConsultationModel = new Mock<IValidator<ConsultationModel>>(MockBehavior.Strict);
            mockValidatorConsultationModel.Setup(m => m.Validate(It.IsAny<ConsultationModel>()));
            Mock<IValidator<PacientModel>> mockValidatorPacientModel = new Mock<IValidator<PacientModel>>(MockBehavior.Strict);
            mockValidatorPacientModel.Setup(m => m.Validate(It.IsAny<PacientModel>()));
            ConsultationLogicAdapter consultationLogicAdapter = new ConsultationLogicAdapter(mock.Object, mapper,
                mockValidatorConsultationModel.Object, mockValidatorPacientModel.Object);

            ConsultationBasicInfoModel consultation = consultationLogicAdapter.Add(consultationModel);

            mock.VerifyAll();
            Assert.AreEqual(consultationToReturn.Cost, consultation.Cost);
        }
    }
}
