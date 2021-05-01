using DataAccessInterface;
using Domain;
using SessionInterface;
using System;

namespace SessionLogic
{
    public class SessionLogics : ISessionLogic
    {
        private readonly IRepository<Session> sessionRepository;

        public SessionLogics(IRepository<Session> sessionRepository)
        {
            this.sessionRepository = sessionRepository;
        }

        public bool IsValidToken(string token)
        {
            bool isValidToken = false;
            if (IsGuid(token))
            {
                isValidToken = sessionRepository.Exists(s => s.Token == Guid.Parse(token)); 
            }

            return isValidToken;
        }

        private bool IsGuid(string token)
        {
            Guid guidOutput;
            return Guid.TryParse(token,out guidOutput);
        }

        public Session Add(string email, string password)
        {
            Session newSession = new Session()
            {
                Token = Guid.NewGuid()
            };
            return sessionRepository.Add(newSession);
        }
    }
}
