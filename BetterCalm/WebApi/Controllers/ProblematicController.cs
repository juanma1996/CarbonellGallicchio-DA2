using System;
using System.Collections.Generic;
using AdapterInterface;
using BetterCalm.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Model.Out;

namespace WebApi.Controllers
{
    public class ProblematicController : BetterCalmControllerBase
    {
        private readonly IProblematicLogicAdapter problematicDomainToModel;
        public ProblematicController(IProblematicLogicAdapter problematicDomainToModel)
        {
            this.problematicDomainToModel = problematicDomainToModel;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<ProblematicBasicInfoModel> problematics = problematicDomainToModel.GetAll();
            return Ok(problematics);
        }
    }
}
