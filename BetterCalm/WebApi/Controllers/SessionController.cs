using AdapterExceptions;
using AdapterInterface;
using BetterCalm.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Model.In;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
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
            try
            {
                var sessionCreated = sessionLogicAdapter.Add(sessionModel);
                return CreatedAtRoute("", sessionCreated);
            }
            catch (NullObjectMappingException e)
            {
                return NotFound(e);
            }
        }
    }
}