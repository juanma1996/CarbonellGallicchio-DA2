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
            mock.Setup(m => m.Get(audioContentId)).Returns(audioContentToReturn);
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
    }
}
