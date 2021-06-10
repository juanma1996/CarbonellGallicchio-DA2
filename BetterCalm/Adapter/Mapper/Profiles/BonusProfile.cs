using AutoMapper;
using Domain;
using Model.Out;

namespace Adapter.Mapper.Profiles
{
    public class BonusProfile : Profile
    {
        public BonusProfile()
        {
            CreateMap<Pacient, BonusBasicInfoModel>()
                .ForMember(p => p.PacientId, opt => opt.MapFrom(c => c.Id))
                .ForMember(p => p.PacientEmail, opt => opt.MapFrom(c => c.Email));
        }
    }
}
