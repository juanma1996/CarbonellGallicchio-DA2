using System;
using AdapterInterface;
using BetterCalm.WebApi.Controllers;

namespace WebApi.Controllers
{
    public class PsychologistController : BetterCalmControllerBase
    {
        private readonly IPsychologistLogicAdapter psychologistDomainToModelAdapter;
        public PsychologistController(IPsychologistLogicAdapter psychologistDomainToModelAdapter)
        {
            this.psychologistDomainToModelAdapter = psychologistDomainToModelAdapter;
        }

        public object GetById(int psychologistId)
        {
            throw new NotImplementedException();
        }
    }
}
