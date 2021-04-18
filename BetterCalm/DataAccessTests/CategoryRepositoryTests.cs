﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Common;
using DataAccess.Context;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Domain;
using System.Linq;

namespace DataAccess.Tests
{
    [TestClass()]
    public class CategoryRepositoryTests
    {
        private DbConnection connection;
        private BetterCalmContext context;

        public CategoryRepositoryTests()
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

        [TestMethod()]
        public void TestGetAllCategories()
        {
            List<Playlist> playlists = new List<Playlist>()
            {
                new Playlist()
                {
                    Id = 1
                }
            };
            List<Category> categoriesToReturn = new List<Category>()
            {
                new Category
                {
                    Id = 1,
                    Playlists = playlists
                }
            };
            categoriesToReturn.ForEach(c => context.Add(c));
            context.SaveChanges();

            CategoryRepository categoryRepository = new CategoryRepository(context);
            var result = categoryRepository.GetAll();

            Assert.IsTrue(categoriesToReturn.SequenceEqual(result));
        }
    }
}