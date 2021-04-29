using System;
using AdapterInterface;
using BetterCalm.WebApi.Controllers;

namespace WebApi.Controllers
{
    public class AdministratorController : BetterCalmControllerBase
    {
        private readonly IAdministratorLogicAdapter administratorDomainToModelAdapter;
        public AdministratorController(IAdministratorLogicAdapter administratorDomainToModelAdapter)
        {
            this.administratorDomainToModelAdapter = administratorDomainToModelAdapter;
        }

        public object GetById(int administratorId)
        {
            throw new NotImplementedException();
        }
    }
}
