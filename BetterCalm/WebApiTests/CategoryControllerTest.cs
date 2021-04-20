using BetterCalm.WebApi.Controllers;
using AdapterInterface;
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
            Mock<ICategoryLogicAdapter> mock = new Mock<ICategoryLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll()).Returns(categoriesToReturn);
            CategoryController controller = new CategoryController(mock.Object);

            var result = controller.Get();
            var okResult = result as OkObjectResult;
            var categories = okResult.Value as List<CategoryBasicInfoModel>;
            
            mock.VerifyAll();
            Assert.AreEqual(categories.First().Id, categoriesToReturn.First().Id);
            Assert.AreEqual(categories.First().Name, categoriesToReturn.First().Name);
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [TestMethod]
        public void TestGetPlaylistByCategoryOk()
        {
            List<PlaylistBasicInfoModel> playlists = new List<PlaylistBasicInfoModel>()
            {
                new PlaylistBasicInfoModel()
                {
                    Id = 1,
                },
                new PlaylistBasicInfoModel()
                {
                    Id = 2,
                },
            };
            Mock<ICategoryLogicAdapter> mock = new Mock<ICategoryLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.GetPlaylistsByCategoryId(1)).Returns(playlists);
            CategoryController controller = new CategoryController(mock.Object);

            var result = controller.GetPlaylistByCategory(1);
            var okResult = result as OkObjectResult;
            var ResultPlaylists = okResult.Value as List<PlaylistBasicInfoModel>;

            mock.VerifyAll();
            Assert.AreEqual(ResultPlaylists.Count, 2);
        }
        //TODO: decide if we're going to throw an exception or a empty list of Playlist. Also, this case cannot ocurr.
        [Ignore]
        [TestMethod]
        public void TestGetPlaylistByCategoryNotExistentId()
        {
            List<PlaylistBasicInfoModel> playlists = new List<PlaylistBasicInfoModel>();
            var id = 1;
            Mock<ICategoryLogicAdapter> mock = new Mock<ICategoryLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.GetPlaylistsByCategoryId(id)).Throws(new NullReferenceException("Not found object"));
            CategoryController controller = new CategoryController(mock.Object);

            var result = controller.GetPlaylistByCategory(id);
            var objectResult = result as ObjectResult;

            mock.VerifyAll();
            Assert.AreEqual(404, objectResult.StatusCode);
        }
    }
}