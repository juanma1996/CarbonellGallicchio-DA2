﻿using System;
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
            return administratorRepository.Add(administrator);
        }

        public void DeleteById(int administratorId)
        {
            Administrator administrator = administratorRepository.GetById(administratorId);
            administratorRepository.Delete(administrator);
        }

        public void Update(Administrator administratorModel)
        {
            administratorRepository.Update(administratorModel);
        }
    }
}
