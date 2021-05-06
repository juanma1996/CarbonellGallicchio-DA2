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

        // POST: 
        /// <summary>
        /// Creates an administrator apikey token.
        /// </summary>
        /// <remarks>
        /// Creates an administrator apikey token from administrator user credentials.
        /// </remarks>
        /// <response code="201">Created.</response>
        /// <response code="400">Error. The email can't be empty.</response>
        /// <response code="400">Error. The password can't be empty.</response>
        /// <response code="404">Not Found. There is no administrator registered for the given data.</response>
        /// <response code="500">InternalServerError. Server problems, unexpected error.</response>
        [HttpPost]
        public IActionResult Post(SessionModel sessionModel)
        {
            SessionBasicInfoModel sessionCreated = sessionLogicAdapter.Add(sessionModel);
            return CreatedAtRoute("", sessionCreated);
        }
    }
}