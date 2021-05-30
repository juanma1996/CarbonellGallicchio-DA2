using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Out;
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
            VideoContentController controller = new VideoContentController();

            var result = controller.Get(videoContentId);
            OkObjectResult okResult = result as OkObjectResult;
            VideoContentBasicInfoModel videoContent = okResult.Value as VideoContentBasicInfoModel;

            Assert.AreEqual(videoContentToReturn.Id, videoContent.Id);
        }
    }
}
