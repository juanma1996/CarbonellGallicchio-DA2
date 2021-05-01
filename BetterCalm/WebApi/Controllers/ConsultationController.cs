using System;
using AdapterInterface;
using BetterCalm.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Model.In;
using Model.Out;

namespace WebApi.Controllers
{
    public class ConsultationController : BetterCalmControllerBase
    {
        private readonly IConsultationLogicAdapter consultationDomainToModelAdapter;
        public ConsultationController(IConsultationLogicAdapter consultationDomainToModelAdapter)
        {
            this.consultationDomainToModelAdapter = consultationDomainToModelAdapter;
        }

        public IActionResult Post(ConsultationModel consultationModel)
        {
            PsychologistBasicInfoModel psychologist = consultationDomainToModelAdapter.Add(consultationModel);
            return CreatedAtRoute("", psychologist);
        }
    }
}
