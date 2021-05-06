using Adapter.Mapper;
using Adapter.Mapper.Profiles;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdapterTests
{
    [TestClass]
    public class PacientMapTest
    {
        [TestMethod]
        public void PacientMapTestok()
        {
            ModelMapper mapper = new ModelMapper();
            MapperConfiguration configuration = new MapperConfiguration(mapper => mapper.AddProfile(new PacientProfile()));
            configuration.AssertConfigurationIsValid();
        }
    }
}
