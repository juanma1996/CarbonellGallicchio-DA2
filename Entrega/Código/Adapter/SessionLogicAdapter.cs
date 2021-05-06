using Adapter.Mapper;
using AdapterExceptions;
using AdapterInterface;
using AutoMapper;
using BusinessExceptions;
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
            try
            {
                sessionModelValidator.Validate(sessionModel);
                string Email = sessionModel.Email;
                string Password = sessionModel.Password;
                Session sessionOut = sessionLogic.Add(Email, Password);
                SessionBasicInfoModel sessionToReturn = mapper.Map<SessionBasicInfoModel>(sessionOut);
                return sessionToReturn;
            }
            catch (NullObjectException e)
            {
                throw new NotFoundException(e.errorMessage);
            }
        }
    }
}
