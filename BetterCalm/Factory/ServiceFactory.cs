using Adapter;
using Adapter.Mapper;
using AdapterInterface;
using BusinessLogic;
using BusinessLogicInterface;
using DataAccess.Context;
using DataAccess.Repositories;
using DataAccessInterface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SessionInterface;
using SessionLogic;

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
            services.AddScoped<IPlaylistLogic, PlaylistLogic>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ICategoryLogic, CategoryLogic>();
            services.AddScoped<IModelMapper, ModelMapper>();
            services.AddScoped<ICategoryLogicAdapter, CategoryLogicAdapter>();
            services.AddScoped<IAudioContentLogicAdapter, AudioContentLogicAdapter>();
            services.AddScoped<IAudioContentLogic, AudioContentLogic>();
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
        }
        public void AddDbContextService()
        {
            services.AddDbContext<DbContext, BetterCalmContext>();
        }
    }
}