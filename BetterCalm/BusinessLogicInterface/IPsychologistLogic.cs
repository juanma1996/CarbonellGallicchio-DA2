using System;
using Domain;

namespace BusinessLogicInterface
{
    public interface IPsychologistLogic
    {
        Psychologist GetById(int psychologistId);
    }
}
