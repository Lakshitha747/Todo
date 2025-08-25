using Microsoft.Extensions.DependencyInjection;
using Todo.Contracts.Contracts;
using Todo.Contracts.Managers;
using Todo.Domain;

namespace Todo.Contracts
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddContractDependencies(this IServiceCollection services)
        {
            services.AddDomainDependencies();

            services.AddScoped<ITaskManager, TaskManager>();

            return services;
        }
    }
}
