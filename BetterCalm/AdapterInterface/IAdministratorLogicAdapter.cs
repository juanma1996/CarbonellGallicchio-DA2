using Model.In;
using Model.Out;
using System.Collections.Generic;

namespace AdapterInterface
{
    public interface IAdministratorLogicAdapter
    {
        AdministratorBasicInfoModel GetById(int administratorId);
        void Add(AdministratorModel administratorModel);
        void Delete(int administratorId);
        void Update(AdministratorModel administratorModel);
        List<AdministratorBasicInfoModel> GetAll();
    }
}
