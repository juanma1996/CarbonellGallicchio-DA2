using Model.In;
using Model.Out;

namespace AdapterInterface
{
    public interface ISessionLogicAdapter
    {
        SessionBasicInfoModel Add(SessionModel sessionModel);
    }
}