using System;
using System.Collections.Generic;
using BusinessLogic;
using BusinessLogicInterface;
using DataAccessInterface;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Out;
using Moq;

namespace BetterCalmTests.BusinessLogic
{
    [TestClass]
    public class CategoryLogicTest
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

            mock.VerifyAll();
        }
    }
}
