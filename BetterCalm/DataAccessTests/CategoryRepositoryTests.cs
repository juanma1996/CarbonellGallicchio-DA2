using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Common;
using DataAccess.Context;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Domain;
using System.Linq;
using DataAccessInterface;
using DataAccess.Repositories;

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
            int categoryId = 1;
            int playlistId = 1;
            List<Category> categoriesToReturn = new List<Category>()
            {
                new Category
                {
                    Id = categoryId,
                    Name= "Chilling"
                }
            };
            categoriesToReturn.ForEach(c => context.Add(c));
            context.SaveChanges();
            List<Playlist> playlistsToReturn = new List<Playlist>()
            {
                new Playlist()
                {
                    Id = playlistId,
                    Name = "One playlist",
                    Description = "One description",
                    Categories =  new List<CategoryPlaylist>()
                    {
                        new CategoryPlaylist
                        {
                            CategoryId = categoryId
                        }
                    }
                }
            };
            playlistsToReturn.ForEach(c => context.Add(c));
            context.SaveChanges();


            IRepository<Category> categoryRepository = new Repository<Category>(context);
            var result = categoryRepository.GetAll();

            Assert.AreEqual(result.First().Id, categoriesToReturn.First().Id);
            Assert.AreEqual(result.First().Name, categoriesToReturn.First().Name);
            Assert.AreEqual(result.First().Playlists.First().Playlist.Id, categoriesToReturn.First().Playlists.First().Playlist.Id);
        }


        [TestMethod()]
        public void TestGetPlaylistByCategoryOk()
        {
            int categoryId = 1;
            List<Category> category = new List<Category>()
            {
                new Category
                {
                    Id = categoryId
                }
            };
            category.ForEach(c => context.Add(c));
            context.SaveChanges();
            List<Playlist> playlistsToReturn = new List<Playlist>()
            {
                new Playlist()
                {
                    Name = "One playlist",
                    Description = "One description",
                    Categories =  new List<CategoryPlaylist>()
                    {
                        new CategoryPlaylist
                        {
                            CategoryId = categoryId
                        }
                    }
                },
                new Playlist()
                {
                    Name = "Other playlist",
                    Description = "Other description",
                    Categories =  new List<CategoryPlaylist>()
                    {
                        new CategoryPlaylist
                        {
                            CategoryId = categoryId
                        }
                    }
                }
            };
            playlistsToReturn.ForEach(c => context.Add(c));
            context.SaveChanges();

            IRepository<Playlist> playlistRepository = new Repository<Playlist>(context);
            var result = playlistRepository.GetAll(playlist => playlist.Categories.Any(playlistCategory => playlistCategory.CategoryId == categoryId));

            Assert.IsTrue(playlistsToReturn.SequenceEqual(result));
        }

        [TestMethod()]
        public void TestGetPlaylistByNotExistantCategoryShouldReturnEmpty()
        {
            int categoryId = 1;
            int notExistentCategoryId = 2;
            List<Category> category = new List<Category>()
            {
                new Category
                {
                    Id = categoryId
                }
            };
            category.ForEach(c => context.Add(c));
            context.SaveChanges();
            List<Playlist> playlistsToReturn = new List<Playlist>()
            {
                new Playlist()
                {
                    Name = "Other playlist",
                    Description = "Other description",
                    Categories =  new List<CategoryPlaylist>()
                    {
                        new CategoryPlaylist
                        {
                            CategoryId = categoryId
                        }
                    }
                },
                new Playlist()
                {
                    Name = "One playlist",
                    Description = "One description",
                    Categories =  new List<CategoryPlaylist>()
                    {
                        new CategoryPlaylist
                        {
                            CategoryId = categoryId
                        }
                    }
                }
            };
            playlistsToReturn.ForEach(c => context.Add(c));
            context.SaveChanges();

            IRepository<Playlist> playlistRepository = new Repository<Playlist>(context);
            var result = playlistRepository.GetAll(playlist => playlist.Categories.Any(playlistCategory => playlistCategory.CategoryId == notExistentCategoryId));

            Assert.IsTrue(result.Count == 0);
        }
    }
}