using System;
using Domain;

namespace BusinessLogicInterface
{
    public interface IPsychologistLogic
    {
        Psychologist GetById(int psychologistId);
        Psychologist Add(Psychologist psycologist);
        void DeleteById(int psychologistId);
        void Update(Psychologist psycologist);
    }
}
