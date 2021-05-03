using System;
using Adapter;
using Adapter.Mapper;
using Adapter.Mapper.Profiles;
using AdapterExceptions;
using AutoMapper;
using BusinessExceptions;
using BusinessLogicInterface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AdapterTests
{
    [TestClass]
    public class CategoryLogicAdapterTest
    {
        [TestMethod]
        public void TestCategoryMapOk()
        {
            ModelMapper mapper = new ModelMapper();
            var configuration = new MapperConfiguration(mapper => mapper.AddProfile(new CategoryProfile()));
            configuration.AssertConfigurationIsValid();
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void TestGetPlaylistByCategoryIdNotPlaylistExist()
        {
            int categoryId = 1;
            Mock<ICategoryLogic> mock = new Mock<ICategoryLogic>(MockBehavior.Strict);
            mock.Setup(m => m.GetPlaylistsByCategoryId(It.IsAny<int>())).Throws(new NullObjectException("Not exist any playlist for this category"));
            ModelMapper mapper = new ModelMapper();
            CategoryLogicAdapter categoryLogicAdapter = new CategoryLogicAdapter(mock.Object, mapper);

            categoryLogicAdapter.GetPlaylistsByCategoryId(categoryId);

            mock.VerifyAll();
        }
    }
}
