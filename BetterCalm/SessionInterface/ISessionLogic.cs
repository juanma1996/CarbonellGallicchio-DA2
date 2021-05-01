using System;

namespace SessionInterface
{
    public interface ISessionLogic
    {
        bool IsValidToken(string token);
    }
}
