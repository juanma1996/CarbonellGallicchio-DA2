using DataAccessInterface;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SessionLogic;
using System;
using System.Linq.Expressions;

namespace SessionLogicTests
{
    [TestClass]
    public class SessionLogicsTests
    {
        [TestMethod]
        public void TestValidToken()
        {
            string token = new Guid().ToString();
            Mock<IRepository<Session>> mock = new Mock<IRepository<Session>>(MockBehavior.Strict);
            mock.Setup(m => m.Exists(s => s.Token == Guid.Parse(token))).Returns(true);
            Mock<IRepository<Administrator>> mockAdministrator = new Mock<IRepository<Administrator>>(MockBehavior.Strict);
            mockAdministrator.Setup(m => m.Get(It.IsAny<Expression<Func<Administrator, bool>>>())).Returns(It.IsAny<Administrator>);
            SessionLogics sessionLogic = new SessionLogics(mock.Object, mockAdministrator.Object);

            bool result = sessionLogic.IsValidToken(token);

            mock.VerifyAll();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestNotExistentToken()
        {
            string token = new Guid().ToString();
            Mock<IRepository<Session>> mock = new Mock<IRepository<Session>>(MockBehavior.Strict);
            mock.Setup(m => m.Exists(s => s.Token == Guid.Parse(token))).Returns(false);
            Mock<IRepository<Administrator>> mockAdministrator = new Mock<IRepository<Administrator>>(MockBehavior.Strict);
            mockAdministrator.Setup(m => m.Get(It.IsAny<Expression<Func<Administrator, bool>>>())).Returns(It.IsAny<Administrator>);
            SessionLogics sessionLogic = new SessionLogics(mock.Object, mockAdministrator.Object);

            bool result = sessionLogic.IsValidToken(token);

            mock.VerifyAll();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestNotValidGuidToken()
        {
            string token = "not guid";
            Mock<IRepository<Session>> mock = new Mock<IRepository<Session>>(MockBehavior.Strict);
            mock.Setup(m => m.Exists(It.IsAny<Expression<Func<Session, bool>>>())).Returns(false);
            Mock<IRepository<Administrator>> mockAdministrator = new Mock<IRepository<Administrator>>(MockBehavior.Strict);
            mockAdministrator.Setup(m => m.Get(It.IsAny<Expression<Func<Administrator, bool>>>())).Returns(It.IsAny<Administrator>);
            SessionLogics sessionLogic = new SessionLogics(mock.Object, mockAdministrator.Object);

            bool result = sessionLogic.IsValidToken(token);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestLogInCorrectly()
        {
            string email = "oneMail@gmail.com";
            string password = "onePassword";
            Guid tokenToReturn = Guid.NewGuid();
            Session sessionToReturn = new Session
            {
                Token = tokenToReturn
            };
            Mock<IRepository<Session>> mock = new Mock<IRepository<Session>>(MockBehavior.Strict);
            mock.Setup(m => m.Add(It.IsAny<Session>())).Returns(sessionToReturn);
            Mock<IRepository<Administrator>> mockAdministrator = new Mock<IRepository<Administrator>>(MockBehavior.Strict);
            mockAdministrator.Setup(m => m.Get(It.IsAny<Expression<Func<Administrator, bool>>>())).Returns(It.IsAny<Administrator>);
            SessionLogics sessionLogic = new SessionLogics(mock.Object, mockAdministrator.Object);

            Session result = sessionLogic.Add(email, password);

            mock.VerifyAll();
            Assert.AreEqual(tokenToReturn, result.Token);
        }

        [TestMethod]
        public void TestLogInCorrectlyGetAdminId()
        {
            string email = "oneMail@gmail.com";
            string password = "onePassword";
            Guid tokenToReturn = Guid.NewGuid();
            Administrator admin = new Administrator()
            {
                Id = 1,
                Email = email,
                Password = password
            };
            Session sessionToReturn = new Session
            {
                Token = tokenToReturn,
                Administrator = admin
            };
            Mock<IRepository<Session>> mock = new Mock<IRepository<Session>>(MockBehavior.Strict);
            mock.Setup(m => m.Add(It.IsAny<Session>())).Returns(sessionToReturn);
            Mock<IRepository<Administrator>> mockAdministrator = new Mock<IRepository<Administrator>>(MockBehavior.Strict);
            mockAdministrator.Setup(m => m.Get(a => a.Email == email && a.Password == password)).Returns(admin);
            SessionLogics sessionLogic = new SessionLogics(mock.Object, mockAdministrator.Object);

            Session result = sessionLogic.Add(email, password);

            mock.VerifyAll();
            Assert.AreEqual(admin.Id, result.Administrator.Id);
        }
    }
}
