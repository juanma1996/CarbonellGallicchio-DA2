using AdapterInterface;
using BetterCalm.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Model.In;
using Model.Out;

namespace WebApi.Controllers
{
    [Route("api/consultations")]
    public class ConsultationController : BetterCalmControllerBase
    {
        private readonly IConsultationLogicAdapter consultationDomainToModelAdapter;
        public ConsultationController(IConsultationLogicAdapter consultationDomainToModelAdapter)
        {
            this.consultationDomainToModelAdapter = consultationDomainToModelAdapter;
        }

        // POST: 
        /// <summary>
        /// Creates a consultation with a psychologist.
        /// </summary>
        /// <remarks>
        /// Creates a consultation with a psychologist. It will return the information of the psychologist and the direction or the link if it's virtual.
        /// </remarks>
        /// <response code="201">Created. Returns the information of the psychologist and the direction or the link if it's virtual</response>
        /// <response code="404">Not found. There is no psychologist registered for the given data.</response>
        /// <response code="500">InternalServerError. Server problems, unexpected error.</response>
        [HttpPost]
        public IActionResult Post(ConsultationModel consultationModel)
        {
            PsychologistBasicInfoModel psychologist = consultationDomainToModelAdapter.Add(consultationModel);
            return CreatedAtRoute("", psychologist);
        }
    }
}
