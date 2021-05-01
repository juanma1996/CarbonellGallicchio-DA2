using System;
using AdapterExceptions;
using AdapterInterface;
using BetterCalm.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Model.In;
using Model.Out;

namespace WebApi.Controllers
{
    public class AdministratorController : BetterCalmControllerBase
    {
        private readonly IAdministratorLogicAdapter administratorDomainToModelAdapter;
        public AdministratorController(IAdministratorLogicAdapter administratorDomainToModelAdapter)
        {
            this.administratorDomainToModelAdapter = administratorDomainToModelAdapter;
        }

        public IActionResult GetById(int administratorId)
        {
            try
            {
                AdministratorBasicInfoModel administrator = administratorDomainToModelAdapter.GetById(administratorId);
                return Ok(administrator);
            }
            catch (NullObjectMappingException e)
            {
                return NotFound(e);
            }
        }

        public IActionResult Post(AdministratorModel administratorModel)
        {
            try
            {
                administratorDomainToModelAdapter.Add(administratorModel);
                return NoContent();
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }

        public IActionResult DeleteById(int administratorId)
        {
            administratorDomainToModelAdapter.Delete(administratorId);
            return NoContent();
        }

        public IActionResult Update(AdministratorModel administratorModel)
        {
            administratorDomainToModelAdapter.Update(administratorModel);
            return NoContent();
        }
    }
}
