using System;
using Model.In;
using Model.Out;

namespace AdapterInterface
{
    public interface IConsultationLogicAdapter
    {
        PsychologistBasicInfoModel Add(ConsultationModel consultationModel);
    }
}
