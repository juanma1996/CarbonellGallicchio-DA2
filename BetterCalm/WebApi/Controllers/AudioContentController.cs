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

        [HttpGet("{id}", Name = "GetAudioContentById")]
        public IActionResult Get(int id)
        {
            return Ok(audioContentLogicAdapter.GetById(id));
        }

        [ServiceFilter(typeof(AuthorizationAttributeFilter))]
        [HttpPost]
        public IActionResult Post([FromBody] AudioContentModel audioContentModel)
        {
            var audioContentCreated = audioContentLogicAdapter.Add(audioContentModel);
            return CreatedAtRoute("GetAudioContentById", new { id = audioContentCreated.Id }, audioContentCreated);
        }
        [ServiceFilter(typeof(AuthorizationAttributeFilter))]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            audioContentLogicAdapter.DeleteById(id);
            return NoContent();
        }
        [ServiceFilter(typeof(AuthorizationAttributeFilter))]
        [HttpPut]
        public IActionResult Put(AudioContentModel audioContentModel)
        {
            audioContentLogicAdapter.Update(audioContentModel);
            return NoContent();
        }
    }
}