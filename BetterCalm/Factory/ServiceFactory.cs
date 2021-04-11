using BusinessLogic;
using BusinessLogicInterface;
using DataAccess;
using DataAccess.Context;
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
            services.AddScoped<IPlaylistRepository, PlaylistRepository>();
            services.AddScoped<IPlaylistLogic, PlaylistLogic>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryLogic, CategoryLogic>();
        }
        public void AddDbContextService()
        {
            services.AddDbContext<DbContext, BetterCalmContext>();
        }
    }
}