using AdapterInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.In;
using Model.Out;
using Moq;
using System;
using System.Collections.Generic;
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

        [TestMethod]
        public void TestPostVideoContentOk()
        {
            int videoContentId = 1;
            VideoContentModel videoContentModel = new VideoContentModel()
            {
                Name = "Video",
                Duration = TimeSpan.MaxValue,
                CreatorName = "Juan",
                VideoUrl = "www.youtube.com/video1",
                Categories = new List<CategoryModel>()
                {
                    new CategoryModel
                    {
                        Id = 1
                    }
                },
                Playlists = new List<PlaylistModel>()
                {
                    new PlaylistModel
                    {
                        Id = 1
                    }
                },
            };
            VideoContentBasicInfoModel videoContentToReturn = new VideoContentBasicInfoModel()
            {
                Id = videoContentId
            };
            Mock<IVideoContentLogicAdapter> mock = new Mock<IVideoContentLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.Add(It.IsAny<VideoContentModel>())).Returns(videoContentToReturn);
            VideoContentController controller = new VideoContentController(mock.Object);

            var result = controller.Post(videoContentModel);
            CreatedAtRouteResult createdAtRouteResult = result as CreatedAtRouteResult;
            VideoContentBasicInfoModel videoContentBasicInfoModel = createdAtRouteResult.Value as VideoContentBasicInfoModel;

            mock.VerifyAll();
            Assert.AreEqual(videoContentId, videoContentBasicInfoModel.Id);
        }

        [TestMethod]
        public void TestDeleteVideoContentOk()
        {
            int videoContentId = 1;
            Mock<IVideoContentLogicAdapter> mock = new Mock<IVideoContentLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.DeleteById(videoContentId));
            VideoContentController controller = new VideoContentController(mock.Object);

            var response = controller.Delete(videoContentId);
            StatusCodeResult statusCodeResult = response as StatusCodeResult;

            mock.VerifyAll();
            Assert.AreEqual(204, statusCodeResult.StatusCode);
        }
    }
}
