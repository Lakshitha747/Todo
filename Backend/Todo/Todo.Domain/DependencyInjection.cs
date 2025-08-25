using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Todo.Domain.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDomainDependencies(this IServiceCollection services)
        {
            var dbConnection = "Host=localhost;Username=postgres;Password=root;Database=todo";

            services.AddDbContext<TodoDbContext>(options =>
            {
                options.UseNpgsql(dbConnection);
            });

            services.AddScoped<ITaskRepository, TaskRepository>();

            return services;
        }
    }
}
