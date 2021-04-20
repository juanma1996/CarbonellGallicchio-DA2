using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Out;
using WebApi.Controllers;

namespace WebApiTests
{
    [TestClass]
    public class PsychologistControllerTest
    {
        [TestMethod]
        public void PsychologistController()
        {
            var controller = new PsychologistController();

            var result = controller.GetById();
            var okResult = result as OkObjectResult;
            var psychologist = okResult.Value as PsychologistBasicInfoModel;

            Assert.IsNotNull(psychologist);
        }
    }
}
