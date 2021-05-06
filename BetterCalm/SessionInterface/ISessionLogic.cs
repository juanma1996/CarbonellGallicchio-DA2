using Domain;

namespace SessionInterface
{
    public interface ISessionLogic
    {
        bool IsValidToken(string token);
        Session Add(string email, string password);
    }
}
