using System.Collections.Generic;
using AdapterInterface;
using BetterCalm.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Model.Out;

namespace WebApi.Controllers
{
    [Route("api/problematics")]
    public class ProblematicController : BetterCalmControllerBase
    {
        private readonly IProblematicLogicAdapter problematicDomainToModel;
        public ProblematicController(IProblematicLogicAdapter problematicDomainToModel)
        {
            this.problematicDomainToModel = problematicDomainToModel;
        }

        // GET: 
        /// <summary>
        /// Obtains all the problematics.
        /// </summary>
        /// <remarks>
        /// Obtains all the information of the problematics on the system.
        /// </remarks>
        /// <response code="200">Success. Returns the list of problematics.</response>  
        /// <response code="500">InternalServerError. Server problems, unexpected error.</response>
        [HttpGet]
        public IActionResult Get()
        {
            List<ProblematicBasicInfoModel> problematics = problematicDomainToModel.GetAll();
            return Ok(problematics);
        }
    }
}
