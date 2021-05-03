using System;
using Adapter;
using Adapter.Mapper;
using Adapter.Mapper.Profiles;
using AdapterExceptions;
using AutoMapper;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.In;
using Moq;
using SessionInterface;

namespace AdapterTests
{
    [TestClass]
    public class SessionLogicAdapterTest
    {
        [TestMethod]
        public void TestSessionMapOk()
        {
            ModelMapper mapper = new ModelMapper();
            var configuration = new MapperConfiguration(mapper => mapper.AddProfile(new SessionProfile()));
            configuration.AssertConfigurationIsValid();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestPostSessionEmptyEmail()
        {
            SessionModel sessionModel = new SessionModel()
            {
                Email = "",
                Password = "onePassword"
            };
            Mock<ISessionLogic> mock = new Mock<ISessionLogic>(MockBehavior.Strict);
            mock.Setup(m => m.Add(It.IsAny<string>(), It.IsAny<string>())).Returns(It.IsAny<Session>());
            ModelMapper mapper = new ModelMapper();
            SessionLogicAdapter sessionLogicAdapter = new SessionLogicAdapter(mock.Object, mapper);

            var result = sessionLogicAdapter.Add(sessionModel);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestPostSessionEmptyPassword()
        {
            SessionModel sessionModel = new SessionModel()
            {
                Email = "oneMail@gmail.com",
                Password = ""
            };
            Mock<ISessionLogic> mock = new Mock<ISessionLogic>(MockBehavior.Strict);
            mock.Setup(m => m.Add(It.IsAny<string>(), It.IsAny<string>())).Returns(It.IsAny<Session>());
            ModelMapper mapper = new ModelMapper();
            SessionLogicAdapter sessionLogicAdapter = new SessionLogicAdapter(mock.Object, mapper);

            var result = sessionLogicAdapter.Add(sessionModel);
        }
    }
}
