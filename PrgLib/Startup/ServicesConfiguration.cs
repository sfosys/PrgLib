using Microsoft.EntityFrameworkCore;
using PrgLib.Api;
using PrgLib.Core.Entities;
using PrgLib.Core.Interfaces;
using PrgLib.Infrastructure.Data;
using PrgLib.Infrastructure.Repositories;
using PrgLib.Interfaces;

namespace PrgLib.Startup
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection RegisterStandardServices(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            return services;
        }
        public static IServiceCollection RegisterAppServices(this IServiceCollection services)
        {
            services.AddScoped<IGenericRepository<ProgramType>, ProgramTypeRepository>();
            return services;
        }
        public static IServiceCollection RegisterApiServices(this IServiceCollection services)
        {
            services.AddScoped<IGenericApi<ProgramType>, ProgramTypeApi>();
            return services;
        }
        public static IServiceCollection RegisterDbServices(this IServiceCollection services, WebApplicationBuilder builder)
        {

            var connectionString = builder.Configuration.
            GetConnectionString("Default");
            builder.Services.AddDbContext<AppDbContext>(o
            => o.UseSqlServer(connectionString));
            return services;
        }

    }
}
