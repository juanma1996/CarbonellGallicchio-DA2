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
    }
}
