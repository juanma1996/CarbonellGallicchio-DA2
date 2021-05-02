using AdapterExceptions;
using AdapterInterface;
using BetterCalm.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Model.In;
using WebApi.Filters;

namespace WebApi.Controllers
{
    public class AudioContentController : BetterCalmControllerBase
    {
        private readonly IAudioContentLogicAdapter audioContentLogicAdapter;

        public AudioContentController(IAudioContentLogicAdapter audioContentLogicAdapter)
        {
            this.audioContentLogicAdapter = audioContentLogicAdapter;
        }

        [HttpGet("{id}", Name = "GetAudioContentById")]
        public IActionResult Get(int audioContentId)
        {
            return Ok(audioContentLogicAdapter.GetById(audioContentId));
        }

        [ServiceFilter(typeof(AuthorizationAttributeFilter))]
        [HttpPost]
        public IActionResult Post([FromBody] AudioContentModel audioContentModel)
        {
            var audioContentCreated = audioContentLogicAdapter.Add(audioContentModel);
            return CreatedAtRoute("GetAudioContentById", audioContentCreated.Id, audioContentCreated);
        }
        [ServiceFilter(typeof(AuthorizationAttributeFilter))]
        [HttpDelete("{audioContentId}")]
        public IActionResult DeleteById(int audioContentId)
        {
            audioContentLogicAdapter.DeleteById(audioContentId);
            return NoContent();
        }
        [ServiceFilter(typeof(AuthorizationAttributeFilter))]
        [HttpPut]
        public IActionResult Update(AudioContentModel audioContentModel)
        {
            audioContentLogicAdapter.Update(audioContentModel);
            return NoContent();
        }
    }
}