using System;
using System.Collections.Generic;
using BusinessLogicInterface;
using Domain;

namespace BusinessLogic
{
    public class ProblematicLogic : IProblematicLogic
    {
        public ProblematicLogic()
        {
        }

        public List<Problematic> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
