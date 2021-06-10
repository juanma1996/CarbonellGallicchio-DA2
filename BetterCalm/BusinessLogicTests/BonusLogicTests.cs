using BusinessExceptions;
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
            BonusLogic bonusLogic = new BonusLogic(mock.Object);

            List<Pacient> pacientsWithBonusGenerated = bonusLogic.GetAllGeneratedBonus();

            mock.VerifyAll();
            Assert.AreEqual(pacientsToReturn.Count, pacientsWithBonusGenerated.Count);
        }

        [TestMethod]
        public void TestApproveBonusOk()
        {
            int pacientId = 1;
            Pacient pacientToReturn = new Pacient()
            {
                Id = 1,
                Email = "juan@email.com",
                ConsultationsQuantity = 5
            };
            Mock<IRepository<Pacient>> mock = new Mock<IRepository<Pacient>>(MockBehavior.Strict);
            mock.Setup(m => m.Get(p => p.Id == pacientId)).Returns(pacientToReturn);
            mock.Setup(m => m.Update(It.IsAny<Pacient>()));
            BonusLogic bonusLogic = new BonusLogic(mock.Object);

            bonusLogic.Update(1, true, 0.25);

            mock.VerifyAll();
        }

        [TestMethod]
        public void TestDenyBonusOk()
        {
            int pacientId = 1;
            Pacient pacientToReturn = new Pacient()
            {
                Id = 1,
                Email = "juan@email.com",
                ConsultationsQuantity = 5
            };
            Mock<IRepository<Pacient>> mock = new Mock<IRepository<Pacient>>(MockBehavior.Strict);
            mock.Setup(m => m.Get(p => p.Id == pacientId)).Returns(pacientToReturn);
            mock.Setup(m => m.Update(It.IsAny<Pacient>()));
            BonusLogic bonusLogic = new BonusLogic(mock.Object);

            bonusLogic.Update(1, false, 0);

            mock.VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(NullObjectException))]
        public void TestApproveBonusNotExistPacientId()
        {
            int pacientId = 1;
            Pacient pacientToReturn = new Pacient()
            {
                Id = 1,
                Email = "juan@email.com",
                ConsultationsQuantity = 5
            };
            Mock<IRepository<Pacient>> mock = new Mock<IRepository<Pacient>>(MockBehavior.Strict);
            mock.Setup(m => m.Get(p => p.Id == pacientId)).Returns(pacientToReturn);
            mock.Setup(m => m.Update(It.IsAny<Pacient>()));
            BonusLogic bonusLogic = new BonusLogic(mock.Object);

            bonusLogic.Update(1, true, 0.25);

            mock.VerifyAll();
        }
    }
}
