using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Domain;
using DataAccessInterface;
using Moq;
using System;
using BusinessLogic.Mapper;
using Model.Out;

namespace BusinessLogic.Tests
{
    [TestClass()]
    public class CategoryLogicTests
    {
        [TestMethod]
        public void TestGetAllCategories()
        {
            List<Playlist> playlists = new List<Playlist>()
            {
                new Playlist()
                {
                    Id = 1
                }
            };
            List<Category> categoryToReturn = new List<Category>()
            {
                new Category
                {
                    Id = 1,
                    Playlists = playlists
                }
            };
            Mock<ICategoryRepository> mock = new Mock<ICategoryRepository>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll()).Returns(categoryToReturn);
            ModelMapper mapper = new ModelMapper();
            CategoryLogic categoryLogic = new CategoryLogic(mock.Object, mapper);

            List<CategoryBasicInfoModel> result = categoryLogic.GetAll();

            mock.VerifyAll();
            Assert.AreEqual(categoryToReturn.Count, result.Count);
        }

        [TestMethod]
        public void TestGetPlaylistByCategoryOk()
        {
            List<Playlist> playlists = new List<Playlist>()
            {
                new Playlist()
                {
                    Id = 1,
                },
                new Playlist()
                {
                    Id = 2,
                },
            };
            Mock<ICategoryRepository> mock = new Mock<ICategoryRepository>(MockBehavior.Strict);
            mock.Setup(m => m.GetPlaylistsBy(1)).Returns(playlists);
            ModelMapper mapper = new ModelMapper();
            CategoryLogic categoryLogic = new CategoryLogic(mock.Object, mapper);

            List<Playlist> result = categoryLogic.GetPlaylistsBy(1);

            mock.VerifyAll();
            Assert.AreEqual(result.Count, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestGetPlaylistByCategoryNotExistentId()
        {
            List<Playlist> playlists = new List<Playlist>();
            var id = 1;
            Mock<ICategoryRepository> mock = new Mock<ICategoryRepository>(MockBehavior.Strict);
            mock.Setup(m => m.GetPlaylistsBy(id)).Returns((List<Playlist>)null);
            ModelMapper mapper = new ModelMapper();
            CategoryLogic categoryLogic = new CategoryLogic(mock.Object, mapper);

            var result = categoryLogic.GetPlaylistsBy(1);

            mock.VerifyAll();
        }
    }
}