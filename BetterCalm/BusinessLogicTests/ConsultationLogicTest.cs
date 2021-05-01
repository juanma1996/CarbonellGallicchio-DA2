using System;
using System.Collections.Generic;
using BusinessLogic;
using DataAccessInterface;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BusinessLogicTests
{
    public class ConsultationLogicTest
    {
        [TestMethod]
        public void TestAddConsultationOk()
        {
            var problematicId = 1;

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
            //Add pacient to repository.
            Mock<IRepository<Consultation>> mock = new Mock<IRepository<Consultation>>(MockBehavior.Strict);
            mock.Setup(p => p.Add(It.IsAny<Consultation>())).Returns(consultationToReturn);
            ConsultationLogic consultationLogic = new ConsultationLogic(mock.Object);

            Psychologist returnedPsychologist = consultationLogic.Add(consultationModel);

            mock.VerifyAll();
            Assert.AreEqual(psychologist.Id, returnedPsychologist.Id);
            Assert.AreEqual(psychologist.Name, returnedPsychologist.Name);
            Assert.AreEqual(psychologist.Direction, returnedPsychologist.Direction);
            Assert.AreEqual(psychologist.ConsultationMode, returnedPsychologist.ConsultationMode);
        }
    }
}
