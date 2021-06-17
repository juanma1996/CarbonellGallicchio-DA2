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

        [HttpPost]
        public IActionResult Post(ImportModel importModel)
        {
            importerLogicAdapter.ImportWithKnownInterface(importModel);
            return CreatedAtRoute("", null);
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<string> importers = importerLogicAdapter.GetAll();
            return Ok(importers);
        }
    }
}
