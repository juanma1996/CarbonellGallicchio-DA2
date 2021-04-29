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
            throw new NotImplementedException();
        }
    }
}
