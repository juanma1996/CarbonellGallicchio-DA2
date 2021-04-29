using System;
using Model.Out;

namespace AdapterInterface
{
    public interface IAdministratorLogicAdapter
    {
        AdministratorBasicInfoModel GetById(int administratorId);
    }
}
