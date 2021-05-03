using Adapter.Mapper;
using AdapterInterface;
using AutoMapper;
using Domain;
using Model.In;
using Model.Out;
using SessionInterface;
using ValidatorInterface;

namespace Adapter
{
    public class SessionLogicAdapter : ISessionLogicAdapter
    {
        private readonly ISessionLogic sessionLogic;
        private readonly IMapper mapper;
        private readonly IValidator<SessionModel> sessionModelValidator;
        public SessionLogicAdapter(ISessionLogic sessionLogic, IModelMapper mapper, IValidator<SessionModel> sessionModelValidator)
        {
            this.sessionLogic = sessionLogic;
            this.mapper = mapper.Configure();
            this.sessionModelValidator = sessionModelValidator;
        }

        public SessionBasicInfoModel Add(SessionModel sessionModel)
        {
            sessionModelValidator.Validate(sessionModel);
            string Email = sessionModel.Email;
            string Password = sessionModel.Password;
            Session sessionOut = sessionLogic.Add(Email, Password);
            SessionBasicInfoModel sessionToReturn = mapper.Map<SessionBasicInfoModel>(sessionOut);
            return sessionToReturn;
        }
    }
}
