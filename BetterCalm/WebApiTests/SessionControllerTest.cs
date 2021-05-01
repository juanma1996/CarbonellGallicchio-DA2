using AdapterInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.In;
using Model.Out;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
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
            var createdAtRouteResult = result as CreatedAtRouteResult;
            var sessionBasicInfoModel = createdAtRouteResult.Value as SessionBasicInfoModel;

            mock.VerifyAll();
            Assert.AreEqual(sessionToReturn.Email, sessionBasicInfoModel.Email);
            Assert.AreEqual(sessionToReturn.Token, sessionBasicInfoModel.Token);
        }
    }
}
