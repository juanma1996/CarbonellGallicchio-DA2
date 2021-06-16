using AdapterInterface;
using BetterCalm.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Model.In;
using Model.Out;
using System;
using System.Collections.Generic;
using WebApi.Filters;

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
        /// Obtains the information of all existing pacient with generated bonus. An administrator token is required.
        /// </remarks>
        /// <response code="200">Success. Returns the requested object.</response>  
        /// <response code="500">InternalServerError. Server problems, unexpected error.</response>
        [ServiceFilter(typeof(AuthorizationFilter))]
        [HttpGet]
        public IActionResult Get()
        {
            List<BonusBasicInfoModel> bonuses = bonusLogicAdapter.GetAll();
            return Ok(bonuses);
        }

        // UPDATE: 
        /// <summary>
        /// Updates an generated bonus for a pacient.
        /// </summary>
        /// <remarks>
        /// Updates an generated bonus for a pacient send in the body. An administrator token is required.
        /// </remarks>
        /// <response code="204">No content.</response>
        /// <response code="401">Unauthorized. Must contain a token to access Api.</response>
        /// <response code="403">Unauthorized. Forbidden, ask for permission.</response>
        /// <response code="400">Error. The bonus amount value is invalid.</response>
        /// <response code="404">NotFound. There is no pacient registered for the given data.</response>
        /// <response code="500">InternalServerError. Server problems, unexpected error.</response>
        [ServiceFilter(typeof(AuthorizationFilter))]
        [HttpPut("{id}")]
        public IActionResult Update(int id, BonusModel bonus)
        {
            bonusLogicAdapter.Update(id, bonus);
            return NoContent();
        }
    }
}
