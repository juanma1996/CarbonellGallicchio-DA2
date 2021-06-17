using AdapterInterface;
using BetterCalm.WebApi.Controllers;
using ImporterLogicInterface;
using Microsoft.AspNetCore.Mvc;
using Model.In;
using System.Collections.Generic;
using WebApi.Filters;

namespace WebApi.Controllers
{
    [Route("api/importers")]
    [ServiceFilter(typeof(AuthorizationFilter))]
    public class ImporterController : BetterCalmControllerBase
    {
        private readonly IImporterLogicAdapter importerLogicAdapter;

        public ImporterController(IImporterLogicAdapter importerLogicAdapter)
        {
            this.importerLogicAdapter = importerLogicAdapter;
        }

        // POST: 
        /// <summary>
        /// Creates an administrator.
        /// </summary>
        /// <remarks>
        /// Creates the administrator with the information send in the body. An administrator token is required.
        /// </remarks>
        /// <response code="201">Created.</response>
        /// <response code="400">Error. The configurated path is not valid.</response>
        /// <response code="400">Error. The given path is not valid.</response>
        /// <response code="401">Unauthorized. Must contain a token to access Api.</response>
        /// <response code="403">Unauthorized. Forbidden, ask for permission.</response>
        /// <response code="500">InternalServerError. Server problems, unexpected error.</response>
        [HttpPost]
        public IActionResult Post(ImportModel importModel)
        {
            importerLogicAdapter.ImportWithKnownInterface(importModel);
            return CreatedAtRoute("", null);
        }

        // GET: 
        /// <summary>
        /// Obtains the information of all avaible importers by the configurated path.
        /// </summary>
        /// <remarks>
        /// Obtains the information of all avaible importers by the configurated path. An administrator token is required.
        /// </remarks>
        /// <response code="200">Success. Returns the requested object.</response>  
        /// <response code="400">Error. The configurated path is not valid.</response>
        /// <response code="401">Unauthorized. Must contain a token to access Api.</response>
        /// <response code="403">Unauthorized. Forbidden, ask for permission.</response>
        /// <response code="500">InternalServerError. Server problems, unexpected error.</response>
        [HttpGet]
        public IActionResult Get()
        {
            List<string> importers = importerLogicAdapter.GetAll();
            return Ok(importers);
        }
    }
}
