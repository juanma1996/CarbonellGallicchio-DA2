using System;
using System.Collections.Generic;
using Domain;

namespace BusinessLogicInterface
{
    public interface IPsychologistLogic
    {
        Psychologist GetById(int psychologistId);
        Psychologist Add(Psychologist psycologist);
        void DeleteById(int psychologistId);
        void Update(Psychologist psycologist);
        Psychologist GetAvailableByProblematicId(int problematicId);
        List<Psychologist> GetAllByProblematicId(int problematicId);
        Psychologist GetAvailableByProblematicIdAndDate(int problematicId, DateTime date);
    }
}
