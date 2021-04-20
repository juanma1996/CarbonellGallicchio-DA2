using AdapterInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            AudioContentController controller = new AudioContentController();

            var result = controller.Get(audioContentId);
            var okResult = result as OkObjectResult;
            var audioContent = okResult.Value as AudioContentBasicInfoModel;

            Assert.AreEqual(audioContentToReturn.Id, audioContent.Id);
        }
    }
}
