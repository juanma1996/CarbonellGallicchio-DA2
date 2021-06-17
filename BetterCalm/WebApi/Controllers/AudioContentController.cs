using AdapterInterface;
using BetterCalm.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Model.In;
using Model.Out;
using System.Collections.Generic;
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
        /// Obtains the information of an audio content by the id given.
        /// </summary>
        /// <remarks>
        /// Obtains an audio content related by the id given.
        /// </remarks>
        /// <response code="200">Success. Returns the requested object.</response>  
        /// <response code="404">NotFound. Audio content not exist for the given data.</response>
        /// <response code="500">InternalServerError. Server problems, unexpected error.</response>
        [HttpGet("{id}", Name = "GetAudioContentById")]
        public IActionResult Get(int id)
        {
            return Ok(audioContentLogicAdapter.GetById(id));
        }

        // POST: 
        /// <summary>
        /// Creates an audio content.
        /// </summary>
        /// <remarks>
        /// Creates the audio content send in the body. An administrator token is required.
        /// </remarks>
        /// <response code="201">Created.</response>
        /// <response code="401">Unauthorized. Must contain a token to access Api.</response>
        /// <response code="400">Error. The audio content name can't be empty.</response>
        /// <response code="400">Error. The audio content must contain a playlist.</response>
        /// <response code="400">Error. The audio content must contain a category.</response>
        /// <response code="403">Unauthorized. Forbidden, ask for permission.</response>
        /// <response code="500">InternalServerError. Server problems, unexpected error.</response>
        [ServiceFilter(typeof(AuthorizationFilter))]
        [HttpPost]
        public IActionResult Post([FromBody] AudioContentModel audioContentModel)
        {
            AudioContentBasicInfoModel audioContentCreated = audioContentLogicAdapter.Add(audioContentModel);
            return CreatedAtRoute("GetAudioContentById", new { id = audioContentCreated.Id }, audioContentCreated);
        }

        // DELETE: 
        /// <summary>
        /// Deletes an audio content.
        /// </summary>
        /// <remarks>
        /// Deletes the audio content with the id given. An administrator token is required.
        /// </remarks>
        /// <response code="204">No content.</response>
        /// <response code="401">Unauthorized. Must contain a token to access Api.</response>
        /// <response code="403">Unauthorized. Forbidden, ask for permission.</response>
        /// <response code="404">NotFound. Audio content not exist for the given data.</response>
        /// <response code="500">InternalServerError. Server problems, unexpected error.</response>
        [ServiceFilter(typeof(AuthorizationFilter))]
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
        /// Updates the audio content with the content send in the body. An administrator token is required.
        /// </remarks>
        /// <response code="204">No content.</response>
        /// <response code="401">Unauthorized. Must contain a token to access Api.</response>
        /// <response code="403">Unauthorized. Forbidden, ask for permission.</response>
        /// <response code="400">Error. The audio content name can't be empty.</response>
        /// <response code="400">Error. The audio content must contain a playlist.</response>
        /// <response code="400">Error. The audio content must contain a category.</response>
        /// <response code="404">NotFound. There is no audio content registered for the given data.</response>
        /// <response code="500">InternalServerError. Server problems, unexpected error.</response>
        [ServiceFilter(typeof(AuthorizationFilter))]
        [HttpPut("{id}")]
        public IActionResult Put(int id, AudioContentModel audioContentModel)
        {
            audioContentLogicAdapter.Update(id, audioContentModel);
            return NoContent();
        }

        // GET: 
        /// <summary>
        /// Obtains all existing audio contents for a given category.
        /// </summary>
        /// <remarks>
        /// Obtains all existing audio contents for a given category. An existing category id is required.
        /// </remarks>
        /// <response code="200">Success. Returns the requested object.</response>  
        /// <response code="404">NotFound. There is no category registered for the given data.</response>
        /// <response code="500">InternalServerError. Server problems, unexpected error.</response>
        [Route("categories/{id}")]
        [HttpGet]
        public IActionResult GetAudioContentByCategory([FromRoute] int id)
        {
            List<AudioContentBasicInfoModel> audioContents = audioContentLogicAdapter.GetByCategoryId(id);
            return Ok(audioContents);
        }

        // GET: 
        /// <summary>
        /// Obtains all existing audio contents for a given playlist.
        /// </summary>
        /// <remarks>
        /// Obtains all existing audio contents for a given playlist. An existing playlist id is required.
        /// </remarks>
        /// <response code="200">Success. Returns the requested object.</response>  
        /// <response code="404">NotFound. There is no playlist registered for the given data.</response>
        /// <response code="500">InternalServerError. Server problems, unexpected error.</response>
        [Route("playlists/{id}")]
        [HttpGet]
        public IActionResult GetAudioContentByPlaylist([FromRoute] int id)
        {
            List<AudioContentBasicInfoModel> audioContents = audioContentLogicAdapter.GetByPlaylistId(id);
            return Ok(audioContents);
        }

        // GET: 
        /// <summary>
        /// Obtains the information of all existing audio contents.
        /// </summary>
        /// <remarks>
        /// Obtains the information of all existing audio contents.
        /// </remarks>
        /// <response code="200">Success. Returns the requested object.</response>  
        /// <response code="500">InternalServerError. Server problems, unexpected error.</response>
        [HttpGet]
        public IActionResult Get()
        {
            List<AudioContentBasicInfoModel> audioContents = audioContentLogicAdapter.GetAll();
            return Ok(audioContents);
        }
    }
}