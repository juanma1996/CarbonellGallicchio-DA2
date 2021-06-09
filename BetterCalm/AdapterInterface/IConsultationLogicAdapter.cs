using Model.In;
using Model.Out;

namespace AdapterInterface
{
    public interface IConsultationLogicAdapter
    {
        ConsultationBasicInfoModel Add(ConsultationModel consultationModel);
    }
}
