using System;
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
using Moq;

namespace AdapterTests
{
    [TestClass]
    public class ConsultationLogicAdapterTest
    {
        [TestMethod]
        public void TestConsultationMapOk()
        {
            ModelMapper mapper = new ModelMapper();
            var configuration = new MapperConfiguration(mapper => mapper.AddProfile(new ConsultationProfile()));
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
            ConsultationLogicAdapter consultationLogicAdapter = new ConsultationLogicAdapter(mock.Object, mapper);

            consultationLogicAdapter.Add(consultationModel);

            mock.VerifyAll();
        }
    }
}
