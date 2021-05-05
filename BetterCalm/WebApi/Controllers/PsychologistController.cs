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
    [Route("api/psychologists")]
    public class PsychologistController : BetterCalmControllerBase
    {
        private readonly IPsychologistLogicAdapter psychologistDomainToModelAdapter;
        public PsychologistController(IPsychologistLogicAdapter psychologistDomainToModelAdapter)
        {
            this.psychologistDomainToModelAdapter = psychologistDomainToModelAdapter;
        }

        // GET: 
        /// <summary>
        /// Obtains the information of a psychologist by the id given.
        /// </summary>
        /// <remarks>
        /// Obtains the information of a psychologist by the id give.
        /// </remarks>
        /// <response code="200">Success. Returns the psychologist information.</response>  
        /// <response code="404">NotFound. There is no psychologist registered for the given data.</response>
        /// <response code="500">InternalServerError. Server problems, unexpected error.</response>
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            PsychologistBasicInfoModel psychologist = psychologistDomainToModelAdapter.GetById(id);
            return Ok(psychologist);
        }

        // POST: 
        /// <summary>
        /// Creates a psychologist.
        /// </summary>
        /// <remarks>
        /// Creates the psychologist with the information send in the body. An administrator token is required.
        /// </remarks>
        /// <response code="201">Created. Returns the psychologist created.</response>
        /// <response code="400">Error. The psychologist's name can't be empty.</response>
        /// <response code="400">Error. The psychologist's consultation mode can't be empty.</response>
        /// <response code="400">Error. The psychologist's direction can't be empty.</response>
        /// <response code="400">Error. The psychologist's problematics can't be zero.</response>
        /// <response code="401">Unauthorized. Must contain a token to access Api.</response>
        /// <response code="403">Unauthorized. Forbidden, ask for permission.</response>
        /// <response code="500">InternalServerError. Server problems, unexpected error.</response>
        [ServiceFilter(typeof(AuthorizationAttributeFilter))]
        [HttpPost]
        public IActionResult Post(PsychologistModel psycologistIn)
        {
            var psychologistCreated = psychologistDomainToModelAdapter.Add(psycologistIn);
            return CreatedAtRoute("Get", new { id = psychologistCreated.Id }, psychologistCreated);
        }

        // DELETE: 
        /// <summary>
        /// Deletes a psychologist.
        /// </summary>
        /// <remarks>
        /// Deletes the psychologist with the id given. An administrator token is required.
        /// </remarks>
        /// <response code="204">No content.</response>
        /// <response code="401">Unauthorized. Must contain a token to access Api.</response>
        /// <response code="403">Unauthorized. Forbidden, ask for permission.</response>
        /// <response code="404">NotFound. There is no psychologist registered for the given data.</response>
        /// <response code="500">InternalServerError. Server problems, unexpected error.</response>
        [ServiceFilter(typeof(AuthorizationAttributeFilter))]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            psychologistDomainToModelAdapter.Delete(id);
            return NoContent();
        }

        // PUT: 
        /// <summary>
        /// Updates a psychologist.
        /// </summary>
        /// <remarks>
        /// Updates a psychologist with the information send in the body. An administrator token is required.
        /// </remarks>
        /// <response code="204">No content.</response>
        /// <response code="400">Error. The psychologist's name can't be empty.</response>
        /// <response code="400">Error. The psychologist's consultation mode can't be empty.</response>
        /// <response code="400">Error. The psychologist's direction can't be empty.</response>
        /// <response code="400">Error. The psychologist's problematics can't be zero.</response>
        /// <response code="401">Unauthorized. Must contain a token to access Api.</response>
        /// <response code="403">Unauthorized. Forbidden, ask for permission.</response>
        /// <response code="404">NotFound. There is no psychologist registered for the given data.</response>
        /// <response code="500">InternalServerError. Server problems, unexpected error.</response>
        [ServiceFilter(typeof(AuthorizationAttributeFilter))]
        [HttpPut]
        public IActionResult Put([FromBody] PsychologistModel psychologistModel)
        {
            psychologistDomainToModelAdapter.Update(psychologistModel);
            return NoContent();
        }
    }
}
