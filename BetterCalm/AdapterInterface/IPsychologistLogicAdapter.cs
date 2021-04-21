using System;
using Model.In;
using Model.Out;

namespace AdapterInterface
{
    public interface IPsychologistLogicAdapter
    {
        PsychologistBasicInfoModel GetById(int psychologistId);
        PsychologistBasicInfoModel Add(PsychologistModel psychologistModel);
    }
}
