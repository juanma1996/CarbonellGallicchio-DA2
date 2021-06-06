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
    [Route("api/videoContents")]
    public class VideoContentController : BetterCalmControllerBase
    {
        private readonly IVideoContentLogicAdapter videoContentLogicAdapter;

        public VideoContentController(IVideoContentLogicAdapter videoContentLogicAdapter)
        {
            this.videoContentLogicAdapter = videoContentLogicAdapter;
        }

        // GET: 
        /// <summary>
        /// Obtains the information of an video content by the id given.
        /// </summary>
        /// <remarks>
        /// Obtains an video content related by the id given.
        /// </remarks>
        /// <response code="200">Success. Returns the requested object.</response>  
        /// <response code="404">NotFound. Video content not exist for the given data.</response>
        /// <response code="500">InternalServerError. Server problems, unexpected error.</response>
        [HttpGet("{id}", Name = "GetVideoContentById")]
        public IActionResult Get(int videoContentId)
        {
            return Ok(videoContentLogicAdapter.GetById(videoContentId));
        }

        // POST: 
        /// <summary>
        /// Creates an video content.
        /// </summary>
        /// <remarks>
        /// Creates the video content send in the body. An administrator token is required.
        /// </remarks>
        /// <response code="201">Created.</response>
        /// <response code="401">Unauthorized. Must contain a token to access Api.</response>
        /// <response code="400">Error. The video content name can't be empty.</response>
        /// <response code="400">Error. The video content must contain a playlist.</response>
        /// <response code="400">Error. The video content must contain a category.</response>
        /// <response code="403">Unauthorized. Forbidden, ask for permission.</response>
        /// <response code="500">InternalServerError. Server problems, unexpected error.</response>
        [ServiceFilter(typeof(AuthorizationAttributeFilter))]
        [HttpPost]
        public IActionResult Post([FromBody] VideoContentModel audioContentModel)
        {
            VideoContentBasicInfoModel videoContentCreated = videoContentLogicAdapter.Add(audioContentModel);
            return CreatedAtRoute("GetVideoContentById", new { id = videoContentCreated.Id }, videoContentCreated);
        }

        // DELETE: 
        /// <summary>
        /// Deletes an video content.
        /// </summary>
        /// <remarks>
        /// Deletes the video content with the id given. An administrator token is required.
        /// </remarks>
        /// <response code="204">No content.</response>
        /// <response code="401">Unauthorized. Must contain a token to access Api.</response>
        /// <response code="403">Unauthorized. Forbidden, ask for permission.</response>
        /// <response code="404">NotFound. Video content not exist for the given data.</response>
        /// <response code="500">InternalServerError. Server problems, unexpected error.</response>
        [ServiceFilter(typeof(AuthorizationAttributeFilter))]
        [HttpDelete("{id}")]
        public IActionResult Delete(int videoContentId)
        {
            videoContentLogicAdapter.DeleteById(videoContentId);
            return NoContent();
        }

        // UPDATE: 
        /// <summary>
        /// Updates an video content.
        /// </summary>
        /// <remarks>
        /// Updates the video content with the content send in the body. An administrator token is required.
        /// </remarks>
        /// <response code="204">No content.</response>
        /// <response code="401">Unauthorized. Must contain a token to access Api.</response>
        /// <response code="403">Unauthorized. Forbidden, ask for permission.</response>
        /// <response code="400">Error. The video content name can't be empty.</response>
        /// <response code="400">Error. The video content must contain a playlist.</response>
        /// <response code="400">Error. The video content must contain a category.</response>
        /// <response code="404">NotFound. There is no video registered for the given data.</response>
        /// <response code="500">InternalServerError. Server problems, unexpected error.</response>
        [ServiceFilter(typeof(AuthorizationAttributeFilter))]
        [HttpPut]
        public IActionResult Put(VideoContentModel videoContentModel)
        {
            videoContentLogicAdapter.Update(videoContentModel);
            return NoContent();
        }

        // GET: 
        /// <summary>
        /// Obtains all existing video contents for a given category.
        /// </summary>
        /// <remarks>
        /// Obtains all existing video contents for a given category. An existing category id is required.
        /// </remarks>
        /// <response code="200">Success. Returns the requested object.</response>  
        /// <response code="404">NotFound. There is no category registered for the given data.</response>
        /// <response code="500">InternalServerError. Server problems, unexpected error.</response>
        [Route("categories/{id}")]
        [HttpGet]
        public IActionResult GetVideoContentByCategory([FromRoute] int id)
        {
            List<VideoContentBasicInfoModel> videoContents = videoContentLogicAdapter.GetByCategoryId(id);
            return Ok(videoContents);
        }

        // GET: 
        /// <summary>
        /// Obtains all existing video contents for a given playlist.
        /// </summary>
        /// <remarks>
        /// Obtains all existing video contents for a given playlist. An existing playlist id is required.
        /// </remarks>
        /// <response code="200">Success. Returns the requested object.</response>  
        /// <response code="404">NotFound. There is no playlist registered for the given data.</response>
        /// <response code="500">InternalServerError. Server problems, unexpected error.</response>
        [Route("playlists/{id}")]
        [HttpGet]
        public IActionResult GetVideoContentByPlaylist([FromRoute] int id)
        {
            List<VideoContentBasicInfoModel> videoContents = videoContentLogicAdapter.GetByPlaylistId(id);
            return Ok(videoContents);
        }
    }
}
