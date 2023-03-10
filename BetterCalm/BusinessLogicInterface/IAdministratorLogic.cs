using Domain;

namespace BusinessLogicInterface
{
    public interface IAdministratorLogic
    {
        Administrator GetById(int administratorId);
        Administrator Add(Administrator administrator);
        void DeleteById(int administratorId);
        void Update(Administrator administratorModel);
        Administrator GetByEmailAndPassword(string email, string password);
    }
}
