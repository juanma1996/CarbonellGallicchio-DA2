using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
                Problematics = new List<PsychologistProblematic>
                {
                    new PsychologistProblematic
                    {
                        ProblematicId = 1,
                    }
                }
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
        [ExpectedException(typeof(NullObjectException))]
        public void TestDeletePsychologistNotExistentId()
        {
            int psychologistId = 1;
            Mock<IRepository<Psychologist>> mock = new Mock<IRepository<Psychologist>>(MockBehavior.Strict);
            mock.Setup(m => m.GetById(psychologistId)).Returns((Psychologist)null);
            mock.Setup(m => m.Delete(It.IsAny<Psychologist>()));
            PsychologistLogic psychologistLogic = new PsychologistLogic(mock.Object);

            psychologistLogic.DeleteById(psychologistId);

            mock.VerifyAll();
        }

        [TestMethod]
        public void TestUpdatePsychologistOk()
        {
            var psychologistId = 1;
            Psychologist psychologistModel = new Psychologist
            {
                Id = psychologistId,
                Direction = "Rio negro",
                ConsultationMode = "Presencial",
                CreationDate = new DateTime(2021, 4, 20),
                Problematics = new List<PsychologistProblematic>
                {
                    new PsychologistProblematic
                    {
                        ProblematicId = 1,
                    }
                }
            };
            Mock<IRepository<Psychologist>> mock = new Mock<IRepository<Psychologist>>(MockBehavior.Strict);
            mock.Setup(m => m.Exists(a => a.Id == psychologistModel.Id)).Returns(true);
            mock.Setup(m => m.Update(psychologistModel));
            PsychologistLogic psychologistLogic = new PsychologistLogic(mock.Object);

            psychologistLogic.Update(psychologistModel);

            mock.VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(NullObjectException))]
        public void TestUpdatePsychologistNotExistent()
        {
            var psychologistId = 1;
            Psychologist psychologistModel = new Psychologist
            {
                Id = psychologistId,
                Name = "Juan",
                Direction = "Rio negro",
                ConsultationMode = "Presencial",
                CreationDate = new DateTime(2021, 4, 20),
            };
            Mock<IRepository<Psychologist>> mock = new Mock<IRepository<Psychologist>>(MockBehavior.Strict);
            mock.Setup(m => m.Exists(a => a.Id == psychologistModel.Id)).Returns(false);
            mock.Setup(m => m.Update(It.IsAny<Psychologist>()));
            PsychologistLogic psychologistLogic = new PsychologistLogic(mock.Object);

            psychologistLogic.Update(psychologistModel);

            mock.VerifyAll();
        }

        [TestMethod]
        public void TestGetAvailableByProblematicIdOk()
        {
            var problematicId = 1;
            Psychologist psychologistToReturn = new Psychologist
            {
                Id = 1,
                Name = "Juan",
                Direction = "Rio negro",
                ConsultationMode = "Presencial",
                CreationDate = new DateTime(2021, 4, 20),
                Problematics = new List<PsychologistProblematic>
                {
                    new PsychologistProblematic
                    {
                        ProblematicId = problematicId,
                    }
                }
            };
            Mock<IRepository<Psychologist>> mock = new Mock<IRepository<Psychologist>>(MockBehavior.Strict);
            mock.Setup(m => m.Get(It.IsAny<Expression<Func<Psychologist, bool>>>())).Returns(psychologistToReturn);
            PsychologistLogic psychologistLogic = new PsychologistLogic(mock.Object);

            Psychologist psychologist = psychologistLogic.GetAvailableByProblematicId(problematicId);

            mock.VerifyAll();
            Assert.AreEqual(psychologistToReturn.Id, psychologist.Id);
            Assert.AreEqual(psychologistToReturn.Name, psychologist.Name);
            Assert.AreEqual(psychologistToReturn.Direction, psychologist.Direction);
            Assert.AreEqual(psychologistToReturn.ConsultationMode, psychologist.ConsultationMode);
            Assert.AreEqual(psychologistToReturn.CreationDate, psychologist.CreationDate);
            Assert.IsTrue(psychologist.Problematics.Exists(p => p.ProblematicId == problematicId));
        }
    }
}
