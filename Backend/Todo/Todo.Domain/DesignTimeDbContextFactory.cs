using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Todo.Domain.Configurations;

namespace Todo.Domain
{
    internal sealed class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<TodoDbContext>
    {
        public TodoDbContext CreateDbContext(string[] args)
        {
            AppSettings appSettings = new AppSettings(false);
            var dbConnectionString = appSettings.GetDbConnectionString();
            var options = new DbContextOptionsBuilder<TodoDbContext>();
            options.UseNpgsql(dbConnectionString);
            return new TodoDbContext(options.Options);
        }
    }
}
