using System;
using Model.Out;

namespace AdapterInterface
{
    public interface IPsychologistLogicAdapter
    {
        PsychologistBasicInfoModel GetById(int psychologistId);
    }
}
