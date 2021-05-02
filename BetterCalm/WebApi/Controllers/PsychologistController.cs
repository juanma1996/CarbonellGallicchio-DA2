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
            PsychologistBasicInfoModel psychologist = psychologistDomainToModelAdapter.GetById(psychologistId);
            return Ok(psychologist);
        }
        [ServiceFilter(typeof(AuthorizationAttributeFilter))]
        [HttpPost]
        public IActionResult Post(PsychologistModel psycologistIn)
        {
            var psychologistCreated = psychologistDomainToModelAdapter.Add(psycologistIn);
            return CreatedAtRoute("GetPsychologistById", psychologistCreated.Id, psychologistCreated);
        }
        [ServiceFilter(typeof(AuthorizationAttributeFilter))]
        [HttpDelete("{id}")]
        public IActionResult DeleteById(int psychologistId)
        {
            psychologistDomainToModelAdapter.Delete(psychologistId);
            return NoContent();
        }
        [ServiceFilter(typeof(AuthorizationAttributeFilter))]
        [HttpPut]
        public IActionResult Update([FromBody] PsychologistModel psychologistModel)
        {
            psychologistDomainToModelAdapter.Update(psychologistModel);
            return NoContent();
        }
    }
}
