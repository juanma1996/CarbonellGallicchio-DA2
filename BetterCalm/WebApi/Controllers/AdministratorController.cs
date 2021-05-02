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

        [HttpGet("{id}", Name = "GetAdministratorsById")]
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

        [HttpPost]
        public IActionResult Post([FromBody]AdministratorModel administratorModel)
        {
            try
            {
                administratorDomainToModelAdapter.Add(administratorModel);
                return NoContent();
            }
            catch (ArgumentInvalidMappingException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{administratorId}")]
        public IActionResult DeleteById(int administratorId)
        {
            try
            {
                administratorDomainToModelAdapter.Delete(administratorId);
                return NoContent();
            }
            catch (ArgumentInvalidMappingException e)
            {
                return NotFound(e);
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody]AdministratorModel administratorModel)
        {
            try
            {
                administratorDomainToModelAdapter.Update(administratorModel);
                return NoContent();
            }
            catch (ArgumentInvalidMappingException e)
            {
                return BadRequest(e.Message);
            }
            catch (NullObjectMappingException e)
            {
                return NotFound(e);
            }
        }
    }
}
