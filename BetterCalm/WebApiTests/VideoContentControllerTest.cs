using AdapterExceptions;
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

        [TestMethod]
        public void TestUpdateVideoContentOk()
        {
            VideoContentModel videoContentModel = new VideoContentModel()
            {
                Name = "Video",
                Duration = TimeSpan.MaxValue,
                CreatorName = "Juan",
                VideoUrl = "www.youtube.com/video",
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
            Mock<IVideoContentLogicAdapter> mock = new Mock<IVideoContentLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.Update(It.IsAny<VideoContentModel>()));
            VideoContentController controller = new VideoContentController(mock.Object);

            var response = controller.Put(videoContentModel);
            StatusCodeResult statusCodeResult = response as StatusCodeResult;

            mock.VerifyAll();
            Assert.AreEqual(204, statusCodeResult.StatusCode);
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void TestGetVideoContentNotExistentId()
        {
            Mock<IVideoContentLogicAdapter> mock = new Mock<IVideoContentLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.GetById(It.IsAny<int>())).Throws(new NotFoundException("Not found object"));
            VideoContentController controller = new VideoContentController(mock.Object);

            var result = controller.Get(It.IsAny<int>());

            mock.VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestCreateVideoContentNotValidName()
        {
            VideoContentModel videoContentModel = new VideoContentModel()
            {
                Name = "",
                Duration = TimeSpan.MaxValue,
                CreatorName = "Juan",
                VideoUrl = "www.youtube.com/video",
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
            Mock<IVideoContentLogicAdapter> mock = new Mock<IVideoContentLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.Add(It.IsAny<VideoContentModel>())).Throws(new InvalidAttributeException("Name is required"));
            VideoContentController controller = new VideoContentController(mock.Object);

            var result = controller.Post(videoContentModel);

            mock.VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void TestDeleteVideoContentNotExistentId()
        {
            int videoContentId = 1;
            Mock<IVideoContentLogicAdapter> mock = new Mock<IVideoContentLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.DeleteById(It.IsAny<int>())).Throws(new NotFoundException("Not found object"));
            VideoContentController controller = new VideoContentController(mock.Object);

            var result = controller.Delete(videoContentId);

            mock.VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void TestUpdateVideoContentNotExistentId()
        {
            VideoContentModel videoContentModel = new VideoContentModel()
            {
                Name = "Canción",
                Duration = TimeSpan.MaxValue,
                CreatorName = "Juan",
                VideoUrl = "www.youtube.com/video",
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
            Mock<IVideoContentLogicAdapter> mock = new Mock<IVideoContentLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.Update(It.IsAny<VideoContentModel>())).Throws(new NotFoundException("Not found object"));
            VideoContentController controller = new VideoContentController(mock.Object);

            var result = controller.Put(videoContentModel);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestUpdateVideoContentNotValidName()
        {
            VideoContentModel videoContentModel = new VideoContentModel()
            {
                Name = "",
                Duration = TimeSpan.MaxValue,
                CreatorName = "Juan",
                VideoUrl = "www.youtube.com/youtube",
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
            Mock<IVideoContentLogicAdapter> mock = new Mock<IVideoContentLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.Update(It.IsAny<VideoContentModel>())).Throws(new InvalidAttributeException("Name is required"));
            VideoContentController controller = new VideoContentController(mock.Object);

            var result = controller.Put(videoContentModel);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestPostVideoContentPlaylistNameInvalid()
        {
            VideoContentModel videoContentModel = new VideoContentModel()
            {
                Name = "Canción",
                Duration = TimeSpan.MaxValue,
                CreatorName = "Juan",
                VideoUrl = "www.youtube.com/youtube",
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
                        Id = 1,
                        Name = ""
                    }
                },
            };
            Mock<IVideoContentLogicAdapter> mock = new Mock<IVideoContentLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.Add(It.IsAny<VideoContentModel>())).Throws(new InvalidAttributeException("Name can't be empty"));
            VideoContentController controller = new VideoContentController(mock.Object);

            var result = controller.Post(videoContentModel);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestPostVideoContentPlaylistDescriptionInvalid()
        {
            VideoContentModel videoContentModel = new VideoContentModel()
            {
                Name = "Canción",
                Duration = TimeSpan.MaxValue,
                CreatorName = "Juan",
                VideoUrl = "www.youtube.com/video",
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
                        Id = 1,
                        Name = "name",
                        Description = ""
                    }
                },
            };
            Mock<IVideoContentLogicAdapter> mock = new Mock<IVideoContentLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.Add(It.IsAny<VideoContentModel>())).Throws(new InvalidAttributeException("Description can't be empty"));
            VideoContentController controller = new VideoContentController(mock.Object);

            var result = controller.Post(videoContentModel);

            mock.VerifyAll();
        }

        [TestMethod]
        public void TestGetVideoContentsByCategoryOk()
        {
            int categoryId = 1;
            VideoContentBasicInfoModel firstVideoContentToReturn = new VideoContentBasicInfoModel()
            {
                Id = 1,
                Name = "One Song",
                Duration = TimeSpan.MaxValue,
                CreatorName = "Juan",
                VideoUrl = "www.unvideo.com"
            };
            VideoContentBasicInfoModel secondVideoContentToReturn = new VideoContentBasicInfoModel()
            {
                Id = 2,
                Name = "Another song",
                Duration = TimeSpan.MaxValue,
                CreatorName = "Juan",
                VideoUrl = "www.unvideo.com"
            };
            List<VideoContentBasicInfoModel> videoContentsToReturn = new List<VideoContentBasicInfoModel>() { firstVideoContentToReturn, secondVideoContentToReturn };
            Mock<IVideoContentLogicAdapter> mock = new Mock<IVideoContentLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.GetByCategoryId(categoryId)).Returns(videoContentsToReturn);
            VideoContentController controller = new VideoContentController(mock.Object);

            var result = controller.GetVideoContentByCategory(categoryId);
            OkObjectResult okResult = result as OkObjectResult;
            List<VideoContentBasicInfoModel> videoContents = okResult.Value as List<VideoContentBasicInfoModel>;

            mock.VerifyAll();
            Assert.AreEqual(videoContentsToReturn.Count, videoContents.Count);
        }

        [TestMethod]
        public void TestGetVideoContentsByPlaylistOk()
        {
            int playlistId = 1;
            VideoContentBasicInfoModel firstVideoContentToReturn = new VideoContentBasicInfoModel()
            {
                Id = 1,
                Name = "One Song",
                Duration = TimeSpan.MaxValue,
                CreatorName = "Juan",
                VideoUrl = "www.unvideo.com"
            };
            VideoContentBasicInfoModel secondVideoContentToReturn = new VideoContentBasicInfoModel()
            {
                Id = 2,
                Name = "Another song",
                Duration = TimeSpan.MaxValue,
                CreatorName = "Juan",
                VideoUrl = "www.unvideo.com"
            };
            List<VideoContentBasicInfoModel> videoContentsToReturn = new List<VideoContentBasicInfoModel>() { firstVideoContentToReturn, secondVideoContentToReturn };
            Mock<IVideoContentLogicAdapter> mock = new Mock<IVideoContentLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.GetByPlaylistId(playlistId)).Returns(videoContentsToReturn);
            VideoContentController controller = new VideoContentController(mock.Object);

            var result = controller.GetVideoContentByPlaylist(playlistId);
            OkObjectResult okResult = result as OkObjectResult;
            List<VideoContentBasicInfoModel> videoContents = okResult.Value as List<VideoContentBasicInfoModel>;

            mock.VerifyAll();
            Assert.AreEqual(videoContentsToReturn.Count, videoContents.Count);
        }

        [TestMethod]
        public void TestGetVideoContentsOk()
        {
            VideoContentBasicInfoModel firstVideoContentToReturn = new VideoContentBasicInfoModel()
            {
                Id = 1,
                Name = "One Song",
                Duration = TimeSpan.MaxValue,
                CreatorName = "Juan",
                VideoUrl = "www.unvideo.com"
            };
            VideoContentBasicInfoModel secondVideoContentToReturn = new VideoContentBasicInfoModel()
            {
                Id = 2,
                Name = "Another song",
                Duration = TimeSpan.MaxValue,
                CreatorName = "Juan",
                VideoUrl = "www.unvideo.com"
            };
            List<VideoContentBasicInfoModel> videoContentsToReturn = new List<VideoContentBasicInfoModel>() { firstVideoContentToReturn, secondVideoContentToReturn };
            Mock<IVideoContentLogicAdapter> mock = new Mock<IVideoContentLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll()).Returns(videoContentsToReturn);
            VideoContentController controller = new VideoContentController(mock.Object);

            var result = controller.Get();
            OkObjectResult okResult = result as OkObjectResult;
            List<VideoContentBasicInfoModel> videoContents = okResult.Value as List<VideoContentBasicInfoModel>;

            mock.VerifyAll();
            Assert.AreEqual(videoContentsToReturn.Count, videoContents.Count);
        }
    }
}
