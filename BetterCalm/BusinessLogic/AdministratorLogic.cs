using System;
using BusinessLogicInterface;
using DataAccessInterface;
using Domain;

namespace BusinessLogic
{
    public class AdministratorLogic : IAdministratorLogic
    {
        private readonly IRepository<Administrator> administratorRepository;
        private readonly Validation validation = new Validation();

        public AdministratorLogic(IRepository<Administrator> administratorRepository)
        {
            this.administratorRepository = administratorRepository;
        }

        public Administrator GetById(int administratorId)
        {
            Administrator administrator = administratorRepository.GetById(administratorId);
            validation.Validate(administrator);
            return administrator;
        }

        public Administrator Add(Administrator administrator)
        {
            if (administratorRepository.Exists(a => a.Email == administrator.Email))
            {
                validation.NullObjectException();
            }

            return administratorRepository.Add(administrator);
        }

        public void DeleteById(int administratorId)
        {
            Administrator administrator = administratorRepository.GetById(administratorId);
            validation.Validate(administrator);
            administratorRepository.Delete(administrator);
        }

        public void Update(Administrator administratorModel)
        {
            if (!administratorRepository.Exists(a => a.Id == administratorModel.Id))
            {
                validation.NullObjectException();
            }
            else
            {
                administratorRepository.Update(administratorModel);
            }
        }

        public Administrator GetByEmailAndPassword(string email, string password)
        {
            Administrator administrator = administratorRepository.Get(a => a.Email == email && a.Password == password);
            validation.Validate(administrator);
            return administrator;
        }
    }
}
