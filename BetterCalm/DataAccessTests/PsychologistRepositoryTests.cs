﻿using System;
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
                Id = 1,
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
                        ProblematicId = 1,
                    }
                }
            };
            IRepository<Psychologist> psychologistRepository = new Repository<Psychologist>(context);

            var result = psychologistRepository.Add(psycologistModel);
            var psychologist = psychologistRepository.GetById(psychologistId);

            Assert.AreEqual(psychologistId, psychologist.Id);
            Assert.AreEqual(psycologistModel.Name, psychologist.Name);
            Assert.AreEqual(psycologistModel.ConsultationMode, psychologist.ConsultationMode);
            Assert.AreEqual(psycologistModel.CreationDate, psychologist.CreationDate);
            Assert.AreEqual(psycologistModel.Problematics.First().ProblematicId, psychologist.Problematics.First().ProblematicId);
        }

        [TestMethod]
        public void TestUpdatePsychologistOk()
        {
            var psychologistId = 1;
            Problematic problematic = new Problematic
            {
                Id = 1,
                Name = "Depresion",
            };
            this.context.Add(problematic);
            this.context.SaveChanges();
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
                        ProblematicId = 1,
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
                        ProblematicId = 1,
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
            IRepository<Psychologist> psychologistRepository = new Repository<Psychologist>(context);

            Boolean result = psychologistRepository.Exists(p => p.Id == psychologistId);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestExistsPsychologistNotFound()
        {
            var psychologistId = 1;
            IRepository<Psychologist> psychologistRepository = new Repository<Psychologist>(context);

            Boolean result = psychologistRepository.Exists(p => p.Id == psychologistId);
            Assert.IsFalse(result);
        }
    }
}