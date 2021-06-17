using Adapter;
using Adapter.Mapper;
using AdapterInterface;
using BusinessLogic;
using BusinessLogicInterface;
using DataAccess.Context;
using DataAccess.Repositories;
using DataAccessInterface;
using Domain;
using ImporterLogic;
using ImporterLogicInterface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Model.In;
using SessionInterface;
using SessionLogic;
using Validator;
using ValidatorInterface;

namespace Factory
{
    public class ServiceFactory
    {
        private readonly IServiceCollection services;

        public ServiceFactory(IServiceCollection services)
        {
            this.services = services;
        }

        public void AddCustomServices()
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ICategoryLogic, CategoryLogic>();
            services.AddScoped<IModelMapper, ModelMapper>();
            services.AddScoped<ICategoryLogicAdapter, CategoryLogicAdapter>();
            services.AddScoped<IAudioContentLogicAdapter, AudioContentLogicAdapter>();
            services.AddScoped<IPlayableContentLogic, PlayableContentLogic>();
            services.AddScoped<IPsychologistLogicAdapter, PsychologistLogicAdapter>();
            services.AddScoped<IPsychologistLogic, PsychologistLogic>();
            services.AddScoped<IProblematicLogic, ProblematicLogic>();
            services.AddScoped<IProblematicLogicAdapter, ProblematicLogicAdapter>();
            services.AddScoped<ISessionLogic, SessionLogics>();
            services.AddScoped<IAdministratorLogicAdapter, AdministratorLogicAdapter>();
            services.AddScoped<IAdministratorLogic, AdministratorLogic>();
            services.AddScoped<IConsultationLogicAdapter, ConsultationLogicAdapter>();
            services.AddScoped<IConsultationLogic, ConsultationLogic>();
            services.AddScoped<IAgendaLogic, AgendaLogic>();
            services.AddScoped<IValidator<AdministratorModel>, AdministratorModelValidator>();
            services.AddScoped<IValidator<Administrator>, AdministratorValidator>();
            services.AddScoped<IValidator<AudioContentModel>, AudioContentModelValidator>();
            services.AddScoped<IValidator<PlayableContent>, PlayableContentValidator>();
            services.AddScoped<IValidator<Playlist>, PlaylistValidator>();
            services.AddScoped<IValidator<PsychologistModel>, PsychologistModelValidator>();
            services.AddScoped<IValidator<Psychologist>, PsychologistValidator>();
            services.AddScoped<IValidator<SessionModel>, SessionModelValidator>();
            services.AddScoped<IValidator<PlaylistModel>, PlaylistModelValidator>();
            services.AddScoped<ISessionLogicAdapter, SessionLogicAdapter>();
            services.AddScoped<IValidator<PacientModel>, PacientModelValidator>();
            services.AddScoped<IValidator<ConsultationModel>, ConsultationModelValidator>();
            services.AddScoped<IImporterLogic, ImporterLogics>();
            services.AddScoped<ImporterLogic.Mapper.IModelMapper, ImporterLogic.Mapper.ModelMapper>();
            services.AddScoped<IVideoContentLogicAdapter, VideoContentLogicAdapter>();
            services.AddScoped<IValidator<VideoContentModel>, VideoContentModelValidator>();
            services.AddScoped<IBonusLogicAdapter, BonusLogicAdapter>();
            services.AddScoped<IBonusLogic, BonusLogic>();
            services.AddScoped<IValidator<BonusModel>, BonusModelValidator>();
            services.AddScoped<IValidator<Pacient>, PacientValidator>();
            services.AddScoped<IPlaylistLogicAdapter, PlaylistLogicAdapter>();
            services.AddScoped<IPlaylistLogic, PlaylistLogic>();
            services.AddScoped<IImporterLogicAdapter, ImporterLogicAdapter>();
        }
        public void AddDbContextService()
        {
            services.AddDbContext<DbContext, BetterCalmContext>();
        }
    }
}