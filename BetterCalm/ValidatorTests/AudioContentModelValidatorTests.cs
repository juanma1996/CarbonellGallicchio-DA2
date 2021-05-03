using AdapterExceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.In;
using System.Collections.Generic;
using Validator;

namespace ValidatorTests
{
    [TestClass]
    public class AudioContentModelValidatorTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestAudioContentModelWithEmptyName()
        {
            AudioContentModel audioContentModel = new AudioContentModel
            {
                Name = ""
            };
            AudioContentModelValidator validator = new AudioContentModelValidator();

            validator.Validate(audioContentModel);
        }

        [TestMethod]
        public void TestAudioContentModelIsCorrect()
        {
            AudioContentModel audioContentModel = new AudioContentModel()
            {
                Id = 1,
                Name = "Audio content",
                Playlists = new List<PlaylistModel>()
                {
                    new PlaylistModel()
                    {
                        Id = 1,
                        Name = "Name",
                        Description = "Description"
                    }
                }
            };
            AudioContentModelValidator validator = new AudioContentModelValidator();

            validator.Validate(audioContentModel);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestAudioContentModelWithEmptyCategory()
        {
            AudioContentModel audioContentModel = new AudioContentModel()
            {
                Id = 1,
                Name = "Audio content",
                Playlists = new List<PlaylistModel>()
                {
                    new PlaylistModel()
                    {
                        Id = 1,
                        Name = "Name",
                        Description = "Description"
                    }
                },
                Categories = new List<CategoryModel>()
                {
                    new CategoryModel()
                    {
                        Id = 1,
                        Name = "Name"
                    }
                }
            };
            AudioContentModelValidator validator = new AudioContentModelValidator();

            validator.Validate(audioContentModel);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestAudioContentModelWithEmptyPlaylist()
        {
            AudioContentModel audioContentModel = new AudioContentModel()
            {
                Id = 1,
                Name = "Audio content",
                Categories = new List<CategoryModel>()
                {
                    new CategoryModel()
                    {
                        Id = 1,
                        Name = "Name"
                    }
                }
            };
            AudioContentModelValidator validator = new AudioContentModelValidator();

            validator.Validate(audioContentModel);
        }
    }
}
