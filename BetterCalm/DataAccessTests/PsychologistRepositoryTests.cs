using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
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
            Problematic problematic = new Problematic
            {
                Id = 9,
                Name = "Depresion",
            };
            this.context.Add(problematic);
            this.context.SaveChanges();
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
                        ProblematicId = 9,
                    }
                }
            };
            IRepository<Psychologist> psychologistRepository = new Repository<Psychologist>(context);

            psychologistRepository.Add(psycologistModel);
            Psychologist psychologist = psychologistRepository.GetById(psychologistId);

            Assert.AreEqual(psychologistId, psychologist.Id);
            Assert.AreEqual(psycologistModel.Name, psychologist.Name);
            Assert.AreEqual(psycologistModel.ConsultationMode, psychologist.ConsultationMode);
            Assert.AreEqual(psycologistModel.CreationDate, psychologist.CreationDate);
            Assert.AreEqual(psycologistModel.Problematics.First().ProblematicId, psychologist.Problematics.First().ProblematicId);
        }

        [TestMethod]
        public void TestUpdatePsychologistOk()
        {
            int psychologistId = 1;
            Problematic problematic = new Problematic
            {
                Id = 9,
                Name = "Depresion",
            };
            context.Add(problematic);
            context.SaveChanges();
            Psychologist psycologistModel = new Psychologist
            {
                Id = psychologistId,
                Name = "Juan",
                Direction = "Rio negro",
                ConsultationMode = "Presencial",
                CreationDate = new DateTime(2021, 4, 20),
                Problematics = new List<PsychologistProblematic>
                {
                    new PsychologistProblematic
                    {
                        ProblematicId = 9,
                    }
                }
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
                Problematics = new List<PsychologistProblematic>
                {
                    new PsychologistProblematic
                    {
                        ProblematicId = 9,
                    }
                }
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
            Assert.AreEqual(psycologistUpdated.Problematics.First().ProblematicId, psychologist.Problematics.First().ProblematicId);
        }

        [TestMethod]
        public void TestDeletePsychologistOk()
        {
            Psychologist psycologistModel = new Psychologist
            {
                Name = "Juan",
                Direction = "Rio negro",
                ConsultationMode = "Presencial",
                CreationDate = new DateTime(2021, 4, 20),
            };
            context.Add(psycologistModel);
            context.SaveChanges();
            Psychologist psycologistToDelete = new Psychologist
            {
                Id = 1,
                Name = "Juan",
                Direction = "Rio negro",
                ConsultationMode = "Presencial",
                CreationDate = new DateTime(2021, 4, 20),
            };
            BetterCalmContext newContext = new BetterCalmContext(
                        new DbContextOptionsBuilder<BetterCalmContext>()
                        .UseSqlite(connection)
                        .Options);
            IRepository<Psychologist> psychologistRepository = new Repository<Psychologist>(newContext);
            psychologistRepository.Delete(psycologistToDelete);

            Assert.AreEqual(0, psychologistRepository.GetAll().Count);
        }

        [TestMethod]
        public void TestExistsPsychologistOk()
        {
            int psychologistId = 1;
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
            IRepository<Psychologist> psychologistRepository = new Repository<Psychologist>(context);

            bool result = psychologistRepository.Exists(p => p.Id == psychologistId);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestExistsPsychologistNotFound()
        {
            int psychologistId = 1;
            IRepository<Psychologist> psychologistRepository = new Repository<Psychologist>(context);

            bool result = psychologistRepository.Exists(p => p.Id == psychologistId);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestGetAvailableByProblematicIdTwoOptions()
        {
            int problematicId = 9;
            Problematic problematic = new Problematic
            {
                Id = problematicId,
                Name = "Depresion",
            };
            context.Add(problematic);
            context.SaveChanges();
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
            context.Add(antiquePsychologist);
            context.SaveChanges();
            Psychologist newerPsychologist = new Psychologist
            {
                Id = 2,
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
            context.Add(newerPsychologist);
            context.SaveChanges();
            IRepository<PsychologistProblematic> psychologistRepository = new Repository<PsychologistProblematic>(context);

            Psychologist psychologist = psychologistRepository.GetAll(p => p.ProblematicId == problematicId).OrderBy(p => p.Psychologist.CreationDate).First().Psychologist;

            Assert.AreEqual(antiquePsychologist.Id, psychologist.Id);
            Assert.AreEqual(antiquePsychologist.Name, psychologist.Name);
            Assert.AreEqual(antiquePsychologist.Direction, psychologist.Direction);
            Assert.AreEqual(antiquePsychologist.ConsultationMode, psychologist.ConsultationMode);
            Assert.AreEqual(antiquePsychologist.CreationDate, psychologist.CreationDate);
            Assert.IsTrue(psychologist.Problematics.Exists(p => p.ProblematicId == problematicId));
        }
    }
}
