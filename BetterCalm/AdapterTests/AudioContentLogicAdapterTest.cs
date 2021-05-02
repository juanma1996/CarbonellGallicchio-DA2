using System;
using Adapter.Mapper;
using Adapter.Mapper.Profiles;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdapterTests
{
    [TestClass]
    public class AudioContentLogicAdapterTest
    {
        [TestMethod]
        public void TestAudioContentMapOk()
        {
            ModelMapper mapper = new ModelMapper();
            var configuration = new MapperConfiguration(mapper => mapper.AddProfile(new AudioContentProfile()));
            configuration.AssertConfigurationIsValid();
        }
    }
}
