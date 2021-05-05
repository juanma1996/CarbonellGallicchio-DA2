using AdapterExceptions;
using AdapterInterface;
using BetterCalm.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Model.In;
using WebApi.Filters;

namespace WebApi.Controllers
{
    [Route("api/audioContents")]
    public class AudioContentController : BetterCalmControllerBase
    {
        private readonly IAudioContentLogicAdapter audioContentLogicAdapter;

        public AudioContentController(IAudioContentLogicAdapter audioContentLogicAdapter)
        {
            this.audioContentLogicAdapter = audioContentLogicAdapter;
        }

        // GET: 
        /// <summary>
        /// Obtains an audio content by the id given.
        /// </summary>
        /// <param name="Token">Here is the description for ID.</param>
        /// <remarks>
        /// Obtains an audio content by the id given.
        /// </remarks>
        /// <response code="200">Success. Returns the requested object.</response>  
        /// <response code="401">Unauthorized. Must contain a token to access Api.</response>
        /// <response code="403">Unauthorized. Forbidden, ask for permission.</response>
        /// <response code="404">NotFound. There is no administrator registered for the given data.</response>
        /// <response code="500">InternalServerError. Server problems, unexpected error.</response>
        [HttpGet("{id}", Name = "GetAudioContentById")]
        public IActionResult Get(int audioContentId)
        {
            return Ok(audioContentLogicAdapter.GetById(audioContentId));
        }

        // POST: 
        /// <summary>
        /// Creates an audio content.
        /// </summary>
        /// <remarks>
        /// Creates an audio content send on the body.
        /// </remarks>
        /// <response code="201">Created.</response>
        /// <response code="401">Unauthorized. Must contain a token to access Api.</response>
        /// <response code="400">Error. The audio content name can't be empty.</response>
        /// <response code="400">Error. The audio content must contain a playlist.</response>
        /// <response code="400">Error. The audio content must contain a category.</response>
        /// <response code="403">Unauthorized. Forbidden, ask for permission.</response>
        /// <response code="500">InternalServerError. Server problems, unexpected error.</response>
        [ServiceFilter(typeof(AuthorizationAttributeFilter))]
        [HttpPost]
        public IActionResult Post([FromBody] AudioContentModel audioContentModel)
        {
            var audioContentCreated = audioContentLogicAdapter.Add(audioContentModel);
            return CreatedAtRoute("GetAudioContentById", audioContentCreated.Id, audioContentCreated);
        }

        // DELETE: 
        /// <summary>
        /// Deletes an audio content.
        /// </summary>
        /// <remarks>
        /// Deletes the audio content with the id given.
        /// </remarks>
        /// <response code="204">No content.</response>
        /// <response code="401">Unauthorized. Must contain a token to access Api.</response>
        /// <response code="403">Unauthorized. Forbidden, ask for permission.</response>
        /// <response code="404">NotFound. Audio content not exist for the given data.</response>
        /// <response code="500">InternalServerError. Server problems, unexpected error.</response>
        [ServiceFilter(typeof(AuthorizationAttributeFilter))]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            audioContentLogicAdapter.DeleteById(id);
            return NoContent();
        }

        // UPDATE: 
        /// <summary>
        /// Updates an audio content.
        /// </summary>
        /// <remarks>
        /// Updates the audio content with the id given.
        /// </remarks>
        /// <response code="204">No content.</response>
        /// <response code="401">Unauthorized. Must contain a token to access Api.</response>
        /// <response code="403">Unauthorized. Forbidden, ask for permission.</response>
        /// <response code="400">Error. The audio content name can't be empty.</response>
        /// <response code="400">Error. The audio content must contain a playlist.</response>
        /// <response code="400">Error. The audio content must contain a category.</response>
        /// <response code="404">NotFound. There is no administrator registered for the given data.</response>
        /// <response code="500">InternalServerError. Server problems, unexpected error.</response>
        [ServiceFilter(typeof(AuthorizationAttributeFilter))]
        [HttpPut]
        public IActionResult Put(AudioContentModel audioContentModel)
        {
            audioContentLogicAdapter.Update(audioContentModel);
            return NoContent();
        }
    }
}