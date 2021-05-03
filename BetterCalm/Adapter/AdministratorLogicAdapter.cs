using System;
using Adapter.Mapper;
using AdapterExceptions;
using AdapterInterface;
using AutoMapper;
using BusinessExceptions;
using BusinessLogicInterface;
using Domain;
using Model.In;
using Model.Out;

namespace Adapter
{
    public class AdministratorLogicAdapter : IAdministratorLogicAdapter
    {
        private readonly IAdministratorLogic administratorLogic;
        private readonly IMapper mapper;
        public AdministratorLogicAdapter(IAdministratorLogic administratorLogic, IModelMapper mapper)
        {
            this.administratorLogic = administratorLogic;
            this.mapper = mapper.Configure();
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
                throw new NotFoundException(e.Message);
            }
        }

        public void Add(AdministratorModel administrator)
        {
            try
            {
                Administrator administratorIn = mapper.Map<Administrator>(administrator);
                administratorLogic.Add(administratorIn);
            }
            catch (AlreadyExistException e)
            {
                throw new EntityAlreadyExistException(e.Message);
            }
        }

        public void Delete(int administratorId)
        {
            administratorLogic.DeleteById(administratorId);
        }

        public void Update(AdministratorModel administrator)
        {
            Administrator administratorToUpdate = mapper.Map<Administrator>(administrator);
            administratorLogic.Update(administratorToUpdate);
        }
    }
}
