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

        public object Post(VideoContentModel audioContentModel)
        {
            VideoContentBasicInfoModel videoContentCreated = videoContentLogicAdapter.Add(audioContentModel);
            return CreatedAtRoute("GetVideoContentById", new { id = videoContentCreated.Id }, videoContentCreated);
        }
    }
}
