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

            psychologistRepository.Add(psycologistModel);
            var result = psychologistRepository.GetById(psychologistId);

            Assert.AreEqual(psychologistId, result.Id);
            Assert.AreEqual(psycologistModel.Name, result.Name);
            Assert.AreEqual(psycologistModel.ConsultationMode, result.ConsultationMode);
            Assert.AreEqual(psycologistModel.CreationDate, result.CreationDate);
        }
    
    }
}
