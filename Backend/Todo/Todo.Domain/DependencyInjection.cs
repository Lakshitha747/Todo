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
            var isProduction = Environment.GetEnvironmentVariable("Production");

            if (string.IsNullOrEmpty(isProduction))
            {
                isProduction = "false";
            }

            AppSettings appSettings = new(bool.Parse(isProduction));
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
