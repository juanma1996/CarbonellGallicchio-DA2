using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Out;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Controllers;

namespace WebApiTests
{
    [TestClass]
    public class BonusControllerTest
    {
        [TestMethod]
        public void TestGetBonusesOk()
        {
            BonusBasicInfoModel firstBonusToReturn = new BonusBasicInfoModel()
            {
                PacientId = 1,
                PacientEmail = "juan@gmail.com",
                ConsultationsQuantity = 6
            };
            BonusBasicInfoModel secondBonusToReturn = new BonusBasicInfoModel()
            {
                PacientId = 2,
                PacientEmail = "fede@gmail.com",
                ConsultationsQuantity = 5
            };
            List<BonusBasicInfoModel> bonusesToReturn = new List<BonusBasicInfoModel>() { firstBonusToReturn, secondBonusToReturn };
            BonusController controller = new BonusController();

            var result = controller.Get();
            OkObjectResult okResult = result as OkObjectResult;
            List<BonusBasicInfoModel> bonuses = okResult.Value as List<BonusBasicInfoModel>;

            Assert.AreEqual(bonusesToReturn.Count, bonuses.Count);
        }
    }
}
