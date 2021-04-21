using System;
using AdapterExceptions;
using AdapterInterface;
using BetterCalm.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Model.In;
using Model.Out;

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

        [HttpPost]
        public IActionResult Post(PsychologistModel psycologistIn)
        {
            var psychologistCreated = psychologistDomainToModelAdapter.Add(psycologistIn);
            return CreatedAtRoute("GetPsychologistById", psychologistCreated.Id, psychologistCreated);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int psychologistId)
        {
            psychologistDomainToModelAdapter.Delete(psychologistId);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute]int psychologistId,[FromBody] PsychologistModel psychologistModel)
        {
            psychologistDomainToModelAdapter.Update(psychologistId, psychologistModel);
            return NoContent();
        }
    }
}
