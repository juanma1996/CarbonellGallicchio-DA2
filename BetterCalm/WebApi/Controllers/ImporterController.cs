using BetterCalm.WebApi.Controllers;
using ImporterLogicInterface;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Post(string filePath)
        {
            importerLogic.InstantiateObjectWithKnownInterface(filePath);
            return CreatedAtRoute("", null);
        }
    }
}
