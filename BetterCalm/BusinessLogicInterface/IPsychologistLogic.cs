using System;
using Domain;

namespace BusinessLogicInterface
{
    public interface IPsychologistLogic
    {
        Psychologist GetById(int psychologistId);
        Psychologist Add(Psychologist psycologist);
    }
}
