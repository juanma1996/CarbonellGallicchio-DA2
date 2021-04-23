using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogic;
using DataAccessInterface;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BusinessLogicTests
{
    [TestClass]
    public class ProblematicLogicTest
    {
        [TestMethod]
        public void TestGetProblematicsOk()
        {
            List<Problematic> problematicsToReturn = new List<Problematic>()
            {
                new Problematic
                {
                    Name = "Estrés"
                },
                new Problematic
                {
                    Name = "Ansiedad"
                },
            };
            Mock<IRepository<Problematic>> mock = new Mock<IRepository<Problematic>>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll(null)).Returns(problematicsToReturn);
            ProblematicLogic problematicLogic = new ProblematicLogic();

            List<Problematic> problematics = problematicLogic.GetAll();

            mock.VerifyAll();
            Assert.AreEqual(problematics.First().Id, problematicsToReturn.First().Id);
            Assert.AreEqual(problematics.First().Name, problematicsToReturn.First().Name);
        }
    }
}
