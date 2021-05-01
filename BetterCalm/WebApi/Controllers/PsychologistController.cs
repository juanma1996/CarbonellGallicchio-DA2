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
    public class PsychologistController : BetterCalmControllerBase
    {
        private readonly IPsychologistLogicAdapter psychologistDomainToModelAdapter;
        public PsychologistController(IPsychologistLogicAdapter psychologistDomainToModelAdapter)
        {
            this.psychologistDomainToModelAdapter = psychologistDomainToModelAdapter;
        }

        [HttpGet("{id}", Name = "GetPsychologistById")]
        public IActionResult GetById(int psychologistId)
        {
            try
            {
                PsychologistBasicInfoModel psychologist = psychologistDomainToModelAdapter.GetById(psychologistId);
                return Ok(psychologist);
            }
            catch (NullObjectMappingException e)
            {
                return NotFound(e);
            }
        }
        [ServiceFilter(typeof(AuthorizationAttributeFilter))]
        [HttpPost]
        public IActionResult Post(PsychologistModel psycologistIn)
        {
            try
            {
                var psychologistCreated = psychologistDomainToModelAdapter.Add(psycologistIn);
                return CreatedAtRoute("GetPsychologistById", psychologistCreated.Id, psychologistCreated);
            }
            catch (ArgumentException e)
            {
                return this.BadRequest(e.Message);
            }
            catch (AmountOfProblematicsException e)
            {
                return this.BadRequest(e.Message);
            }
        }
        [ServiceFilter(typeof(AuthorizationAttributeFilter))]
        [HttpDelete("{id}")]
        public IActionResult DeleteById(int psychologistId)
        {
            try
            {
                psychologistDomainToModelAdapter.Delete(psychologistId);
                return NoContent();
            }
            catch (ArgumentException e)
            {
                return NotFound(e);
            }
        }
        [ServiceFilter(typeof(AuthorizationAttributeFilter))]
        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int psychologistId, [FromBody] PsychologistModel psychologistModel)
        {
            try
            {
                psychologistDomainToModelAdapter.Update(psychologistId, psychologistModel);
                return NoContent();
            }
            catch (ArgumentException e)
            {
                return this.BadRequest(e.Message);
            }
            catch (AmountOfProblematicsException e)
            {
                return this.BadRequest(e.Message);
            }
            catch (NullObjectMappingException e)
            {
                return NotFound(e);
            }
        }
    }
}
