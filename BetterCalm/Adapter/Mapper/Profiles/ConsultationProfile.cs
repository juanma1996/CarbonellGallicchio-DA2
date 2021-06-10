using AutoMapper;
using Domain;
using Model.In;
using Model.Out;

namespace Adapter.Mapper.Profiles
{
    public class ConsultationProfile : Profile
    {
        public ConsultationProfile()
        {
            CreateMap<ConsultationModel, Consultation>()
                .ForMember(prop => prop.Id, opt => opt.Ignore())
                .ForMember(prop => prop.Cost, opt => opt.Ignore())
                .ForMember(prop => prop.Psychologist, opt => opt.Ignore());
            CreateMap<PacientModel, Pacient>()
                .ForMember(prop => prop.GeneratedBonus, opt => opt.Ignore())
                .ForMember(prop => prop.BonusApproved, opt => opt.Ignore())
                .ForMember(prop => prop.BonusAmount, opt => opt.Ignore())
                .ForMember(prop => prop.ConsultationsQuantity, opt => opt.Ignore())
                .ForMember(prop => prop.Id, opt => opt.Ignore());
            CreateMap<Consultation, ConsultationBasicInfoModel>();
            CreateMap<Psychologist, PsychologistBasicInfoModel>();
            CreateMap<PsychologistProblematic, ProblematicBasicInfoModel>()
                .ForMember(p => p.Name, opt => opt.MapFrom(c => c.Problematic.Name))
                .ForMember(p => p.Id, opt => opt.MapFrom(c => c.Problematic.Id));
        }
    }
}
