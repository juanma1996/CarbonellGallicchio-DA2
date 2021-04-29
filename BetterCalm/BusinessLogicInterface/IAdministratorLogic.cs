using System;
using Domain;

namespace BusinessLogicInterface
{
    public interface IAdministratorLogic
    {
        Administrator GetById(int administratorId);
        void Add(Administrator administrator);
    }
}
