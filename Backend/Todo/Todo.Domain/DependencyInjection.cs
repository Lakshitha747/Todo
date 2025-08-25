using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Todo.Domain.Configurations;
using Todo.Domain.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDomainDependencies(this IServiceCollection services)
        {
            AppSettings appSettings = new();
            var dbConnectionString = appSettings.GetDbConnectionString();

            services.AddDbContext<TodoDbContext>(options =>
            {
                options.UseNpgsql(dbConnectionString);
            });

            services.AddScoped<ITaskRepository, TaskRepository>();

            return services;
        }
    }
}
