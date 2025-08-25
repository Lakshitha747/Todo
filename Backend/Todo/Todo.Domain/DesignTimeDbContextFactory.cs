using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Todo.Domain
{
    internal sealed class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<TodoDbContext>
    {
        public TodoDbContext CreateDbContext(string[] args)
        {
            var dbcon = "Host=localhost;Username=postgres;Password=root;Database=todo";
            var options = new DbContextOptionsBuilder<TodoDbContext>();
            options.UseNpgsql(dbcon);
            return new TodoDbContext(options.Options);
        }
    }
}
