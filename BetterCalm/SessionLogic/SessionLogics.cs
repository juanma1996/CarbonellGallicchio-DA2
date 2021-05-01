using DataAccessInterface;
using Domain;
using SessionInterface;
using System;

namespace SessionLogic
{
    public class SessionLogics : ISessionLogic
    {
        private readonly IRepository<Session> sessionRepository;
        private readonly IRepository<Administrator> administratorRepository;

        public SessionLogics(IRepository<Session> sessionRepository, IRepository<Administrator> administratorRepository)
        {
            this.sessionRepository = sessionRepository;
            this.administratorRepository = administratorRepository;
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
            return Guid.TryParse(token, out guidOutput);
        }

        public Session Add(string email, string password)
        {
            Administrator admin = GetByEmailAndPassword(email, password);
            Session newSession = new Session()
            {
                Token = Guid.NewGuid(),
                Administrator = admin
            };
            return sessionRepository.Add(newSession);
        }

        private Administrator GetByEmailAndPassword(string email, string password)
        {
            return administratorRepository.Get(a => a.Email == email && a.Password == password);
        }
    }
}
