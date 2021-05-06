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
            OkObjectResult okResult = result as OkObjectResult;
            AudioContentBasicInfoModel audioContent = okResult.Value as AudioContentBasicInfoModel;

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
            AudioContentBasicInfoModel audioContentToReturn = new AudioContentBasicInfoModel()
            {
                Id = audioContentId
            };
            Mock<IAudioContentLogicAdapter> mock = new Mock<IAudioContentLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.Add(It.IsAny<AudioContentModel>())).Returns(audioContentToReturn);
            AudioContentController controller = new AudioContentController(mock.Object);

            var result = controller.Post(audioContentModel);
            CreatedAtRouteResult createdAtRouteResult = result as CreatedAtRouteResult;
            AudioContentBasicInfoModel audioContentBasicInfoModel = createdAtRouteResult.Value as AudioContentBasicInfoModel;

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

            var response = controller.Delete(audioContentId);
            StatusCodeResult statusCodeResult = response as StatusCodeResult;

            mock.VerifyAll();
            Assert.AreEqual(204, statusCodeResult.StatusCode);
        }

        [TestMethod]
        public void TestUpdateAudioContentOk()
        {
            AudioContentModel audioContentModel = new AudioContentModel()
            {
                Name = "Canción",
                Duration = TimeSpan.MaxValue,
                CreatorName = "Juan",
                ImageUrl = "www.unaimagen.com",
                AudioUrl = "www.audio.com",
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
            Mock<IAudioContentLogicAdapter> mock = new Mock<IAudioContentLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.Update(It.IsAny<AudioContentModel>()));
            AudioContentController controller = new AudioContentController(mock.Object);

            var response = controller.Put(audioContentModel);
            StatusCodeResult statusCodeResult = response as StatusCodeResult;

            mock.VerifyAll();
            Assert.AreEqual(204, statusCodeResult.StatusCode);
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void TestGetAudioContentNotExistentId()
        {
            Mock<IAudioContentLogicAdapter> mock = new Mock<IAudioContentLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.GetById(It.IsAny<int>())).Throws(new NotFoundException("Not found object"));
            AudioContentController controller = new AudioContentController(mock.Object);

            var result = controller.Get(It.IsAny<int>());

            mock.VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestCreateAudioContentNotValidName()
        {
            AudioContentModel audioContentModel = new AudioContentModel()
            {
                Name = "",
                Duration = TimeSpan.MaxValue,
                CreatorName = "Juan",
                ImageUrl = "www.unaimagen.com",
                AudioUrl = "www.audio.com",
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
            Mock<IAudioContentLogicAdapter> mock = new Mock<IAudioContentLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.Add(It.IsAny<AudioContentModel>())).Throws(new InvalidAttributeException("Name is required"));
            AudioContentController controller = new AudioContentController(mock.Object);

            var result = controller.Post(audioContentModel);

            mock.VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void TestDeleteAudioContentNotExistentId()
        {
            int audioContentId = 1;
            Mock<IAudioContentLogicAdapter> mock = new Mock<IAudioContentLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.DeleteById(It.IsAny<int>())).Throws(new NotFoundException("Not found object"));
            AudioContentController controller = new AudioContentController(mock.Object);

            var result = controller.Delete(audioContentId);

            mock.VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void TestUpdateAudioContentNotExistentId()
        {
            AudioContentModel audioContentModel = new AudioContentModel()
            {
                Name = "Canción",
                Duration = TimeSpan.MaxValue,
                CreatorName = "Juan",
                ImageUrl = "www.unaimagen.com",
                AudioUrl = "www.audio.com",
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
            Mock<IAudioContentLogicAdapter> mock = new Mock<IAudioContentLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.Update(It.IsAny<AudioContentModel>())).Throws(new NotFoundException("Not found object"));
            AudioContentController controller = new AudioContentController(mock.Object);

            var result = controller.Put(audioContentModel);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestUpdateAudioContentNotValidName()
        {
            AudioContentModel audioContentModel = new AudioContentModel()
            {
                Name = "",
                Duration = TimeSpan.MaxValue,
                CreatorName = "Juan",
                ImageUrl = "www.unaimagen.com",
                AudioUrl = "www.audio.com",
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
            Mock<IAudioContentLogicAdapter> mock = new Mock<IAudioContentLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.Update(It.IsAny<AudioContentModel>())).Throws(new InvalidAttributeException("Name is required"));
            AudioContentController controller = new AudioContentController(mock.Object);

            var result = controller.Put(audioContentModel);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestPostAudioContentPlaylistNameInvalid()
        {
            int audioContentId = 1;
            AudioContentModel audioContentModel = new AudioContentModel()
            {
                Name = "Canción",
                Duration = TimeSpan.MaxValue,
                CreatorName = "Juan",
                ImageUrl = "www.unaimagen.com",
                AudioUrl = "www.audio.com",
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
            AudioContentBasicInfoModel audioContentToReturn = new AudioContentBasicInfoModel()
            {
                Id = audioContentId
            };
            Mock<IAudioContentLogicAdapter> mock = new Mock<IAudioContentLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.Add(It.IsAny<AudioContentModel>())).Throws(new InvalidAttributeException("Name can't be empty"));
            AudioContentController controller = new AudioContentController(mock.Object);

            var result = controller.Post(audioContentModel);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestPostAudioContentPlaylistDescriptionInvalid()
        {
            int audioContentId = 1;
            AudioContentModel audioContentModel = new AudioContentModel()
            {
                Name = "Canción",
                Duration = TimeSpan.MaxValue,
                CreatorName = "Juan",
                ImageUrl = "www.unaimagen.com",
                AudioUrl = "www.audio.com",
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
            AudioContentBasicInfoModel audioContentToReturn = new AudioContentBasicInfoModel()
            {
                Id = audioContentId
            };
            Mock<IAudioContentLogicAdapter> mock = new Mock<IAudioContentLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.Add(It.IsAny<AudioContentModel>())).Throws(new InvalidAttributeException("Description can't be empty"));
            AudioContentController controller = new AudioContentController(mock.Object);

            var result = controller.Post(audioContentModel);

            mock.VerifyAll();
        }
    }
}