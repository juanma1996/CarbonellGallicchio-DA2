using System;
using AdapterExceptions;
using AdapterInterface;
using BetterCalm.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Model.In;
using Model.Out;
using WebApi.Filters;

namespace WebApi.Controllers
{
    [Route("api/administrators")]
    public class AdministratorController : BetterCalmControllerBase
    {
        private readonly IAdministratorLogicAdapter administratorDomainToModelAdapter;
        public AdministratorController(IAdministratorLogicAdapter administratorDomainToModelAdapter)
        {
            this.administratorDomainToModelAdapter = administratorDomainToModelAdapter;
        }

        // GET: 
        /// <summary>
        /// Obtains an administrator by the id given.
        /// </summary>
        /// <param name="Token">Here is the description for ID.</param>
        /// <remarks>
        /// Obtains an administrator by the id given.
        /// </remarks>
        /// <response code="200">Success. Returns the requested object.</response>  
        /// <response code="401">Unauthorized. Must contain a token to access Api.</response>
        /// <response code="403">Unauthorized. Forbidden, ask for permission.</response>
        /// <response code="404">NotFound. There is no administrator registered for the given data.</response>
        /// <response code="500">InternalServerError. Server problems, unexpected error.</response>
        [ServiceFilter(typeof(AuthorizationAttributeFilter))]
        [HttpGet("{id}", Name = "GetAdministrator")]
        public IActionResult Get(int id)
        {
            AdministratorBasicInfoModel administrator = administratorDomainToModelAdapter.GetById(id);
            return Ok(administrator);
        }

        // POST: 
        /// <summary>
        /// Creates an administrator.
        /// </summary>
        /// <remarks>
        /// Creates the administrator send on the body.
        /// </remarks>
        /// <response code="201">Created.</response>
        /// <response code="401">Unauthorized. Must contain a token to access Api.</response>
        /// <response code="400">Error. There is an administrator registered for the given data.</response>
        /// <response code="403">Unauthorized. Forbidden, ask for permission.</response>
        /// <response code="500">InternalServerError. Server problems, unexpected error.</response>
        [ServiceFilter(typeof(AuthorizationAttributeFilter))]
        [HttpPost]
        public IActionResult Post([FromBody] AdministratorModel administratorModel)
        {
            administratorDomainToModelAdapter.Add(administratorModel);
            return NoContent();
        }

        // DELETE: 
        /// <summary>
        /// Deletes an administrator.
        /// </summary>
        /// <remarks>
        /// Deletes the administrator with the id given.
        /// </remarks>
        /// <response code="204">No content.</response>
        /// <response code="401">Unauthorized. Must contain a token to access Api.</response>
        /// <response code="403">Unauthorized. Forbidden, ask for permission.</response>
        /// <response code="404">NotFound. There is no administrator registered for the given data.</response>
        /// <response code="500">InternalServerError. Server problems, unexpected error.</response>
        [ServiceFilter(typeof(AuthorizationAttributeFilter))]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            administratorDomainToModelAdapter.Delete(id);
            return NoContent();
        }

        // PUT: 
        /// <summary>
        /// Updates an administrator.
        /// </summary>
        /// <remarks>
        /// Updates the administrator with the id given.
        /// </remarks>
        /// <response code="204">No content.</response>
        /// <response code="401">Unauthorized. Must contain a token to access Api.</response>
        /// <response code="403">Unauthorized. Forbidden, ask for permission.</response>
        /// <response code="404">NotFound. There is no administrator registered for the given data.</response>
        /// <response code="500">InternalServerError. Server problems, unexpected error.</response>
        [ServiceFilter(typeof(AuthorizationAttributeFilter))]
        [HttpPut]
        public IActionResult Put([FromBody]AdministratorModel administratorModel)
        {
            administratorDomainToModelAdapter.Update(administratorModel);
            return NoContent();
        }
    }
}
