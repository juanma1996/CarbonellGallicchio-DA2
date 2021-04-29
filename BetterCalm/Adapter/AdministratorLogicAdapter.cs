using System;
using AdapterInterface;
using Model.In;
using Model.Out;

namespace Adapter
{
    public class AdministratorLogicAdapter : IAdministratorLogicAdapter
    {
        public AdministratorLogicAdapter()
        {
        }

        public AdministratorBasicInfoModel GetById(int administratorId)
        {
            throw new NotImplementedException();
        }

        public void Add(AdministratorModel administrator)
        {
            throw new NotImplementedException();
        }

        public void Delete(int administratorId)
        {
            throw new NotImplementedException();
        }

        public void Update(AdministratorModel administrator)
        {
            throw new NotImplementedException();
        }
    }
}
