using System;
using AdapterInterface;
using BetterCalm.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Model.In;

namespace WebApi.Controllers
{
    public class AdministratorController : BetterCalmControllerBase
    {
        private readonly IAdministratorLogicAdapter administratorDomainToModelAdapter;
        public AdministratorController(IAdministratorLogicAdapter administratorDomainToModelAdapter)
        {
            this.administratorDomainToModelAdapter = administratorDomainToModelAdapter;
        }

        public IActionResult GetById(int administratorId)
        {
            return Ok(administratorDomainToModelAdapter.GetById(administratorId));
        }

        public object Post(AdministratorModel administratorModel)
        {
            administratorDomainToModelAdapter.Add(administratorModel);
            return NoContent();
        }
    }
}
