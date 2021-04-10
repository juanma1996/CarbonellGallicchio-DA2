using BetterCalm.WebApi.Controllers;
using BusinessLogicInterface;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Out;
using Moq;
using System.Collections.Generic;
using System.Linq;
using WebApi.Mapper;

namespace BetterCalmTests.WebApi
{
    [TestClass]
    public class CategoryControllerTest
    {
        [TestMethod]
        public void TestGetAllCategoriesOk()
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
                },
                new Category
                {
                    Id = 2,
                    Playlists = playlists
                }
            };
            Mock<ICategoryLogic> mock = new Mock<ICategoryLogic>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll()).Returns(categoriesToReturn);
            ApiMapper mapper = new ApiMapper();
            CategoryController controller = new CategoryController(mock.Object, mapper);

            var result = controller.Get();
            var okResult = result as OkObjectResult;
            var categories = okResult.Value as List<CategoryBasicInfoModel>;

            mock.VerifyAll();
            Assert.AreEqual(categories.First().Id, categoriesToReturn.First().Id);
            Assert.AreEqual(categories.First().Playlists.First().Id, categoriesToReturn.First().Playlists.First().Id);
            Assert.AreEqual(200, okResult.StatusCode);
        }

        //[TestMethod]
        //public void TestGetPlaylistByCategoryOk()
        //{
        //    CategoryController controller = new CategoryController();

        //    var result = controller.GetPlaylistByCategory(1);
        //    var okResult = result as OkObjectResult;
        //    var playlists = okResult.Value as List<Playlist>;

        //    Assert.AreEqual(playlists.Count, 1);
        //}

        //[TestMethod]
        //public void TestGetPlaylistByCategoryNotExistentId()
        //{
        //    CategoryController controller = new CategoryController();

        //    var result = controller.GetPlaylistByCategory(2);

        //    var notFoundObjectResult = result as NotFoundObjectResult;

        //    Assert.AreEqual(notFoundObjectResult.Value, "Categoría inexistente");
        //}
    }
}