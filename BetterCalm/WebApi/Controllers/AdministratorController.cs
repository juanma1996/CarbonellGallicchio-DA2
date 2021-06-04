using AdapterInterface;
using BetterCalm.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Model.In;
using Model.Out;
using System;
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
        /// Obtains the information of an administrator by the id given.
        /// </summary>
        /// <remarks>
        /// Obtains an administrator by the id given. An administrator token is required.
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
        /// Creates the administrator with the information send in the body. An administrator token is required.
        /// </remarks>
        /// <response code="201">Created.</response>
        /// <response code="401">Unauthorized. Must contain a token to access Api.</response>
        /// <response code="400">Error. There is an administrator registered for the given data.</response>
        /// <response code="400">Error. The administrator's name can't be empty.</response>
        /// <response code="400">Error. The administrator's email can't be empty.</response>
        /// <response code="400">Error. The administrator's password can't be empty.</response>
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
        /// Deletes the administrator with the id given. An administrator token is required.
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
        /// Updates an administrator with the information send in the body. An administrator token is required.
        /// </remarks>
        /// <response code="204">No content.</response>
        /// <response code="400">Error. The administrator's name can't be empty.</response>
        /// <response code="400">Error. The administrator's email can't be empty.</response>
        /// <response code="400">Error. The administrator's password can't be empty.</response>
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

        public object Get()
        {
            throw new NotImplementedException();
        }
    }
}
