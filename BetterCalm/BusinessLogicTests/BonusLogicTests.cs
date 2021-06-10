using BusinessLogic;
using DataAccessInterface;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace BusinessLogicTests
{
    [TestClass]
    public class BonusLogicTests
    {
        [TestMethod]
        public void TestGetAudioContentsOk()
        {
            Pacient firstPacientToReturn = new Pacient()
            {
                Id = 1,
                Email = "juan@email.com",
                ConsultationsQuantity = 5
            };
            Pacient secondPacientToReturn = new Pacient()
            {
                Id = 2,
                Email = "fede@email.com",
                ConsultationsQuantity = 6
            };
            List<Pacient> pacientsToReturn = new List<Pacient>() { firstPacientToReturn, secondPacientToReturn };
            Mock<IRepository<Pacient>> mock = new Mock<IRepository<Pacient>>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll(p => p.BonusApproved)).Returns(pacientsToReturn);
            BonusLogic bonusLogic = new BonusLogic();

            List<Pacient> pacientsWithBonusGenerated = bonusLogic.GetAll();

            mock.VerifyAll();
            Assert.AreEqual(pacientsToReturn.Count, pacientsWithBonusGenerated.Count);
        }
    }
}
