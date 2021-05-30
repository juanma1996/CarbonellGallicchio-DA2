using AdapterInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Out;
using Moq;
using System;
using WebApi.Controllers;

namespace WebApiTests
{
    [TestClass]
    public class VideoContentControllerTest
    {
        [TestMethod]
        public void TestGetVideoContentOk()
        {
            int videoContentId = 1;
            VideoContentBasicInfoModel videoContentToReturn = new VideoContentBasicInfoModel()
            {
                Id = videoContentId,
                Name = "Video",
                Duration = TimeSpan.MaxValue,
                CreatorName = "Juan"
            };
            Mock<IVideoContentLogicAdapter> mock = new Mock<IVideoContentLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.GetById(videoContentId)).Returns(videoContentToReturn);
            VideoContentController controller = new VideoContentController(mock.Object);

            var result = controller.Get(videoContentId);
            OkObjectResult okResult = result as OkObjectResult;
            VideoContentBasicInfoModel videoContent = okResult.Value as VideoContentBasicInfoModel;

            Assert.AreEqual(videoContentToReturn.Id, videoContent.Id);
        }
    }
}
