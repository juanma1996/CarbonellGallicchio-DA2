using BusinessExceptions;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Validator;

namespace ValidatorTests
{
    [TestClass]
    public class PlaylistValidatorTests
    {
        [TestMethod]
        [ExpectedException(typeof(NullObjectException))]
        public void TestAdministratorModelWithEmptyName()
        {
            Playlist playlist = null;
            PlaylistValidator validator = new PlaylistValidator();

            validator.Validate(playlist);
        }
    }
}
