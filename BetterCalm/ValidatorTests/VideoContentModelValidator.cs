using AdapterExceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.In;
using System.Collections.Generic;
using Validator;

namespace ValidatorTests
{
    [TestClass]
    public class VideoContentModelValidatorTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestVideoContentModelWithEmptyName()
        {
            VideoContentModel VideoContentModel = new VideoContentModel
            {
                Name = ""
            };
            VideoContentModelValidator validator = new VideoContentModelValidator();

            validator.Validate(VideoContentModel);
        }

        [TestMethod]
        public void TestVideoContentModelIsCorrect()
        {
            VideoContentModel VideoContentModel = new VideoContentModel()
            {
                Id = 1,
                Name = "Video content",
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
            VideoContentModelValidator validator = new VideoContentModelValidator();

            validator.Validate(VideoContentModel);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestVideoContentModelWithEmptyCategory()
        {
            VideoContentModel VideoContentModel = new VideoContentModel()
            {
                Id = 1,
                Name = "Video content",
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
            VideoContentModelValidator validator = new VideoContentModelValidator();

            validator.Validate(VideoContentModel);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestVideoContentModelWithEmptyPlaylist()
        {
            VideoContentModel VideoContentModel = new VideoContentModel()
            {
                Id = 1,
                Name = "Video content",
                Categories = new List<CategoryModel>()
                {
                    new CategoryModel()
                    {
                        Id = 1,
                        Name = "Name"
                    }
                }
            };
            VideoContentModelValidator validator = new VideoContentModelValidator();

            validator.Validate(VideoContentModel);
        }
    }
}
