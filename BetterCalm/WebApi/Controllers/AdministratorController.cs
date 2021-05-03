using System;
using AdapterExceptions;
using AdapterInterface;
using BetterCalm.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Model.In;
using Model.Out;
using WebApi.Filters;

namespace WebApi.Controllers
{
    public class AdministratorController : BetterCalmControllerBase
    {
        private readonly IAdministratorLogicAdapter administratorDomainToModelAdapter;
        public AdministratorController(IAdministratorLogicAdapter administratorDomainToModelAdapter)
        {
            this.administratorDomainToModelAdapter = administratorDomainToModelAdapter;
        }

        [ServiceFilter(typeof(AuthorizationAttributeFilter))]
        [HttpGet("{id}", Name = "GetAdministratorsById")]
        public IActionResult GetById(int administratorId)
        {
            AdministratorBasicInfoModel administrator = administratorDomainToModelAdapter.GetById(administratorId);
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
        [HttpDelete("{administratorId}")]
        public IActionResult DeleteById(int administratorId)
        {
            administratorDomainToModelAdapter.Delete(administratorId);
            return NoContent();
        }

        [ServiceFilter(typeof(AuthorizationAttributeFilter))]
        [HttpPut]
        public IActionResult Update([FromBody] AdministratorModel administratorModel)
        {
            administratorDomainToModelAdapter.Update(administratorModel);
            return NoContent();
        }
    }
}
