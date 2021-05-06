using BetterCalm.WebApi.Controllers;
using AdapterInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Out;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace WebApiTests
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
            OkObjectResult okResult = result as OkObjectResult;
            List<CategoryBasicInfoModel> categories = okResult.Value as List<CategoryBasicInfoModel>;

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
            OkObjectResult okResult = result as OkObjectResult;
            List<PlaylistBasicInfoModel> ResultPlaylists = okResult.Value as List<PlaylistBasicInfoModel>;

            mock.VerifyAll();
            Assert.AreEqual(ResultPlaylists.Count, 2);
        }
        
        [TestMethod]
        public void TestGetPlaylistByCategoryNotExistentId()
        {
            List<PlaylistBasicInfoModel> playlists = new List<PlaylistBasicInfoModel>();
            int id = 1;
            Mock<ICategoryLogicAdapter> mock = new Mock<ICategoryLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.GetPlaylistsByCategoryId(id)).Returns(playlists);
            CategoryController controller = new CategoryController(mock.Object);

            var result = controller.GetPlaylistByCategory(id);
            ObjectResult objectResult = result as ObjectResult;

            mock.VerifyAll();
            Assert.AreEqual(0, playlists.Count);
        }

        [TestMethod]
        public void TestGetAllCategoriesCheckAudioContentListOk()
        {
            int audioContentId = 1;
            string nameAudioContent = "Audio content name";
            List<CategoryBasicInfoModel> categoriesToReturn = new List<CategoryBasicInfoModel>()
            {
                new CategoryBasicInfoModel
                {
                    Id = 1,
                    Name = "Top 50 Uruguay",
                    AudioContents = new List<AudioContentBasicInfoModel>
                    {
                        new AudioContentBasicInfoModel()
                        {
                            Id = audioContentId,
                            Name = nameAudioContent
                        }
                    }
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
            OkObjectResult okResult = result as OkObjectResult;
            List<CategoryBasicInfoModel> categories = okResult.Value as List<CategoryBasicInfoModel>;

            mock.VerifyAll();
            Assert.AreEqual(audioContentId, categories.First().AudioContents.First().Id);
            Assert.AreEqual(nameAudioContent, categories.First().AudioContents.First().Name);
            Assert.AreEqual(200, okResult.StatusCode);
        }
    }
}