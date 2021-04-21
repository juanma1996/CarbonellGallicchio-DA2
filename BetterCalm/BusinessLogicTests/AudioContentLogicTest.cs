using BusinessLogic;
using DataAccessInterface;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicTests
{
    [TestClass]
    public class AudioContentLogicTest
    {
        [TestMethod]
        public void TestGetAudioContentOk()
        {
            int audioContentId = 1;
            AudioContent audioContentToReturn = new AudioContent()
            {
                Id = audioContentId,
                Name = "Canción",
                Duration = TimeSpan.MaxValue,
                CreatorName = "Juan",
                ImageUrl = "www.unaimagen.com",
                AudioUrl = "www.audio.com"
            };
            Mock<IRepository<AudioContent>> mock = new Mock<IRepository<AudioContent>>(MockBehavior.Strict);
            mock.Setup(m => m.GetById(audioContentId)).Returns(audioContentToReturn);
            AudioContentLogic audioContentLogic = new AudioContentLogic(mock.Object);

            AudioContent result = audioContentLogic.GetById(audioContentId);

            mock.VerifyAll();
            Assert.AreEqual(audioContentToReturn.Id, result.Id);
            Assert.AreEqual(audioContentToReturn.Name, result.Name);
        }

        [TestMethod]
        public void TestCreateAudioContentOk()
        {
            int audioContentId = 1;
            AudioContent audioContentModel = new AudioContent()
            {
                Name = "Canción",
                Duration = TimeSpan.MaxValue,
                CreatorName = "Juan",
                ImageUrl = "www.unaimagen.com",
                AudioUrl = "www.audio.com",
                Categories = new List<Category>()
                {
                    new Category
                    {
                        Id = 1
                    }
                },
                Playlists = new List<Playlist>()
                {
                    new Playlist
                    {
                        Id = 1
                    }
                },
            };
            AudioContent audioContentToReturn = new AudioContent()
            {
                Id = audioContentId
            };
            Mock<IRepository<AudioContent>> mock = new Mock<IRepository<AudioContent>>(MockBehavior.Strict);
            mock.Setup(m => m.Add(It.IsAny<AudioContent>())).Returns(audioContentToReturn);
            AudioContentLogic audioContentLogic = new AudioContentLogic(mock.Object);

            var result = audioContentLogic.Create(audioContentModel);

            mock.VerifyAll();
            Assert.AreEqual(audioContentId, audioContentToReturn.Id);
        }

        [TestMethod]
        public void TestDeleteAudioContentOk()
        {
            int audioContentId = 1;
            AudioContent audioContentToReturn = new AudioContent
            {
                Id = audioContentId
            };
            Mock<IRepository<AudioContent>> mock = new Mock<IRepository<AudioContent>>(MockBehavior.Strict);
            mock.Setup(m => m.GetById(audioContentId)).Returns(audioContentToReturn);
            mock.Setup(m => m.Delete(It.IsAny<AudioContent>()));
            AudioContentLogic audioContentLogic = new AudioContentLogic(mock.Object);

            var result = audioContentLogic.DeleteById(audioContentId);

            mock.VerifyAll();
        }
    }
}
