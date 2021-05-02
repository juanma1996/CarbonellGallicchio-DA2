using System;
using Adapter.Mapper;
using Adapter.Mapper.Profiles;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdapterTests
{
    [TestClass]
    public class PsychologistLogicAdapterTest
    {
        [TestMethod]
        public void TestPsychologistMapOk()
        {
            ModelMapper mapper = new ModelMapper();
            var configuration = new MapperConfiguration(mapper => mapper.AddProfile(new PsychologistProfile()));
            configuration.AssertConfigurationIsValid();
        }
    }
}
