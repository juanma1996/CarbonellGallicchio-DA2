using System;
using BusinessExceptions;
using BusinessLogic;
using DataAccessInterface;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BusinessLogicTests
{
    [TestClass]
    public class PsychologistLogicTests
    {
        [TestMethod]
        public void TestGetPsychologistByIdOk()
        {
            var psychologistId = 1;
            Psychologist psychologistToReturn = new Psychologist
            {
                Id = 1,
                Name = "Juan",
                Direction = "Rio negro",
                ConsultationMode = "Presencial",
                CreationDate = new DateTime(2021, 4, 20),
            };
            Mock<IRepository<Psychologist>> mock = new Mock<IRepository<Psychologist>>(MockBehavior.Strict);
            mock.Setup(m => m.GetById(psychologistId)).Returns(psychologistToReturn);
            PsychologistLogic psychologistLogic = new PsychologistLogic(mock.Object);

            Psychologist result = psychologistLogic.GetById(psychologistId);

            mock.VerifyAll();
            Assert.AreEqual(psychologistToReturn.Id, result.Id);
            Assert.AreEqual(psychologistToReturn.Name, result.Name);
            Assert.AreEqual(psychologistToReturn.Direction, result.Direction);
            Assert.AreEqual(psychologistToReturn.ConsultationMode, result.ConsultationMode);
            Assert.AreEqual(psychologistToReturn.CreationDate, result.CreationDate);
        }

        [TestMethod]
        [ExpectedException(typeof(NullObjectException))]
        public void TestGetPsychologistNotExistentId()
        {
            var psychologistId = 1;
            Mock<IRepository<Psychologist>> mock = new Mock<IRepository<Psychologist>>(MockBehavior.Strict);
            mock.Setup(m => m.GetById(psychologistId)).Returns((Psychologist)null);
            PsychologistLogic psychologistLogic = new PsychologistLogic(mock.Object);

            Psychologist result = psychologistLogic.GetById(psychologistId);

            mock.VerifyAll();
        }

        [TestMethod]
        public void TestCreatePsychologistOk()
        {
            int psychologistId = 1;
            Psychologist psycologistModel = new Psychologist
            {
                Name = "Juan",
                Direction = "Rio negro",
                ConsultationMode = "Presencial",
                CreationDate = new DateTime(2021, 4, 20),
            };
            Psychologist psychologistToReturn = new Psychologist
            {
                Id = psychologistId
            };
            Mock<IRepository<Psychologist>> mock = new Mock<IRepository<Psychologist>>(MockBehavior.Strict);
            mock.Setup(m => m.Add(It.IsAny<Psychologist>())).Returns(psychologistToReturn);
            PsychologistLogic psychologistLogic = new PsychologistLogic(mock.Object);

            Psychologist result = psychologistLogic.Add(psycologistModel);

            mock.VerifyAll();
            Assert.AreEqual(psychologistToReturn.Id, result.Id);
        }

        [TestMethod]
        public void TestDeletePsychologistOk()
        {
            int psychologistId = 1;
            Psychologist psychologistToReturn = new Psychologist
            {
                Id = 1,
                Name = "Juan",
                Direction = "Rio negro",
                ConsultationMode = "Presencial",
                CreationDate = new DateTime(2021, 4, 20),
            };
            Mock<IRepository<Psychologist>> mock = new Mock<IRepository<Psychologist>>(MockBehavior.Strict);
            mock.Setup(m => m.GetById(psychologistId)).Returns(psychologistToReturn);
            mock.Setup(m => m.Delete(psychologistToReturn));
            PsychologistLogic psychologistLogic = new PsychologistLogic(mock.Object);

            psychologistLogic.DeleteById(psychologistId);

            mock.VerifyAll();
        }

        [TestMethod]
        public void TestUpdatePsychologistOk()
        {
            Psychologist psycologistModel = new Psychologist
            {
                Name = "Juan",
                Direction = "Rio negro",
                ConsultationMode = "Presencial",
                CreationDate = new DateTime(2021, 4, 20),
            };
            Mock<IRepository<Psychologist>> mock = new Mock<IRepository<Psychologist>>(MockBehavior.Strict);
            mock.Setup(m => m.Update(psycologistModel));
            PsychologistLogic psychologistLogic = new PsychologistLogic(mock.Object);

            psychologistLogic.Update(psycologistModel);

            mock.VerifyAll();
        }
    }
}
