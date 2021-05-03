using AdapterExceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.In;
using System;
using System.Collections.Generic;
using System.Text;
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
            string largeDescription = "This is a description very large for the playlist description attribute";
            PlaylistModel playlist = new PlaylistModel()
            {
                Id = 1,
                Name = "Juan Manuel",
                Description = largeDescription
            };
            PlaylistModelValidator validator = new PlaylistModelValidator();

            validator.Validate(playlist);
        }
    }
}
