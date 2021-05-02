using Adapter.Mapper;
using AdapterInterface;
using AutoMapper;
using Domain;
using Model.In;
using Model.Out;
using SessionInterface;

namespace Adapter
{
    public class SessionLogicAdapter : ISessionLogicAdapter
    {
        private readonly ISessionLogic sessionLogic;
        private readonly IMapper mapper;
        public SessionLogicAdapter(ISessionLogic sessionLogic, IModelMapper mapper)
        {
            this.sessionLogic = sessionLogic;
            this.mapper = mapper.Configure();
        }

        public SessionBasicInfoModel Add(SessionModel sessionModel)
        {
            string Email = sessionModel.Email;
            string Password = sessionModel.Password;
            Session sessionOut = sessionLogic.Add(Email, Password);
            SessionBasicInfoModel sessionToReturn = mapper.Map<SessionBasicInfoModel>(sessionOut);
            return sessionToReturn;
        }
    }
}
