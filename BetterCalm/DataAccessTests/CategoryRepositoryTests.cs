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
            int categoryId = 9;
            int playlistId = 1;
            string categoryName = "Category name";
            List<Category> categoriesToReturn = new List<Category>()
            {
                new Category
                {
                    Id = categoryId,
                    Name= categoryName
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

            Assert.IsTrue(result.Count > 0);
        }


        [TestMethod()]
        public void TestGetPlaylistByCategoryOk()
        {
            int categoryId = 9;
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
            int categoryId = 9;
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