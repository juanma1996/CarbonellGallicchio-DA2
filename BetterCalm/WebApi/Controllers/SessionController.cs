using AdapterInterface;
using BetterCalm.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Model.In;
using Model.Out;

namespace WebApi.Controllers
{
    [Route("api/sessions")]
    public class SessionController : BetterCalmControllerBase
    {
        private readonly ISessionLogicAdapter sessionLogicAdapter;

        public SessionController(ISessionLogicAdapter sessionLogicAdapter)
        {
            this.sessionLogicAdapter = sessionLogicAdapter;
        }

        [HttpPost]
        public IActionResult Post(SessionModel sessionModel)
        {
            SessionBasicInfoModel sessionCreated = sessionLogicAdapter.Add(sessionModel);
            return CreatedAtRoute("", sessionCreated);
        }
    }
}