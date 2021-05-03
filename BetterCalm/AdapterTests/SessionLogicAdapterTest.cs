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
using ValidatorInterface;

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
        public void TestCreateSessionEmptyEmail()
        {
            SessionModel sessionModel = new SessionModel()
            {
                Email = "",
                Password = "onePassword"
            };
            Mock<ISessionLogic> mock = new Mock<ISessionLogic>(MockBehavior.Strict);
            mock.Setup(m => m.Add(It.IsAny<string>(), It.IsAny<string>())).Returns(It.IsAny<Session>());
            ModelMapper mapper = new ModelMapper();
            Mock<IValidator<SessionModel>> validatorMock = new Mock<IValidator<SessionModel>>(MockBehavior.Strict);
            validatorMock.Setup(m => m.Validate(sessionModel)).Throws(new InvalidAttributeException("Email can't be null"));
            SessionLogicAdapter sessionLogicAdapter = new SessionLogicAdapter(mock.Object, mapper, validatorMock.Object);

            var result = sessionLogicAdapter.Add(sessionModel);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestCreateSessionEmptyPassword()
        {
            SessionModel sessionModel = new SessionModel()
            {
                Email = "oneMail@gmail.com",
                Password = ""
            };
            Mock<ISessionLogic> mock = new Mock<ISessionLogic>(MockBehavior.Strict);
            mock.Setup(m => m.Add(It.IsAny<string>(), It.IsAny<string>())).Returns(It.IsAny<Session>());
            ModelMapper mapper = new ModelMapper();
            Mock<IValidator<SessionModel>> validatorMock = new Mock<IValidator<SessionModel>>(MockBehavior.Strict);
            validatorMock.Setup(m => m.Validate(sessionModel)).Throws(new InvalidAttributeException("Password can't be null"));
            SessionLogicAdapter sessionLogicAdapter = new SessionLogicAdapter(mock.Object, mapper, validatorMock.Object);

            var result = sessionLogicAdapter.Add(sessionModel);
        }
    }
}
