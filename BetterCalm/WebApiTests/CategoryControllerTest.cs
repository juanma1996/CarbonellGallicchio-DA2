﻿using BetterCalm.WebApi.Controllers;
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
            List<Category> categoriesToReturn = new List<Category>()
            {
                new Category
                {
                    Id = 1,
                    Name = "Top 50 Uruguay"
                },
                new Category
                {
                    Id = 2,
                    Name = "Top 50 Usa"
                }
            };
            Mock<ICategoryLogic> mock = new Mock<ICategoryLogic>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll()).Returns(categoriesToReturn);
            ApiMapper mapper = new ApiMapper();
            CategoryController controller = new CategoryController(mock.Object, mapper);


            var result = controller.Get();
            var okResult = result as OkObjectResult;
            var categories = okResult.Value as List<CategoryBasicInfoModel>;
            var categoriesToReturnModel = mapper.Configure().Map<List<CategoryBasicInfoModel>>(categoriesToReturn);

            mock.VerifyAll();
            Assert.IsTrue(categories.SequenceEqual(categoriesToReturnModel));
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
            ApiMapper mapper = new ApiMapper();
            CategoryController controller = new CategoryController(mock.Object, mapper);

            var result = controller.GetPlaylistByCategory(1);
            var okResult = result as OkObjectResult;
            var ResultPlaylists = okResult.Value as List<PlaylistBasicInfoModel>;

            Assert.AreEqual(ResultPlaylists.Count, 2);
        }

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