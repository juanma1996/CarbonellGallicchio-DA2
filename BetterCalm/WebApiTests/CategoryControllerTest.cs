using BetterCalm.WebApi.Controllers;
using BusinessLogicInterface;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Out;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BetterCalmTests.WebApi
{
    [TestClass]
    public class CategoryControllerTest
    {
        [TestMethod]
        public void TestGetAllCategoriesOk()
        {
            List<CategoryBasicInfoModel> categoriesToReturn = new List<CategoryBasicInfoModel>()
            {
                new CategoryBasicInfoModel
                {
                    Id = 1,
                    Name = "Top 50 Uruguay"
                },
                new CategoryBasicInfoModel
                {
                    Id = 2,
                    Name = "Top 50 Usa"
                }
            };
            Mock<ICategoryLogic> mock = new Mock<ICategoryLogic>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll()).Returns(categoriesToReturn);
            CategoryController controller = new CategoryController(mock.Object);

            var result = controller.Get();
            var okResult = result as OkObjectResult;
            var categories = okResult.Value as List<CategoryBasicInfoModel>;
            
            mock.VerifyAll();
            Assert.IsTrue(categories.SequenceEqual(categoriesToReturn));
            Assert.AreEqual(200, okResult.StatusCode);
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
            Mock<ICategoryLogic> mock = new Mock<ICategoryLogic>(MockBehavior.Strict);
            mock.Setup(m => m.GetPlaylistsBy(1)).Returns(playlists);
            CategoryController controller = new CategoryController(mock.Object);

            var result = controller.GetPlaylistByCategory(1);
            var okResult = result as OkObjectResult;
            var ResultPlaylists = okResult.Value as List<PlaylistBasicInfoModel>;

            mock.VerifyAll();
            Assert.AreEqual(ResultPlaylists.Count, 2);
        }

        [TestMethod]
        public void TestGetPlaylistByCategoryNotExistentId()
        {
            List<Playlist> playlists = new List<Playlist>();
            var id = 1;
            Mock<ICategoryLogic> mock = new Mock<ICategoryLogic>(MockBehavior.Strict);
            mock.Setup(m => m.GetPlaylistsBy(id)).Throws(new NullReferenceException("Not found object"));
            CategoryController controller = new CategoryController(mock.Object);

            var result = controller.GetPlaylistByCategory(id);
            var objectResult = result as ObjectResult;

            mock.VerifyAll();
            Assert.AreEqual(404, objectResult.StatusCode);
        }
    }
}