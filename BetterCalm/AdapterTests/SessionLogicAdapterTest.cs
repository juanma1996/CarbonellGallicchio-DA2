using System;
using Adapter.Mapper;
using Adapter.Mapper.Profiles;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdapterTests
{
    [TestClass]
    public class SessionLogicAdapterTest
    {
        [TestMethod]
        public void TestSessionMapOk()
        {
            ModelMapper mapper = new ModelMapper();
            var configuration = new MapperConfiguration(mapper => mapper.AddProfile(new SessionProfile()));
            configuration.AssertConfigurationIsValid();
        }
    }
}
