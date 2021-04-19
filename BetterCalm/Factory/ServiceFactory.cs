using BusinessLogic;
using BusinessLogic.Mapper;
using BusinessLogicInterface;
using DataAccess;
using DataAccess.Context;
using DataAccess.Repositories;
using DataAccessInterface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

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
        }
        public void AddDbContextService()
        {
            services.AddDbContext<DbContext, BetterCalmContext>();
        }
    }
}