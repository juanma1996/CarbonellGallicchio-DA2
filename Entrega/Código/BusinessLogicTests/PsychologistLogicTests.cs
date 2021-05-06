using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessExceptions;
using BusinessLogic;
using BusinessLogicInterface;
using DataAccessInterface;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ValidatorInterface;

namespace BusinessLogicTests
{
    [TestClass]
    public class PsychologistLogicTests
    {
        [TestMethod]
        public void TestGetPsychologistByIdOk()
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
            Mock<IAgendaLogic> mockAgendaLogic = new Mock<IAgendaLogic>(MockBehavior.Strict);
            Mock<IValidator<Psychologist>> validatorMock = new Mock<IValidator<Psychologist>>(MockBehavior.Strict);
            validatorMock.Setup(m => m.Validate(It.IsAny<Psychologist>()));
            PsychologistLogic psychologistLogic = new PsychologistLogic(mock.Object, mockAgendaLogic.Object, validatorMock.Object);

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
            int psychologistId = 1;
            Mock<IRepository<Psychologist>> mock = new Mock<IRepository<Psychologist>>(MockBehavior.Strict);
            mock.Setup(m => m.GetById(psychologistId)).Returns((Psychologist)null);
            Mock<IAgendaLogic> mockAgendaLogic = new Mock<IAgendaLogic>(MockBehavior.Strict);
            Mock<IValidator<Psychologist>> validatorMock = new Mock<IValidator<Psychologist>>(MockBehavior.Strict);
            validatorMock.Setup(m => m.Validate(It.IsAny<Psychologist>())).Throws(new NullObjectException("There is no psychologist for the given data"));
            PsychologistLogic psychologistLogic = new PsychologistLogic(mock.Object, mockAgendaLogic.Object, validatorMock.Object);

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
            Mock<IAgendaLogic> mockAgendaLogic = new Mock<IAgendaLogic>(MockBehavior.Strict);
            Mock<IValidator<Psychologist>> validatorMock = new Mock<IValidator<Psychologist>>(MockBehavior.Strict);
            validatorMock.Setup(m => m.Validate(It.IsAny<Psychologist>()));
            PsychologistLogic psychologistLogic = new PsychologistLogic(mock.Object, mockAgendaLogic.Object, validatorMock.Object);

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
            Mock<IAgendaLogic> mockAgendaLogic = new Mock<IAgendaLogic>(MockBehavior.Strict);
            Mock<IValidator<Psychologist>> validatorMock = new Mock<IValidator<Psychologist>>(MockBehavior.Strict);
            validatorMock.Setup(m => m.Validate(It.IsAny<Psychologist>()));
            PsychologistLogic psychologistLogic = new PsychologistLogic(mock.Object, mockAgendaLogic.Object, validatorMock.Object);

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
            Mock<IAgendaLogic> mockAgendaLogic = new Mock<IAgendaLogic>(MockBehavior.Strict);
            Mock<IValidator<Psychologist>> validatorMock = new Mock<IValidator<Psychologist>>(MockBehavior.Strict);
            validatorMock.Setup(m => m.Validate(It.IsAny<Psychologist>())).Throws(new NullObjectException("There is no psychologist for the given data"));
            PsychologistLogic psychologistLogic = new PsychologistLogic(mock.Object, mockAgendaLogic.Object, validatorMock.Object);

            psychologistLogic.DeleteById(psychologistId);

            mock.VerifyAll();
        }

        [TestMethod]
        public void TestUpdatePsychologistOk()
        {
            int psychologistId = 1;
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
            Mock<IAgendaLogic> mockAgendaLogic = new Mock<IAgendaLogic>(MockBehavior.Strict);
            Mock<IValidator<Psychologist>> validatorMock = new Mock<IValidator<Psychologist>>(MockBehavior.Strict);
            validatorMock.Setup(m => m.Validate(It.IsAny<Psychologist>()));
            PsychologistLogic psychologistLogic = new PsychologistLogic(mock.Object, mockAgendaLogic.Object, validatorMock.Object);

            psychologistLogic.Update(psychologistModel);

            mock.VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(NullObjectException))]
        public void TestUpdatePsychologistNotExistent()
        {
            int psychologistId = 1;
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
            Mock<IAgendaLogic> mockAgendaLogic = new Mock<IAgendaLogic>(MockBehavior.Strict);
            Mock<IValidator<Psychologist>> validatorMock = new Mock<IValidator<Psychologist>>(MockBehavior.Strict);
            validatorMock.Setup(m => m.Validate(It.IsAny<Psychologist>())).Throws(new NullObjectException("There is no psychologist for the given data"));
            PsychologistLogic psychologistLogic = new PsychologistLogic(mock.Object, mockAgendaLogic.Object, validatorMock.Object);

            psychologistLogic.Update(psychologistModel);

            mock.VerifyAll();
        }

        [TestMethod]
        public void TestGetAvailableByProblematicIdOk()
        {
            int problematicId = 1;
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
            Mock<IAgendaLogic> mockAgendaLogic = new Mock<IAgendaLogic>(MockBehavior.Strict);
            Mock<IValidator<Psychologist>> validatorMock = new Mock<IValidator<Psychologist>>(MockBehavior.Strict);
            validatorMock.Setup(m => m.Validate(It.IsAny<Psychologist>()));
            PsychologistLogic psychologistLogic = new PsychologistLogic(mock.Object, mockAgendaLogic.Object, validatorMock.Object);

            Psychologist psychologist = psychologistLogic.GetAvailableByProblematicId(problematicId);

            mock.VerifyAll();
            Assert.AreEqual(psychologistToReturn.Id, psychologist.Id);
            Assert.AreEqual(psychologistToReturn.Name, psychologist.Name);
            Assert.AreEqual(psychologistToReturn.Direction, psychologist.Direction);
            Assert.AreEqual(psychologistToReturn.ConsultationMode, psychologist.ConsultationMode);
            Assert.AreEqual(psychologistToReturn.CreationDate, psychologist.CreationDate);
            Assert.IsTrue(psychologist.Problematics.Exists(p => p.ProblematicId == problematicId));
        }

        [TestMethod]
        public void TestGetAvailableByProblematicIdTwoOptions()
        {
            int problematicId = 1;
            Psychologist antiquePsychologist = new Psychologist
            {
                Id = 1,
                Name = "Juan",
                Direction = "Rio negro",
                ConsultationMode = "Presencial",
                CreationDate = new DateTime(1999, 4, 20),
                Problematics = new List<PsychologistProblematic>
                {
                    new PsychologistProblematic
                    {
                        ProblematicId = problematicId,
                    }
                }
            };
            Psychologist newerPsychologist = new Psychologist
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
            mock.Setup(m => m.Get(It.IsAny<Expression<Func<Psychologist, bool>>>())).Returns(antiquePsychologist);
            Mock<IAgendaLogic> mockAgendaLogic = new Mock<IAgendaLogic>(MockBehavior.Strict);
            Mock<IValidator<Psychologist>> validatorMock = new Mock<IValidator<Psychologist>>(MockBehavior.Strict);
            validatorMock.Setup(m => m.Validate(It.IsAny<Psychologist>()));
            PsychologistLogic psychologistLogic = new PsychologistLogic(mock.Object, mockAgendaLogic.Object, validatorMock.Object);

            Psychologist psychologist = psychologistLogic.GetAvailableByProblematicId(problematicId);

            mock.VerifyAll();
            Assert.AreEqual(antiquePsychologist.Id, psychologist.Id);
            Assert.AreEqual(antiquePsychologist.Name, psychologist.Name);
            Assert.AreEqual(antiquePsychologist.Direction, psychologist.Direction);
            Assert.AreEqual(antiquePsychologist.ConsultationMode, psychologist.ConsultationMode);
            Assert.AreEqual(antiquePsychologist.CreationDate, psychologist.CreationDate);
            Assert.IsTrue(psychologist.Problematics.Exists(p => p.ProblematicId == problematicId));
        }

        [TestMethod]
        public void TestGetAvailablesByProblematicId()
        {
            int problematicId = 1;
            List<Psychologist> psychologists = new List<Psychologist>();
            Psychologist onePsychologist = new Psychologist
            {
                Id = 1,
                Name = "Juan",
                Direction = "Rio negro",
                ConsultationMode = "Presencial",
                CreationDate = new DateTime(1999, 4, 20),
                Problematics = new List<PsychologistProblematic>
                {
                    new PsychologistProblematic
                    {
                        ProblematicId = problematicId,
                    }
                }
            };
            psychologists.Add(onePsychologist);
            Psychologist anotherPsychologist = new Psychologist
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
            psychologists.Add(anotherPsychologist);
            Mock<IRepository<Psychologist>> mock = new Mock<IRepository<Psychologist>>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll(It.IsAny<Expression<Func<Psychologist, bool>>>())).Returns(psychologists);
            mock.Setup(m => m.Exists(It.IsAny<Expression<Func<Psychologist, bool>>>())).Returns(true);
            Mock<IAgendaLogic> mockAgendaLogic = new Mock<IAgendaLogic>(MockBehavior.Strict);
            Mock<IValidator<Psychologist>> validatorMock = new Mock<IValidator<Psychologist>>(MockBehavior.Strict);
            validatorMock.Setup(m => m.Validate(It.IsAny<Psychologist>()));
            PsychologistLogic psychologistLogic = new PsychologistLogic(mock.Object, mockAgendaLogic.Object, validatorMock.Object);

            List<Psychologist> result = psychologistLogic.GetAllByProblematicId(problematicId);

            mock.VerifyAll();
            Assert.AreEqual(psychologists.Count, result.Count);
        }

        [TestMethod]
        public void TestGetAvailableByProblematicIdAndDateOk()
        {
            int problematicId = 1;
            DateTime date = DateTime.Now;
            List<Psychologist> psychologists = new List<Psychologist>();
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
            psychologists.Add(psychologistToReturn);
            Agenda agenda = new Agenda()
            {
                IsAvaible = true,
                Psychologist = psychologistToReturn
            };
            Mock<IRepository<Psychologist>> mock = new Mock<IRepository<Psychologist>>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll(It.IsAny<Expression<Func<Psychologist, bool>>>())).Returns(psychologists);
            mock.Setup(m => m.Exists(It.IsAny<Expression<Func<Psychologist, bool>>>())).Returns(true);
            Mock<IAgendaLogic> mockAgendaLogic = new Mock<IAgendaLogic>(MockBehavior.Strict);
            mockAgendaLogic.Setup(m => m.GetAgendaByPsychologistIdAndDate(It.IsAny<int>(), It.IsAny<DateTime>())).Returns(agenda);
            mockAgendaLogic.Setup(m => m.Add(It.IsAny<Psychologist>(), It.IsAny<DateTime>())).Returns(It.IsAny<Agenda>());
            mockAgendaLogic.Setup(m => m.Update(It.IsAny<Agenda>()));
            mockAgendaLogic.Setup(m => m.Assign(It.IsAny<Agenda>())).Returns(It.IsAny<Agenda>());
            Mock<IValidator<Psychologist>> validatorMock = new Mock<IValidator<Psychologist>>(MockBehavior.Strict);
            validatorMock.Setup(m => m.Validate(It.IsAny<Psychologist>()));
            PsychologistLogic psychologistLogic = new PsychologistLogic(mock.Object, mockAgendaLogic.Object, validatorMock.Object);

            Psychologist psychologist = psychologistLogic.GetAvailableByProblematicIdAndDate(problematicId, date);

            mock.VerifyAll();
            Assert.AreEqual(psychologistToReturn.Id, psychologist.Id);
            Assert.AreEqual(psychologistToReturn.Name, psychologist.Name);
            Assert.AreEqual(psychologistToReturn.Direction, psychologist.Direction);
            Assert.AreEqual(psychologistToReturn.ConsultationMode, psychologist.ConsultationMode);
            Assert.AreEqual(psychologistToReturn.CreationDate, psychologist.CreationDate);
        }

        [TestMethod]
        [ExpectedException(typeof(NullObjectException))]
        public void TestGetAvailableByProblematicIdAndDateNoPsychologist()
        {
            int problematicId = 1;
            DateTime date = DateTime.Now;
            List<Psychologist> psychologists = new List<Psychologist>();
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
            Agenda agenda = new Agenda()
            {
                IsAvaible = true,
                Psychologist = psychologistToReturn
            };
            Mock<IRepository<Psychologist>> mock = new Mock<IRepository<Psychologist>>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll(It.IsAny<Expression<Func<Psychologist, bool>>>())).Returns(psychologists);
            mock.Setup(m => m.Exists(It.IsAny<Expression<Func<Psychologist, bool>>>())).Returns(true);
            Mock<IAgendaLogic> mockAgendaLogic = new Mock<IAgendaLogic>(MockBehavior.Strict);
            mockAgendaLogic.Setup(m => m.GetAgendaByPsychologistIdAndDate(It.IsAny<int>(), It.IsAny<DateTime>())).Returns(agenda);
            mockAgendaLogic.Setup(m => m.Add(It.IsAny<Psychologist>(), It.IsAny<DateTime>())).Returns(It.IsAny<Agenda>());
            mockAgendaLogic.Setup(m => m.Update(It.IsAny<Agenda>()));
            Mock<IValidator<Psychologist>> validatorMock = new Mock<IValidator<Psychologist>>(MockBehavior.Strict);
            validatorMock.Setup(m => m.Validate(It.IsAny<Psychologist>())).Throws(new NullObjectException("There is no psychologist for the given data"));
            PsychologistLogic psychologistLogic = new PsychologistLogic(mock.Object, mockAgendaLogic.Object, validatorMock.Object);

            Psychologist psychologist = psychologistLogic.GetAvailableByProblematicIdAndDate(problematicId, date);
        }

        [TestMethod]
        public void TestGetAvailablesByProblematicOther()
        {
            int problematicId = 8;
            List<Psychologist> psychologists = new List<Psychologist>();
            Psychologist onePsychologist = new Psychologist
            {
                Id = 1,
                Name = "Juan",
                Direction = "Rio negro",
                ConsultationMode = "Presencial",
                CreationDate = new DateTime(1999, 4, 20),
                Problematics = new List<PsychologistProblematic>
                {
                    new PsychologistProblematic
                    {
                        ProblematicId = 2,
                    }
                }
            };
            psychologists.Add(onePsychologist);
            Psychologist anotherPsychologist = new Psychologist
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
            psychologists.Add(anotherPsychologist);
            Mock<IRepository<Psychologist>> mock = new Mock<IRepository<Psychologist>>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll(It.IsAny<Expression<Func<Psychologist, bool>>>())).Returns(psychologists);
            mock.Setup(m => m.Exists(It.IsAny<Expression<Func<Psychologist, bool>>>())).Returns(true);
            Mock<IAgendaLogic> mockAgendaLogic = new Mock<IAgendaLogic>(MockBehavior.Strict);
            Mock<IValidator<Psychologist>> validatorMock = new Mock<IValidator<Psychologist>>(MockBehavior.Strict);
            validatorMock.Setup(m => m.Validate(It.IsAny<Psychologist>()));
            PsychologistLogic psychologistLogic = new PsychologistLogic(mock.Object, mockAgendaLogic.Object, validatorMock.Object);

            List<Psychologist> result = psychologistLogic.GetAllByProblematicId(problematicId);

            mock.VerifyAll();
            Assert.AreEqual(psychologists.Count, result.Count);
        }        
    }
}
