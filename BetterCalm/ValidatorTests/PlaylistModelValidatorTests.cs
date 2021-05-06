using AdapterExceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.In;
using Validator;

namespace ValidatorTests
{
    [TestClass]
    public class PlaylistModelValidatorTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestPlaylistModelInvalidName()
        {
            PlaylistModel playlist = new PlaylistModel()
            {
                Id = 1,
                Name = "",
                Description = "One description"
            };
            PlaylistModelValidator validator = new PlaylistModelValidator();

            validator.Validate(playlist);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestPlaylistModelEmptyDescription()
        {
            PlaylistModel playlist = new PlaylistModel()
            {
                Id = 1,
                Name = "Juan Manuel",
                Description = ""
            };
            PlaylistModelValidator validator = new PlaylistModelValidator();

            validator.Validate(playlist);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestPlaylistModelToolargeDescription()
        {
            string largeDescription = "This is a description very large for the playlist description" +
                " attribute that must contain a string with one hundred and fifty " +
                "characteres but this has more";
            PlaylistModel playlist = new PlaylistModel()
            {
                Id = 1,
                Name = "Juan Manuel",
                Description = largeDescription
            };
            PlaylistModelValidator validator = new PlaylistModelValidator();

            validator.Validate(playlist);
        }

        [TestMethod]
        public void TestPlaylistModelIsOk()
        {
            PlaylistModel playlist = new PlaylistModel()
            {
                Id = 1,
                Name = "Juan Manuel",
                Description = "Description"
            };
            PlaylistModelValidator validator = new PlaylistModelValidator();

            validator.Validate(playlist);
        }
    }
}
