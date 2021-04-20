using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Domain;
using DataAccessInterface;
using Moq;
using System;
using BusinessExceptions;
using System.Linq;

namespace BusinessLogic.Tests
{
    [TestClass()]
    public class CategoryLogicTests
    {
        [TestMethod]
        public void TestGetAllCategories()
        {
            List<Category> categoryToReturn = new List<Category>()
            {
                new Category
                {
                    Id = 1
                }
            };
            Mock<IRepository<Category>> mock = new Mock<IRepository<Category>>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll(null)).Returns(categoryToReturn);
            Validation validate = new Validation();
            CategoryLogic categoryLogic = new CategoryLogic(mock.Object, null, validate);

            List<Category> result = categoryLogic.GetAll();

            mock.VerifyAll();
            Assert.AreEqual(categoryToReturn.Count, result.Count);
        }

        [TestMethod]
        public void TestGetPlaylistByCategoryOk()
        {
            int categoryId = 1;
            Category category = new Category
            {
                Id = categoryId

            };
            List<Playlist> playlists = new List<Playlist>()
            {
                new Playlist()
                {
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
                    Categories =  new List<CategoryPlaylist>()
                    {
                        new CategoryPlaylist
                        {
                            CategoryId = categoryId
                        }
                    }
                }
            };
            Mock<IRepository<Playlist>> mock = new Mock<IRepository<Playlist>>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll(playlist => playlist.Categories.Any(playlistCategory => playlistCategory.CategoryId == categoryId))).Returns(playlists);
            Validation validate = new Validation();
            CategoryLogic categoryLogic = new CategoryLogic(null, mock.Object, validate);

            List<Playlist> result = categoryLogic.GetPlaylistsByCategoryId(1);

            mock.VerifyAll();
            Assert.AreEqual(result.Count, 2);
        }
        [TestMethod]
        public void TestGetPlaylistByCategoryNotExistentId()
        {
            List<Playlist> playlists = new List<Playlist>();
            var categoryId = 2;
            Mock<IRepository<Playlist>> mock = new Mock<IRepository<Playlist>>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll(playlist => playlist.Categories.Any(playlistCategory => playlistCategory.CategoryId == categoryId))).Returns(new List<Playlist>());
            Validation validate = new Validation();
            CategoryLogic categoryLogic = new CategoryLogic(null, mock.Object, validate);

            var result = categoryLogic.GetPlaylistsByCategoryId(2);

            mock.VerifyAll();
            Assert.AreEqual(result.Count, 0);
        }
    }
}