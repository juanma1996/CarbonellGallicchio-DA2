using Adapter;
using Adapter.Mapper;
using Adapter.Mapper.Profiles;
using AutoMapper;
using BusinessLogicInterface;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Out;
using Moq;
using System.Collections.Generic;

namespace AdapterTests
{
    [TestClass]
    public class BonusLogicAdapterTest
    {
        [TestMethod]
        public void TestBonusMapOk()
        {
            ModelMapper mapper = new ModelMapper();
            MapperConfiguration configuration = new MapperConfiguration(mapper => mapper.AddProfile(new BonusProfile()));
            configuration.AssertConfigurationIsValid();
        }

        [TestMethod]
        public void TestGetBonusesOk()
        {
            Pacient firstPacientToReturn = new Pacient()
            {
                Id = 1,
                Email = "juan@email.com",
                ConsultationsQuantity = 5
            };
            Pacient secondPacientToReturn = new Pacient()
            {
                Id = 2,
                Email = "fede@email.com",
                ConsultationsQuantity = 6
            };
            List<Pacient> pacientsToReturn = new List<Pacient>() { firstPacientToReturn, secondPacientToReturn };
            Mock<IBonusLogic> mock = new Mock<IBonusLogic>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll()).Returns(pacientsToReturn);
            ModelMapper mapper = new ModelMapper();
            BonusLogicAdapter bonusLogicAdapter = new BonusLogicAdapter(mock.Object, mapper);

            List<BonusBasicInfoModel> result = bonusLogicAdapter.GetAll();

            mock.VerifyAll();
            Assert.AreEqual(pacientsToReturn.Count, result.Count);
        }
    }
}
