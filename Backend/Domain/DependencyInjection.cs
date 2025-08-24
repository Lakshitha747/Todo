using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Domain
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDomainDependencies(this IServiceCollection services)
        {
            services.AddDbContext<TodoDbContext>(options =>
            {
                options.UseNpgsql();
            });

            return services.AddDomainDependencies();
        }
    }
}
