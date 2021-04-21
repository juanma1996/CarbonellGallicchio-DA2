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

        [HttpGet("{Id}/")]
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

        public object Post(PsychologistModel psycologistIn)
        {
            throw new NotImplementedException();
        }
    }
}
