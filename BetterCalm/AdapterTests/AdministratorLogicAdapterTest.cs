using System;
using Adapter.Mapper;
using Adapter.Mapper.Profiles;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdapterTests
{
    [TestClass]
    public class AdministratorLogicAdapterTest
    {
        [TestMethod]
        public void TestAdministratorMapOk()
        {
            ModelMapper mapper = new ModelMapper();
            var configuration = new MapperConfiguration(mapper => mapper.AddProfile(new AdministratorProfile()));
            configuration.AssertConfigurationIsValid();
        }
    }
}
