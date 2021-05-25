using BetterCalm.WebApi.Controllers;
using ImporterLogicInterface;
using Microsoft.AspNetCore.Mvc;
using Model.In;
using System;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [Route("api/importers")]
    public class ImporterController : BetterCalmControllerBase
    {
        private readonly IImporterLogic importerLogic;

        public ImporterController(IImporterLogic importerLogic)
        {
            this.importerLogic = importerLogic;
        }

        [HttpPost]
        public IActionResult Post(ImportModel importModel)
        {
            importerLogic.ImportWithKnownInterface(importModel);
            return CreatedAtRoute("", null);
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<string> importers = importerLogic.GetAll();
            return Ok(importers);
        }
    }
}
