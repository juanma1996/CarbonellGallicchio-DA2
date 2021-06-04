using Adapter.Mapper;
using AdapterExceptions;
using AdapterInterface;
using AutoMapper;
using BusinessExceptions;
using BusinessLogicInterface;
using Domain;
using Model.In;
using Model.Out;
using System.Collections.Generic;
using ValidatorInterface;

namespace Adapter
{
    public class AdministratorLogicAdapter : IAdministratorLogicAdapter
    {
        private readonly IAdministratorLogic administratorLogic;
        private readonly IMapper mapper;
        private readonly IValidator<AdministratorModel> administratorModelValidator;
        public AdministratorLogicAdapter(IAdministratorLogic administratorLogic, IModelMapper mapper,
            IValidator<AdministratorModel> administratorModelValidator)
        {
            this.administratorLogic = administratorLogic;
            this.mapper = mapper.Configure();
            this.administratorModelValidator = administratorModelValidator;
        }

        public AdministratorBasicInfoModel GetById(int administratorId)
        {
            try
            {
                Administrator administrator = administratorLogic.GetById(administratorId);
                return mapper.Map<AdministratorBasicInfoModel>(administrator);
            }
            catch (NullObjectException e)
            {
                throw new NotFoundException(e.errorMessage);
            }
        }

        public void Add(AdministratorModel administrator)
        {
            try
            {
                administratorModelValidator.Validate(administrator);
                Administrator administratorIn = mapper.Map<Administrator>(administrator);
                administratorLogic.Add(administratorIn);
            }
            catch (AlreadyExistException e)
            {
                throw new EntityAlreadyExistException(e.errorMessage);
            }
        }

        public void Delete(int administratorId)
        {
            try
            {
                administratorLogic.DeleteById(administratorId);
            }
            catch (NullObjectException e)
            {
                throw new NotFoundException(e.errorMessage);
            }
        }

        public void Update(AdministratorModel administrator)
        {
            try
            {
                administratorModelValidator.Validate(administrator);
                Administrator administratorToUpdate = mapper.Map<Administrator>(administrator);
                administratorLogic.Update(administratorToUpdate);
            }
            catch (NullObjectException e)
            {
                throw new NotFoundException(e.errorMessage);
            }
        }

        public List<AdministratorBasicInfoModel> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}
