using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SAM.Infrastructure.Persistences.Contexts;
using SAM.Infrastructure.Persistences.Interfaces;
using SAM.Infrastructure.Persistences.Repositories;

namespace SAM.Infrastructure.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly = typeof(SAMContext).Assembly.FullName;
            services.AddDbContext<SAMContext>(
                options => options.UseSqlServer(
                    configuration.GetConnectionString("SAMConnection"), b => b.MigrationsAssembly(assembly)), ServiceLifetime.Transient);
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
