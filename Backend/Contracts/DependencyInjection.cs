using Contracts.Contracts;
using Contracts.Managers;
using Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Contracts
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddContractDependencies(this IServiceCollection services)
        {
            services.AddDomainDependencies();
            services.AddScoped<ITaskManager, TaskManager>();
            return services.AddContractDependencies();
        }
    }
}
