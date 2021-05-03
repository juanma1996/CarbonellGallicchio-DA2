using Adapter;
using Adapter.Mapper;
using Adapter.Mapper.Profiles;
using AdapterExceptions;
using AutoMapper;
using BusinessExceptions;
using BusinessLogicInterface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Out;
using Moq;

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

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void TestGetAdministratorNotExistentId()
        {
            var administratorId = 1;
            Mock<IAdministratorLogic> mock = new Mock<IAdministratorLogic>(MockBehavior.Strict);
            mock.Setup(m => m.GetById(administratorId)).Throws(new NullObjectException("Not exist Administrator"));
            ModelMapper mapper = new ModelMapper();
            AdministratorLogicAdapter administratorLogicAdapter = new AdministratorLogicAdapter(mock.Object, mapper);

            AdministratorBasicInfoModel result = administratorLogicAdapter.GetById(administratorId);

            mock.VerifyAll();
        }
    }
}
