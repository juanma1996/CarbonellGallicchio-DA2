using AdapterInterface;
using BetterCalm.WebApi.Controllers;
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

        public object Post(SessionModel sessionModel)
        {
            throw new NotImplementedException();
        }
    }
}