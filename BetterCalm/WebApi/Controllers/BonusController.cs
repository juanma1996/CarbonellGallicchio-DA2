using AdapterInterface;
using BetterCalm.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Model.Out;
using System;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [Route("api/bonuses")]
    public class BonusController : BetterCalmControllerBase
    {
        private readonly IBonusLogicAdapter bonusLogicAdapter;

        public BonusController(IBonusLogicAdapter bonusLogicAdapter)
        {
            this.bonusLogicAdapter = bonusLogicAdapter;
        }

        // GET: 
        /// <summary>
        /// Obtains the information of all existing pacient with generated bonus.
        /// </summary>
        /// <remarks>
        /// Obtains the information of all existing pacient with generated bonus.
        /// </remarks>
        /// <response code="200">Success. Returns the requested object.</response>  
        /// <response code="500">InternalServerError. Server problems, unexpected error.</response>
        [HttpGet]
        public IActionResult Get()
        {
            List<BonusBasicInfoModel> bonuses = bonusLogicAdapter.GetAll();
            return Ok(bonuses);
        }

        public object Update()
        {
            throw new NotImplementedException();
        }
    }
}
