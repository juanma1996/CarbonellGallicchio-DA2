using System;
using AdapterInterface;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class ProblematicController
    {
        private readonly IProblematicLogicAdapter problematicDomainToModel;
        public ProblematicController(IProblematicLogicAdapter problematicDomainToModel)
        {
            this.problematicDomainToModel = problematicDomainToModel;
        }

        [HttpGet]
        public IActionResult Get()
        {
            throw new NotImplementedException();
        }
    }
}
