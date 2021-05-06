using AdapterExceptions;
using AdapterInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.In;
using Model.Out;
using Moq;
using System;
using WebApi.Controllers;

namespace WebApiTests
{
    [TestClass]
    public class SessionControllerTest
    {
        [TestMethod]
        public void TestPostSessionOk()
        {
            string mail = "oneMail@gmail.com";
            Guid token = Guid.NewGuid();
            SessionModel sessionModel = new SessionModel()
            {
                Email = mail,
                Password = "onePassword"
            };
            SessionBasicInfoModel sessionToReturn = new SessionBasicInfoModel()
            {
                Email = mail,
                Token = token
            };
            Mock<ISessionLogicAdapter> mock = new Mock<ISessionLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.Add(It.IsAny<SessionModel>())).Returns(sessionToReturn);
            SessionController controller = new SessionController(mock.Object);

            var result = controller.Post(sessionModel);
            CreatedAtRouteResult createdAtRouteResult = result as CreatedAtRouteResult;
            SessionBasicInfoModel sessionBasicInfoModel = createdAtRouteResult.Value as SessionBasicInfoModel;

            mock.VerifyAll();
            Assert.AreEqual(sessionToReturn.Email, sessionBasicInfoModel.Email);
            Assert.AreEqual(sessionToReturn.Token, sessionBasicInfoModel.Token);
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void TestPostSessionEmailNotExistent()
        {
            string mail = "oneMail@gmail.com";
            SessionModel sessionModel = new SessionModel()
            {
                Email = mail,
                Password = "onePassword"
            };
            Mock<ISessionLogicAdapter> mock = new Mock<ISessionLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.Add(It.IsAny<SessionModel>())).Throws(new NotFoundException("Email not registered"));
            SessionController controller = new SessionController(mock.Object);

            var result = controller.Post(sessionModel);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestPostSessionIncorrectPasswordForEmail()
        {
            string mail = "oneMail@gmail.com";
            SessionModel sessionModel = new SessionModel()
            {
                Email = mail,
                Password = "onePassword"
            };
            Mock<ISessionLogicAdapter> mock = new Mock<ISessionLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.Add(It.IsAny<SessionModel>())).Throws(new InvalidAttributeException("Incorrect password for email"));
            SessionController controller = new SessionController(mock.Object);

            var result = controller.Post(sessionModel);
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
            Mock<ISessionLogicAdapter> mock = new Mock<ISessionLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.Add(It.IsAny<SessionModel>())).Throws(new InvalidAttributeException("Email can't be null"));
            SessionController controller = new SessionController(mock.Object);

            var result = controller.Post(sessionModel);
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
            Mock<ISessionLogicAdapter> mock = new Mock<ISessionLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.Add(It.IsAny<SessionModel>())).Throws(new InvalidAttributeException("Password can't be null"));
            SessionController controller = new SessionController(mock.Object);

            var result = controller.Post(sessionModel);
        }
    }
}
