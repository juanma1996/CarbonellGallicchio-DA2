using System;
using System.Data.Common;
using DataAccess.Context;
using DataAccess.Repositories;
using DataAccessInterface;
using Domain;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataAccessTests
{
    [TestClass]
    public class PsychologistRepositoryTests
    {
        private DbConnection connection;
        private BetterCalmContext context;

        public PsychologistRepositoryTests()
        {
            this.connection = new SqliteConnection("Filename=:memory:");
            this.context = new BetterCalmContext(
                        new DbContextOptionsBuilder<BetterCalmContext>()
                        .UseSqlite(connection)
                        .Options);
        }

        [TestInitialize]
        public void Setup()
        {
            this.connection.Open();
            this.context.Database.EnsureCreated();
        }

        [TestCleanup]
        public void CleanUp()
        {
            this.context.Database.EnsureDeleted();
        }

        [TestMethod]
        public void TestAddPsychologistOk()
        {
            int psychologistId = 1;
            Psychologist psycologistModel = new Psychologist
            {
                Name = "Juan",
                Direction = "Rio negro",
                ConsultationMode = "Presencial",
                CreationDate = new DateTime(2021, 4, 20),
            };
            IRepository<Psychologist> psychologistRepository = new Repository<Psychologist>(context);

            var result = psychologistRepository.Add(psycologistModel);
            var psychologist = psychologistRepository.GetById(psychologistId);

            Assert.AreEqual(psychologistId, psychologist.Id);
            Assert.AreEqual(psycologistModel.Name, psychologist.Name);
            Assert.AreEqual(psycologistModel.ConsultationMode, psychologist.ConsultationMode);
            Assert.AreEqual(psycologistModel.CreationDate, psychologist.CreationDate);
        }

        [TestMethod]
        public void TestUpdatePsychologistOk()
        {
            var psychologistId = 1;
            Psychologist psycologistModel = new Psychologist
            {
                Id = psychologistId,
                Name = "Juan",
                Direction = "Rio negro",
                ConsultationMode = "Presencial",
                CreationDate = new DateTime(2021, 4, 20),
            };
            context.Add(psycologistModel);
            context.SaveChanges();

            Psychologist psycologistUpdated = new Psychologist
            {
                Id = psychologistId,
                Name = "Ricardo",
                Direction = "Rio negro",
                ConsultationMode = "Presencial",
                CreationDate = new DateTime(2021, 4, 20),
            };
            BetterCalmContext newContext = new BetterCalmContext(
                        new DbContextOptionsBuilder<BetterCalmContext>()
                        .UseSqlite(connection)
                        .Options);
            IRepository<Psychologist> psychologistRepository = new Repository<Psychologist>(newContext);

            psychologistRepository.Update(psycologistUpdated);
            Psychologist psychologist = psychologistRepository.GetById(psychologistId);

            Assert.AreEqual(psychologistId, psychologist.Id);
            Assert.AreEqual(psycologistUpdated.Name, psychologist.Name);
            Assert.AreEqual(psycologistUpdated.ConsultationMode, psychologist.ConsultationMode);
            Assert.AreEqual(psycologistUpdated.CreationDate, psychologist.CreationDate);
        }

    }
}
