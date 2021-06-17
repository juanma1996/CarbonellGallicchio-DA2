using AutoMapper;
using Domain;
using Model.In;

namespace Adapter.Mapper.Profiles
{
    public class PacientProfile : Profile
    {
        public PacientProfile()
        {
            CreateMap<PacientModel, Pacient>()
                .ForMember(prop => prop.GeneratedBonus, opt => opt.Ignore())
                .ForMember(prop => prop.BonusApproved, opt => opt.Ignore())
                .ForMember(prop => prop.BonusAmount, opt => opt.Ignore())
                .ForMember(prop => prop.ConsultationsQuantity, opt => opt.Ignore())
                .ForMember(prop => prop.Id, opt => opt.Ignore());
        }
    }
}
