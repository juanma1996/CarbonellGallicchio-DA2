using Adapter.Mapper;
using Adapter.Mapper.Profiles;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdapterTests
{
    [TestClass]
    public class ProblematicMapTest
    {
        [TestMethod]
        public void TestProblematicMapOk()
        {
            ModelMapper mapper = new ModelMapper();
            MapperConfiguration configuration = new MapperConfiguration(mapper => mapper.AddProfile(new ProblematicProfile()));
            configuration.AssertConfigurationIsValid();
        }
    }
}
