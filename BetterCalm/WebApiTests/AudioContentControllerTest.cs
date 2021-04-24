using AdapterExceptions;
using AdapterInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.In;
using Model.Out;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Controllers;

namespace WebApiTests
{
    [TestClass]
    public class AudioContentControllerTest
    {
        [TestMethod]
        public void TestGetAudioContentOk()
        {
            int audioContentId = 1;
            AudioContentBasicInfoModel audioContentToReturn = new AudioContentBasicInfoModel()
            {
                Id = audioContentId,
                Name = "Canción",
                Duration = TimeSpan.MaxValue,
                CreatorName = "Juan",
                ImageUrl = "www.unaimagen.com",
                AudioUrl = "www.audio.com"
            };
            Mock<IAudioContentLogicAdapter> mock = new Mock<IAudioContentLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.GetById(audioContentId)).Returns(audioContentToReturn);
            AudioContentController controller = new AudioContentController(mock.Object);

            var result = controller.Get(audioContentId);
            var okResult = result as OkObjectResult;
            var audioContent = okResult.Value as AudioContentBasicInfoModel;

            Assert.AreEqual(audioContentToReturn.Id, audioContent.Id);
        }

        [TestMethod]
        public void TestPostAudioContentOk()
        {
            int audioContentId = 1;
            AudioContentModel audioContentModel = new AudioContentModel()
            {
                Name = "Canción",
                Duration = TimeSpan.MaxValue,
                CreatorName = "Juan",
                ImageUrl = "www.unaimagen.com",
                AudioUrl = "www.audio.com",
                Categories = new List<CategoryBasicInfoModel>()
                {
                    new CategoryBasicInfoModel
                    {
                        Id = 1
                    }
                },
                Playlists = new List<PlaylistBasicInfoModel>()
                {
                    new PlaylistBasicInfoModel
                    {
                        Id = 1
                    }
                },
            };
            AudioContentBasicInfoModel audioContentToReturn = new AudioContentBasicInfoModel()
            {
                Id = audioContentId
            };
            Mock<IAudioContentLogicAdapter> mock = new Mock<IAudioContentLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.Add(It.IsAny<AudioContentModel>())).Returns(audioContentToReturn);
            AudioContentController controller = new AudioContentController(mock.Object);

            var result = controller.Post(audioContentModel);
            var createdAtRouteResult = result as CreatedAtRouteResult;
            var audioContentBasicInfoModel = createdAtRouteResult.Value as AudioContentBasicInfoModel;

            mock.VerifyAll();
            Assert.AreEqual(audioContentId, audioContentBasicInfoModel.Id);
        }

        [TestMethod]
        public void TestDeleteAudioContentOk()
        {
            int audioContentId = 1;
            Mock<IAudioContentLogicAdapter> mock = new Mock<IAudioContentLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.DeleteById(audioContentId));
            AudioContentController controller = new AudioContentController(mock.Object);

            var response = controller.DeleteById(audioContentId);
            var statusCodeResult = response as StatusCodeResult;

            mock.VerifyAll();
            Assert.AreEqual(204, statusCodeResult.StatusCode);
        }

        [TestMethod]
        public void TestUpdateAudioContentOk()
        {
            int audioContentId = 1;
            AudioContentModel audioContentModel = new AudioContentModel()
            {
                Name = "Canción",
                Duration = TimeSpan.MaxValue,
                CreatorName = "Juan",
                ImageUrl = "www.unaimagen.com",
                AudioUrl = "www.audio.com",
                Categories = new List<CategoryBasicInfoModel>()
                {
                    new CategoryBasicInfoModel
                    {
                        Id = 1
                    }
                },
                Playlists = new List<PlaylistBasicInfoModel>()
                {
                    new PlaylistBasicInfoModel
                    {
                        Id = 1
                    }
                },
            };
            Mock<IAudioContentLogicAdapter> mock = new Mock<IAudioContentLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.UpdateById(It.IsAny<int>(), It.IsAny<AudioContentModel>()));
            AudioContentController controller = new AudioContentController(mock.Object);

            var response = controller.Update(audioContentId, audioContentModel);
            var statusCodeResult = response as StatusCodeResult;

            mock.VerifyAll();
            Assert.AreEqual(204, statusCodeResult.StatusCode);
        }

        [TestMethod]
        public void TestGetAudioContentNotExistentId()
        {
            Mock<IAudioContentLogicAdapter> mock = new Mock<IAudioContentLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.GetById(It.IsAny<int>())).Throws(new NullObjectMappingException("Not found object"));
            AudioContentController controller = new AudioContentController(mock.Object);

            var result = controller.Get(It.IsAny<int>());
            var objectResult = result as ObjectResult;

            mock.VerifyAll();
            Assert.AreEqual(404, objectResult.StatusCode);
        }

        [TestMethod]
        public void TestCreateAudioContentNotValidName()
        {
            AudioContentModel audioContentModel = new AudioContentModel()
            {
                Name = "",
                Duration = TimeSpan.MaxValue,
                CreatorName = "Juan",
                ImageUrl = "www.unaimagen.com",
                AudioUrl = "www.audio.com",
                Categories = new List<CategoryBasicInfoModel>()
                {
                    new CategoryBasicInfoModel
                    {
                        Id = 1
                    }
                },
                Playlists = new List<PlaylistBasicInfoModel>()
                {
                    new PlaylistBasicInfoModel
                    {
                        Id = 1
                    }
                },
            };
            Mock<IAudioContentLogicAdapter> mock = new Mock<IAudioContentLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.Add(It.IsAny<AudioContentModel>())).Throws(new ArgumentInvalidMappingException("Name is required"));
            AudioContentController controller = new AudioContentController(mock.Object);

            var result = controller.Post(audioContentModel);
            var objectResult = result as ObjectResult;

            mock.VerifyAll();
            Assert.AreEqual(400, objectResult.StatusCode);
        }
    }
}