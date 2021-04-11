using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Domain;
using DataAccessInterface;
using Moq;

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
            CategoryLogic categoryLogic = new CategoryLogic(mock.Object);

            List<Category> result = categoryLogic.GetAll();

            mock.VerifyAll();
            Assert.AreEqual(categoryToReturn.Count, result.Count);
        }
    }
}