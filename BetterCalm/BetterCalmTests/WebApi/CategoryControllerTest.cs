using BetterCalm.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace BetterCalmTests.WebApi
{
    [TestClass]
    public class CategoryControllerTest
    {
        [TestMethod]
        public void TestGetAllCategoriesOk()
        {
            CategoryController controller = new CategoryController();

            var result = controller.Get();
            var okResult = result as OkObjectResult;
            var categories = okResult.Value as List<Category>;

            Assert.AreEqual(categories.Count, 1);
        }

        [TestMethod]
        public void TestGetPlaylistByCategoryOk()
        {
            CategoryController controller = new CategoryController();

            var result = controller.GetPlaylistByCategory(1);
            var okResult = result as OkObjectResult;
            var playlists = okResult.Value as List<Playlist>;

            Assert.AreEqual(playlists.Count, 1);
        }

        [TestMethod]
        public void TestGetPlaylistByCategoryNotExistentId()
        {
            CategoryController controller = new CategoryController();

            var result = controller.GetPlaylistByCategory(2);

            var notFoundObjectResult = result as NotFoundObjectResult;

            Assert.AreEqual(notFoundObjectResult.Value, "Categoría inexistente");
        }
    }
}