using BusinessExceptions;
using BusinessLogicInterface;
using DataAccessInterface;
using Domain;
using ValidatorInterface;

namespace BusinessLogic
{
    public class AdministratorLogic : IAdministratorLogic
    {
        private readonly IRepository<Administrator> administratorRepository;
        private readonly IValidator<Administrator> administratorvalidator;

        public AdministratorLogic(IRepository<Administrator> administratorRepository, IValidator<Administrator> administratorvalidator)
        {
            this.administratorRepository = administratorRepository;
            this.administratorvalidator = administratorvalidator;
        }

        public Administrator GetById(int administratorId)
        {
            Administrator administrator = administratorRepository.GetById(administratorId);
            administratorvalidator.Validate(administrator);
            return administrator;
        }

        public Administrator Add(Administrator administrator)
        {
            if (administratorRepository.Exists(a => a.Email == administrator.Email))
            {
                throw new AlreadyExistException("There is an administrator registered for the given data");
            }

            return administratorRepository.Add(administrator);
        }

        public void DeleteById(int administratorId)
        {
            Administrator administrator = administratorRepository.GetById(administratorId);
            administratorvalidator.Validate(administrator);
            administratorRepository.Delete(administrator);
        }

        public void Update(Administrator administratorModel)
        {
            if (!administratorRepository.Exists(a => a.Id == administratorModel.Id))
            {
                throw new NullObjectException("There is no administrator registered for the given data");
            }
            else
            {
                administratorRepository.Update(administratorModel);
            }
        }

        public Administrator GetByEmailAndPassword(string email, string password)
        {
            Administrator administrator = administratorRepository.Get(a => a.Email == email && a.Password == password);
            administratorvalidator.Validate(administrator);
            return administrator;
        }
    }
}
