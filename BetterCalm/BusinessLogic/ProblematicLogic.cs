using System;
using System.Collections.Generic;
using BusinessLogicInterface;
using DataAccessInterface;
using Domain;

namespace BusinessLogic
{
    public class ProblematicLogic : IProblematicLogic
    {
        private readonly IRepository<Problematic> problematicRepository;
        public ProblematicLogic(IRepository<Problematic> problematicRepository)
        {
            this.problematicRepository = problematicRepository;
        }

        public List<Problematic> GetAll()
        {
            return problematicRepository.GetAll();
        }
    }
}
