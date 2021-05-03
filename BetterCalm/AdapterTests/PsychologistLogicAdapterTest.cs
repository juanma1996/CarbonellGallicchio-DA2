using System;
using System.Collections.Generic;
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
    public class PsychologistLogicAdapterTest
    {
        [TestMethod]
        public void TestPsychologistMapOk()
        {
            ModelMapper mapper = new ModelMapper();
            var configuration = new MapperConfiguration(mapper => mapper.AddProfile(new PsychologistProfile()));
            configuration.AssertConfigurationIsValid();
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void TestGetByIdNotExistant()
        {
            int psychologistId = 1;
            Mock<IPsychologistLogic> mock = new Mock<IPsychologistLogic>(MockBehavior.Strict);
            mock.Setup(m => m.GetById(It.IsAny<int>())).Throws(new NullObjectException("Not exist any psychologist for the given data"));
            ModelMapper mapper = new ModelMapper();
            PsychologistLogicAdapter psychologistLogicAdapter = new PsychologistLogicAdapter(mock.Object, mapper);

            psychologistLogicAdapter.GetById(psychologistId);

            mock.VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void TestDeletePsychologistNotExistant()
        {
            int psychologistId = 1;
            Mock<IPsychologistLogic> mock = new Mock<IPsychologistLogic>(MockBehavior.Strict);
            mock.Setup(m => m.DeleteById(It.IsAny<int>())).Throws(new NullObjectException("Not exist any psychologist for the given data"));
            ModelMapper mapper = new ModelMapper();
            PsychologistLogicAdapter psychologistLogicAdapter = new PsychologistLogicAdapter(mock.Object, mapper);

            psychologistLogicAdapter.Delete(psychologistId);

            mock.VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void TestUpdatePsychologistNotExistant()
        {
            PsychologistModel psychologistModel = new PsychologistModel()
            {
                Id = 1,
                ConsultationMode = "some mode",
                Direction = "one direction",
                Name = "Juan",
                Problematics = new List<ProblematicModel>()
                {
                    new ProblematicModel()
                    {
                        Id = 1,
                        Name = "Federico"
                    }
                }
            };
            Mock<IPsychologistLogic> mock = new Mock<IPsychologistLogic>(MockBehavior.Strict);
            mock.Setup(m => m.Update(It.IsAny<Psychologist>())).Throws(new NullObjectException("Not exist any psychologist for the given data"));
            ModelMapper mapper = new ModelMapper();
            PsychologistLogicAdapter psychologistLogicAdapter = new PsychologistLogicAdapter(mock.Object, mapper);

            psychologistLogicAdapter.Update(psychologistModel);

            mock.VerifyAll();
        }
    }
}
