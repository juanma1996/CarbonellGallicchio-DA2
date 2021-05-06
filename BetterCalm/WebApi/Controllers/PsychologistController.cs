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

        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            PsychologistBasicInfoModel psychologist = psychologistDomainToModelAdapter.GetById(id);
            return Ok(psychologist);
        }
        [ServiceFilter(typeof(AuthorizationAttributeFilter))]
        [HttpPost]
        public IActionResult Post(PsychologistModel psycologistIn)
        {
            PsychologistBasicInfoModel psychologistCreated = psychologistDomainToModelAdapter.Add(psycologistIn);
            return CreatedAtRoute("Get", new { id = psychologistCreated.Id }, psychologistCreated);
        }
        [ServiceFilter(typeof(AuthorizationAttributeFilter))]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            psychologistDomainToModelAdapter.Delete(id);
            return NoContent();
        }
        [ServiceFilter(typeof(AuthorizationAttributeFilter))]
        [HttpPut]
        public IActionResult Put([FromBody] PsychologistModel psychologistModel)
        {
            psychologistDomainToModelAdapter.Update(psychologistModel);
            return NoContent();
        }
    }
}
