using BusinessLogic;
using DataAccessInterface;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace BusinessLogicTests
{
    [TestClass]
    public class AgendaLogicTest
    {
        [TestMethod]
        public void TestGetAgendaByPsychologistIdAndDate()
        {
            int psychologistId = 1;
            DateTime date = DateTime.Now;
            Agenda agendaToReturn = new Agenda
            {
                Id = 1,
                Psychologist = new Psychologist()
                {
                    Id = psychologistId
                },
                Date = date,
                Count = 0,
                IsAvaible = true,
            };
            Mock<IRepository<Agenda>> mock = new Mock<IRepository<Agenda>>(MockBehavior.Strict);
            mock.Setup(m => m.Get(a => a.Psychologist.Id == psychologistId && a.Date.Date == date.Date)).Returns(agendaToReturn);
            AgendaLogic agendaLogic = new AgendaLogic(mock.Object);

            Agenda result = agendaLogic.GetAgendaByPsychologistIdAndDate(psychologistId, date);

            mock.VerifyAll();
            Assert.AreEqual(agendaToReturn.Id, result.Id);
            Assert.AreEqual(agendaToReturn.Psychologist.Id, result.Psychologist.Id);
            Assert.AreEqual(agendaToReturn.Date, result.Date);
        }

        [TestMethod]
        public void TestCreateAgendaByPsychologistIdAndDate()
        {
            int psychologistId = 1;
            DateTime date = DateTime.Now;
            Psychologist psychologist = new Psychologist()
            {
                Id = psychologistId
            };
            Agenda agendaToReturn = new Agenda
            {
                Id = 1,
                Psychologist = psychologist,
                Date = date,
                Count = 0,
                IsAvaible = true,
            };
            Mock<IRepository<Agenda>> mock = new Mock<IRepository<Agenda>>(MockBehavior.Strict);
            mock.Setup(m => m.Add(It.IsAny<Agenda>())).Returns(agendaToReturn);
            AgendaLogic agendaLogic = new AgendaLogic(mock.Object);

            Agenda result = agendaLogic.Add(psychologist, date);

            mock.VerifyAll();
            Assert.AreEqual(agendaToReturn.Id, result.Id);
            Assert.AreEqual(agendaToReturn.Psychologist.Id, result.Psychologist.Id);
            Assert.AreEqual(agendaToReturn.Date, result.Date);
        }

        [TestMethod]
        public void TestAssingAgendaOk()
        {
            int psychologistId = 1;
            DateTime date = DateTime.Now;
            Agenda agendaToReturn = new Agenda
            {
                Id = 1,
                Psychologist = new Psychologist()
                {
                    Id = psychologistId
                },
                Date = date,
                Count = 0,
                IsAvaible = true,
            };
            Agenda agenda = new Agenda
            {
                Id = 1,
                Psychologist = new Psychologist()
                {
                    Id = psychologistId
                },
                Date = date,
                Count = 1,
                IsAvaible = true,
            };
            Mock<IRepository<Agenda>> mock = new Mock<IRepository<Agenda>>(MockBehavior.Strict);
            AgendaLogic agendaLogic = new AgendaLogic(mock.Object);

            Agenda result = agendaLogic.Assign(agendaToReturn);

            mock.VerifyAll();
            Assert.AreEqual(agenda.Id, result.Id);
            Assert.AreEqual(agenda.Psychologist.Id, result.Psychologist.Id);
            Assert.AreEqual(agenda.Date, result.Date);
            Assert.AreEqual(agenda.Count, result.Count);
        }

        [TestMethod]
        public void TestAssingAgendaWithCountFourShouldNotBeAvaible()
        {
            int psychologistId = 1;
            DateTime date = DateTime.Now;
            Agenda agendaToReturn = new Agenda
            {
                Id = 1,
                Psychologist = new Psychologist()
                {
                    Id = psychologistId
                },
                Date = date,
                Count = 4,
                IsAvaible = true,
            };
            Agenda agenda = new Agenda
            {
                Id = 1,
                Psychologist = new Psychologist()
                {
                    Id = psychologistId
                },
                Date = date,
                Count = 5,
                IsAvaible = false,
            };
            Mock<IRepository<Agenda>> mock = new Mock<IRepository<Agenda>>(MockBehavior.Strict);
            AgendaLogic agendaLogic = new AgendaLogic(mock.Object);

            Agenda result = agendaLogic.Assign(agendaToReturn);

            mock.VerifyAll();
            Assert.AreEqual(agenda.Id, result.Id);
            Assert.AreEqual(agenda.Psychologist.Id, result.Psychologist.Id);
            Assert.AreEqual(agenda.Date, result.Date);
            Assert.AreEqual(agenda.Count, result.Count);
            Assert.IsFalse(result.IsAvaible);
        }
    }
}
