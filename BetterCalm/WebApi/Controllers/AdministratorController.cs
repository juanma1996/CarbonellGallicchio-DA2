using AdapterInterface;
using BetterCalm.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Model.In;
using Model.Out;
using WebApi.Filters;

namespace WebApi.Controllers
{
    [Route("api/administrators")]
    public class AdministratorController : BetterCalmControllerBase
    {
        private readonly IAdministratorLogicAdapter administratorDomainToModelAdapter;
        public AdministratorController(IAdministratorLogicAdapter administratorDomainToModelAdapter)
        {
            this.administratorDomainToModelAdapter = administratorDomainToModelAdapter;
        }

        [ServiceFilter(typeof(AuthorizationAttributeFilter))]
        [HttpGet("{id}", Name = "GetAdministrator")]
        public IActionResult Get(int id)
        {
            AdministratorBasicInfoModel administrator = administratorDomainToModelAdapter.GetById(id);
            return Ok(administrator);
        }

        [ServiceFilter(typeof(AuthorizationAttributeFilter))]
        [HttpPost]
        public IActionResult Post([FromBody] AdministratorModel administratorModel)
        {
            administratorDomainToModelAdapter.Add(administratorModel);
            return NoContent();
        }

        [ServiceFilter(typeof(AuthorizationAttributeFilter))]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            administratorDomainToModelAdapter.Delete(id);
            return NoContent();
        }

        [ServiceFilter(typeof(AuthorizationAttributeFilter))]
        [HttpPut]
        public IActionResult Put([FromBody]AdministratorModel administratorModel)
        {
            administratorDomainToModelAdapter.Update(administratorModel);
            return NoContent();
        }
    }
}
