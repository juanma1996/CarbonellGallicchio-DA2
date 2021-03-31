using BetterCalm.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BetterCalmTests.WebApi
{
    [TestClass]
    public class CategoryControllerTest
    {
        [TestMethod]
        public void TestGetAllCategoriesOk()
        {
            var controller = new CategoryController();

            var result = controller.Get();
            var okResult = result as OkObjectResult;
            var categories = okResult.Value as List<Category>;

            Assert.AreEqual(categories.Count,1);
        }
    }
}