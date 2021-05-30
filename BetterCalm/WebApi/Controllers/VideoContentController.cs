using AdapterInterface;
using BetterCalm.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebApi.Controllers
{
    [Route("api/videoContents")]
    public class VideoContentController : BetterCalmControllerBase
    {
        private readonly IVideoContentLogicAdapter videooContentLogicAdapter;

        public VideoContentController(IVideoContentLogicAdapter videooContentLogicAdapter)
        {
            this.videooContentLogicAdapter = videooContentLogicAdapter;
        }

        [HttpGet("{id}", Name = "GetVideoContentById")]
        public IActionResult Get(int videoContentId)
        {
            return Ok(videooContentLogicAdapter.GetById(videoContentId));
        }

        public object Post(int videoContentId)
        {
            throw new NotImplementedException();
        }
    }
}
