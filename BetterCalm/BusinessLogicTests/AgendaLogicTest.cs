using BusinessLogic;
using DataAccessInterface;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

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
            mock.Setup(m => m.Get(a => a.Psychologist.Id == psychologistId && a.Date == date)).Returns(agendaToReturn);
            AgendaLogic agendaLogic = new AgendaLogic(mock.Object);

            Agenda result = agendaLogic.GetAgendaByPsychologistIdAndDate(psychologistId, date);

            mock.VerifyAll();
            Assert.AreEqual(agendaToReturn.Id, result.Id);
            Assert.AreEqual(agendaToReturn.Psychologist.Id, result.Psychologist.Id);
            Assert.AreEqual(agendaToReturn.Date, result.Date);
        }
    }
}
