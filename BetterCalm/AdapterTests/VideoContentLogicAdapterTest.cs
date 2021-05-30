using Adapter.Mapper;
using Adapter.Mapper.Profiles;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdapterTests
{
    [TestClass]
    public class VideoContentLogicAdapterTest
    {
        [TestMethod]
        public void TestAudioContentMapOk()
        {
            ModelMapper mapper = new ModelMapper();
            MapperConfiguration configuration = new MapperConfiguration(mapper => mapper.AddProfile(new VideoContentProfile()));
            configuration.AssertConfigurationIsValid();
        }
    }
}
