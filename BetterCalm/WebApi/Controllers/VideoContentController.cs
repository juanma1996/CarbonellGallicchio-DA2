using AdapterInterface;
using BetterCalm.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Model.In;
using Model.Out;
using System;

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

        [HttpGet("{id}", Name = "GetVideoContentById")]
        public IActionResult Get(int videoContentId)
        {
            return Ok(videoContentLogicAdapter.GetById(videoContentId));
        }

        [HttpPost]
        public IActionResult Post([FromBody] VideoContentModel audioContentModel)
        {
            VideoContentBasicInfoModel videoContentCreated = videoContentLogicAdapter.Add(audioContentModel);
            return CreatedAtRoute("GetVideoContentById", new { id = videoContentCreated.Id }, videoContentCreated);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int videoContentId)
        {
            videoContentLogicAdapter.DeleteById(videoContentId);
            return NoContent();
        }

        public object Put(VideoContentModel videoContentModel)
        {
            videoContentLogicAdapter.Update(videoContentModel);
            return NoContent();
        }
    }
}
