using System;
using AdapterInterface;
using BetterCalm.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
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
            PsychologistBasicInfoModel psychologist = psychologistDomainToModelAdapter.GetById(psychologistId);
            return Ok(psychologist);
        }
    }
}
