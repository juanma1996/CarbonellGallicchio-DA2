using Model.In;
using Model.Out;
using System.Collections.Generic;

namespace AdapterInterface
{
    public interface IPsychologistLogicAdapter
    {
        PsychologistBasicInfoModel GetById(int psychologistId);
        PsychologistBasicInfoModel Add(PsychologistModel psychologistModel);
        void Delete(int psychologistId);
        void Update(int id, PsychologistModel psychologistModel);
        List<PsychologistBasicInfoModel> GetAll();
    }
}
