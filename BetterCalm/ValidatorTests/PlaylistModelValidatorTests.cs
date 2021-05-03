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
    }
}
