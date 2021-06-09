using System;
using System.Collections.Generic;
using BusinessExceptions;
using BusinessLogic;
using BusinessLogicInterface;
using DataAccessInterface;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BusinessLogicTests
{
    [TestClass]
    public class ConsultationLogicTest
    {
        [TestMethod]
        public void TestAddConsultationPresencialOk()
        {
            int problematicId = 1;
            Consultation consultationModel = new Consultation
            {
                ProblematicId = problematicId,
                Pacient = new Pacient
                {
                    Name = "Juan",
                    Surname = "Perez",
                    BirthDate = new DateTime(1996, 12, 05),
                    Email = "Juan@gmail.com",
                    Cellphone = "098342972"
                }
            };
            Psychologist psychologist = new Psychologist
            {
                Name = "Juan",
                Direction = "Rio negro",
                ConsultationMode = "Presencial",
                CreationDate = new DateTime(2021, 4, 20),
                Problematics = new List<PsychologistProblematic>
                {
                    new PsychologistProblematic
                    {
                        ProblematicId = problematicId,
                    },
                    new PsychologistProblematic
                    {
                        ProblematicId = 2,
                    },
                    new PsychologistProblematic
                    {
                        ProblematicId = 3,
                    },
                    new PsychologistProblematic
                    {
                        ProblematicId = 4,
                    }
                }
            };
            Consultation consultationToReturn = new Consultation
            {
                ProblematicId = problematicId,
                Pacient = new Pacient
                {
                    Name = "Juan",
                    Surname = "Perez",
                    BirthDate = new DateTime(1996, 12, 05),
                    Email = "Juan@gmail.com",
                    Cellphone = "098342972"
                },
                Psychologist = psychologist,
            };
            Mock<IRepository<Consultation>> mock = new Mock<IRepository<Consultation>>(MockBehavior.Strict);
            mock.Setup(p => p.Add(It.IsAny<Consultation>())).Returns(consultationToReturn);
            Mock<IPsychologistLogic> psychologistMock = new Mock<IPsychologistLogic>(MockBehavior.Strict);
            psychologistMock.Setup(p => p.GetAvailableByProblematicIdAndDate(It.IsAny<int>(), It.IsAny<DateTime>())).Returns(psychologist);
            ConsultationLogic consultationLogic = new ConsultationLogic(mock.Object, psychologistMock.Object);

            Consultation returnedConsultation = consultationLogic.Add(consultationModel);

            mock.VerifyAll();
            Assert.AreEqual(psychologist.Id, returnedConsultation.Psychologist.Id);
            Assert.AreEqual(psychologist.Name, returnedConsultation.Psychologist.Name);
            Assert.AreEqual(psychologist.Direction, returnedConsultation.Psychologist.Direction);
            Assert.AreEqual(psychologist.ConsultationMode, returnedConsultation.Psychologist.ConsultationMode);
        }

        [TestMethod]
        public void TestAddConsultationPresencialCheckDirection()
        {
            int problematicId = 1;
            Consultation consultationModel = new Consultation
            {
                ProblematicId = problematicId,
                Pacient = new Pacient
                {
                    Name = "Juan",
                    Surname = "Perez",
                    BirthDate = new DateTime(1996, 12, 05),
                    Email = "Juan@gmail.com",
                    Cellphone = "098342972"
                }
            };
            Psychologist psychologist = new Psychologist
            {
                Name = "Juan",
                Direction = "Rio negro",
                ConsultationMode = "Presencial",
                CreationDate = new DateTime(2021, 4, 20),
                Problematics = new List<PsychologistProblematic>
                {
                    new PsychologistProblematic
                    {
                        ProblematicId = problematicId,
                    },
                    new PsychologistProblematic
                    {
                        ProblematicId = 2,
                    },
                    new PsychologistProblematic
                    {
                        ProblematicId = 3,
                    },
                    new PsychologistProblematic
                    {
                        ProblematicId = 4,
                    }
                }
            };
            Consultation consultationToReturn = new Consultation
            {
                ProblematicId = problematicId,
                Pacient = new Pacient
                {
                    Name = "Juan",
                    Surname = "Perez",
                    BirthDate = new DateTime(1996, 12, 05),
                    Email = "Juan@gmail.com",
                    Cellphone = "098342972"
                },
                Psychologist = psychologist,
            };
            Mock<IRepository<Consultation>> mock = new Mock<IRepository<Consultation>>(MockBehavior.Strict);
            mock.Setup(p => p.Add(It.IsAny<Consultation>())).Returns(consultationToReturn);
            Mock<IPsychologistLogic> psychologistMock = new Mock<IPsychologistLogic>(MockBehavior.Strict);
            psychologistMock.Setup(p => p.GetAvailableByProblematicIdAndDate(It.IsAny<int>(), It.IsAny<DateTime>())).Returns(psychologist);
            ConsultationLogic consultationLogic = new ConsultationLogic(mock.Object, psychologistMock.Object);

            Consultation returnedConsultation = consultationLogic.Add(consultationModel);

            mock.VerifyAll();
            Assert.AreEqual(psychologist.Id, returnedConsultation.Psychologist.Id);
            Assert.AreEqual(psychologist.Name, returnedConsultation.Psychologist.Name);
            Assert.AreEqual(psychologist.Direction, returnedConsultation.Psychologist.Direction);
            Assert.IsFalse(returnedConsultation.Psychologist.Direction.Contains("https://bettercalm.com.uy/meeting_id/"));
            Assert.AreEqual(psychologist.ConsultationMode, returnedConsultation.Psychologist.ConsultationMode);
        }

        [TestMethod]
        public void TestAddConsultationVirtualCheckLink()
        {
            int problematicId = 1;
            Consultation consultationModel = new Consultation
            {
                ProblematicId = problematicId,
                Pacient = new Pacient
                {
                    Name = "Juan",
                    Surname = "Perez",
                    BirthDate = new DateTime(1996, 12, 05),
                    Email = "Juan@gmail.com",
                    Cellphone = "098342972"
                }
            };
            Psychologist psychologist = new Psychologist
            {
                Name = "Juan",
                Direction = "Rio negro",
                ConsultationMode = "Virtual",
                CreationDate = new DateTime(2021, 4, 20),
                Problematics = new List<PsychologistProblematic>
                {
                    new PsychologistProblematic
                    {
                        ProblematicId = problematicId,
                    },
                    new PsychologistProblematic
                    {
                        ProblematicId = 2,
                    },
                    new PsychologistProblematic
                    {
                        ProblematicId = 3,
                    },
                    new PsychologistProblematic
                    {
                        ProblematicId = 4,
                    }
                }
            };
            Consultation consultationToReturn = new Consultation
            {
                ProblematicId = problematicId,
                Pacient = new Pacient
                {
                    Name = "Juan",
                    Surname = "Perez",
                    BirthDate = new DateTime(1996, 12, 05),
                    Email = "Juan@gmail.com",
                    Cellphone = "098342972"
                },
                Psychologist = psychologist,
            };
            Mock<IRepository<Consultation>> mock = new Mock<IRepository<Consultation>>(MockBehavior.Strict);
            mock.Setup(p => p.Add(It.IsAny<Consultation>())).Returns(consultationToReturn);
            Mock<IPsychologistLogic> psychologistMock = new Mock<IPsychologistLogic>(MockBehavior.Strict);
            psychologistMock.Setup(p => p.GetAvailableByProblematicIdAndDate(It.IsAny<int>(), It.IsAny<DateTime>())).Returns(psychologist);
            ConsultationLogic consultationLogic = new ConsultationLogic(mock.Object, psychologistMock.Object);

            Consultation returnedConsultation = consultationLogic.Add(consultationModel);

            mock.VerifyAll();
            Assert.AreEqual(psychologist.Id, returnedConsultation.Psychologist.Id);
            Assert.AreEqual(psychologist.Name, returnedConsultation.Psychologist.Name);
            Assert.IsTrue(returnedConsultation.Psychologist.Direction.Contains("https://bettercalm.com.uy/meeting_id/"));
        }

        [TestMethod]
        public void TestAddConsultationVirtualOk()
        {
            int problematicId = 1;
            Consultation consultationModel = new Consultation
            {
                ProblematicId = problematicId,
                Pacient = new Pacient
                {
                    Name = "Juan",
                    Surname = "Perez",
                    BirthDate = new DateTime(1996, 12, 05),
                    Email = "Juan@gmail.com",
                    Cellphone = "098342972"
                }
            };
            Psychologist psychologist = new Psychologist
            {
                Name = "Juan",
                Direction = "Rio negro",
                ConsultationMode = "Presencial",
                CreationDate = new DateTime(2021, 4, 20),
                Problematics = new List<PsychologistProblematic>
                {
                    new PsychologistProblematic
                    {
                        ProblematicId = problematicId,
                    },
                    new PsychologistProblematic
                    {
                        ProblematicId = 2,
                    },
                    new PsychologistProblematic
                    {
                        ProblematicId = 3,
                    },
                    new PsychologistProblematic
                    {
                        ProblematicId = 4,
                    }
                }
            };
            Consultation consultationToReturn = new Consultation
            {
                ProblematicId = problematicId,
                Pacient = new Pacient
                {
                    Name = "Juan",
                    Surname = "Perez",
                    BirthDate = new DateTime(1996, 12, 05),
                    Email = "Juan@gmail.com",
                    Cellphone = "098342972"
                },
                Psychologist = psychologist,
            };
            Mock<IRepository<Consultation>> mock = new Mock<IRepository<Consultation>>(MockBehavior.Strict);
            mock.Setup(p => p.Add(It.IsAny<Consultation>())).Returns(consultationToReturn);
            Mock<IPsychologistLogic> psychologistMock = new Mock<IPsychologistLogic>(MockBehavior.Strict);
            psychologistMock.Setup(p => p.GetAvailableByProblematicIdAndDate(It.IsAny<int>(), It.IsAny<DateTime>())).Returns(psychologist);
            ConsultationLogic consultationLogic = new ConsultationLogic(mock.Object, psychologistMock.Object);

            Consultation returnedConsultation = consultationLogic.Add(consultationModel);

            mock.VerifyAll();
            Assert.AreEqual(psychologist.Id, returnedConsultation.Psychologist.Id);
            Assert.AreEqual(psychologist.Name, returnedConsultation.Psychologist.Name);
            Assert.AreEqual(psychologist.ConsultationMode, returnedConsultation.Psychologist.ConsultationMode);
        }

        [TestMethod]
        [ExpectedException(typeof(NullObjectException))]
        public void TestAddConsultationNoPsychologistExistant()
        {
            int problematicId = 1;
            Consultation consultationModel = new Consultation
            {
                ProblematicId = problematicId,
                Pacient = new Pacient
                {
                    Name = "Juan",
                    Surname = "Perez",
                    BirthDate = new DateTime(1996, 12, 05),
                    Email = "Juan@gmail.com",
                    Cellphone = "098342972"
                }
            };
            Psychologist psychologist = new Psychologist
            {
                Name = "Juan",
                Direction = "Rio negro",
                ConsultationMode = "Presencial",
                CreationDate = new DateTime(2021, 4, 20),
                Problematics = new List<PsychologistProblematic>
                {
                    new PsychologistProblematic
                    {
                        ProblematicId = problematicId,
                    },
                    new PsychologistProblematic
                    {
                        ProblematicId = 2,
                    },
                    new PsychologistProblematic
                    {
                        ProblematicId = 3,
                    },
                    new PsychologistProblematic
                    {
                        ProblematicId = 4,
                    }
                }
            };
            Consultation consultationToReturn = new Consultation
            {
                ProblematicId = problematicId,
                Pacient = new Pacient
                {
                    Name = "Juan",
                    Surname = "Perez",
                    BirthDate = new DateTime(1996, 12, 05),
                    Email = "Juan@gmail.com",
                    Cellphone = "098342972"
                },
                Psychologist = psychologist,
            };
            Mock<IRepository<Consultation>> mock = new Mock<IRepository<Consultation>>(MockBehavior.Strict);
            mock.Setup(p => p.Add(It.IsAny<Consultation>())).Returns(consultationToReturn);
            Mock<IPsychologistLogic> psychologistMock = new Mock<IPsychologistLogic>(MockBehavior.Strict);
            psychologistMock.Setup(p => p.GetAvailableByProblematicIdAndDate(It.IsAny<int>(), It.IsAny<DateTime>())).Throws(new NullObjectException("There is no psychologist"));
            ConsultationLogic consultationLogic = new ConsultationLogic(mock.Object, psychologistMock.Object);

            Consultation returnedConsultation = consultationLogic.Add(consultationModel);

            mock.VerifyAll();
            Assert.AreEqual(psychologist.Id, returnedConsultation.Psychologist.Id);
            Assert.AreEqual(psychologist.Name, returnedConsultation.Psychologist.Name);
            Assert.AreEqual(psychologist.Direction, returnedConsultation.Psychologist.Direction);
            Assert.AreEqual(psychologist.ConsultationMode, returnedConsultation.Psychologist.ConsultationMode);
        }
    }
}
